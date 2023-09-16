using System.IO;
using System.Text;
using Newtonsoft.Json;
using DicomClient = Dicom.Network.Client.DicomClient;
using Dicom.Imaging.Codec;
using System.Windows.Forms;

namespace CaptureX.Uploader
{
    public partial class MainForm : Form
    {
        private string sourcePath;
        private string destinationPath;
        private static bool GetMore = false;
        private static bool CanSend = false;

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer sendTimer;
        private const string LogFilePrefix = "captureX-log-";

        private static string logFolderPath = "C:\\";

        private UploaderStatuses _currentStatus = UploaderStatuses.NotStarted;

        private static int SendFileCount = 0;
        private const string CloudHost = "3.19.112.113";
        private const int CloudPort = 11112;
        private const string CloudAETitle = "CLOUDIMAGING192";

        private UploaderStatuses CurrentStatus
        {
            get { return _currentStatus; }
            set
            {
                _currentStatus = value;
                switch (value)
                {
                    case UploaderStatuses.NotStarted:
                        break;
                    case UploaderStatuses.ClinicConnected:
                        StatusPanel.BackColor = Color.Green;
                        break;
                    case UploaderStatuses.CloudConnected:
                        break;
                    case UploaderStatuses.NotConnected:
                        StatusPanel.BackColor = Color.Red;

                        break;
                    default:
                        break;
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();
            this.ShowInTaskbar = true;
            // Initialize the timer for file monitoring
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 5000; // 1 second
            timer.Tick += Timer_Tick;

            sendTimer = new System.Windows.Forms.Timer();
            sendTimer.Interval = 30000; // 30 second
            sendTimer.Tick += SendTimer_Tick;
        }

        private void ChangeValueOfProgressbar(int copiedFilesCount, int totalFilesToCopy)
        {
            int progressPercentage = (int)((copiedFilesCount * 100) / totalFilesToCopy);

            progressBarForFileUpload.BeginInvoke(new Action(() =>
            {
                progressBarForFileUpload.Value = progressPercentage;
            }));
        }

        private void CalculateAllFilesCount(string sourcePath, params string[] fileExtensions)
        {
            var filesCount = Directory
                .GetFiles(sourcePath, "*.*")
                .Count(file => fileExtensions
                    .Any(extension => file.EndsWith(extension)));

            lblAllValue.Text = filesCount.ToString();
        }

        private void ChangeDoneRemainCount(string destinationPath, params string[] fileExtensions)
        {
            var doneFilesCount = Directory
                .GetFiles(destinationPath, "*.*")
                .Count(file => fileExtensions
                    .Any(file.EndsWith));
            //.Any(extensions => file.EndsWith(extensions)));

            int allFiles;
            int remainFiles;
            int.TryParse(lblAllValue.Text.Trim(), out allFiles);

            remainFiles = allFiles - doneFilesCount;
            lblRemainValue.Text = remainFiles.ToString();
            lblDoneValue.Text = doneFilesCount.ToString();

            ChangeValueOfProgressbar(doneFilesCount, allFiles);
        }

        private async void SendTimer_Tick(object? sender, EventArgs e)
        {
            try
            {
                GetMore = false;
                if (CanSend)
                {
                    CanSend = false;

                    if (!Directory.Exists(Properties.Settings.Default.DestinationDirectory))
                    {
                        Directory.CreateDirectory(Properties.Settings.Default.DestinationDirectory);
                    }
                    else
                    {
                        string[] files = Directory.GetFiles(Properties.Settings.Default.DestinationDirectory, "*.dcm");

                        if (files.Length > 0)
                        {
                            var result = await SendRequest(files);

                            foreach (string filePath in files)
                            {
                                string fileName = Path.GetFileName(filePath);
                                LogMessage($"Sent to the cloud :{fileName} ");

                                string sentFullPath = Path.Combine(Properties.Settings.Default.DestinationDirectory,
                                    Properties.Settings.Default.SentFilesFolderName, fileName);
                                File.Move(filePath, sentFullPath);
                                SendFileCount++;
                                SentFilesCountLabel.Text = SendFileCount.ToString();
                                LogMessage($"Moved {fileName} to {Properties.Settings.Default.DestinationDirectory}");
                            }
                        }

                        SendCounterLabel.Text = SendFileCount.ToString();
                    }

                    CanSend = true;
                }

                GetMore = true;
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (GetMore)
            {
                try
                {
                    sourcePath = Properties.Settings.Default.SourceDirectory;
                    destinationPath = Properties.Settings.Default.DestinationDirectory;
                    string sentFolder = Properties.Settings.Default.SentFilesFolderName;
                    if (!Directory.Exists(Path.Combine(destinationPath, sentFolder)))
                    {
                        Directory.CreateDirectory(Path.Combine(destinationPath, sentFolder));
                    }

                    if (!string.IsNullOrEmpty(sourcePath) && !string.IsNullOrEmpty(destinationPath))
                    {
                        DateTime fromDate = dateTimePicker1.Value;
                        DateTime toDate = dateTimePicker2.Value;
                        if (fromDate.Date > toDate.Date || toDate.Date > DateTime.Now || fromDate.Date > DateTime.Now)
                        {
                            MessageBox.Show("From Date Must Be Lesser Than To Date!");
                        }

                        //CalculateTheCountOfFiles(false, sourcePath, destinationPath, fromDate, toDate);
                        CopyFilesRecursively(sourcePath, destinationPath, fromDate, toDate);
                    }
                }
                catch (Exception ex)
                {
                    GetMore = false;
                    MessageBox.Show("Error occurred: " + ex.Message);
                }
            }
        }

        public static bool IsLittleEndianExplicit(string filePath)
        {
            try
            {
                Dicom.DicomFile dicomFile = Dicom.DicomFile.Open(filePath);
                Dicom.DicomTransferSyntax transferSyntax = dicomFile.Dataset.InternalTransferSyntax;

                // TransferSyntax.ImplicitVRLittleEndian corresponds to LittleEndianExplicit
                return transferSyntax == Dicom.DicomTransferSyntax.ImplicitVRLittleEndian;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool IsJPEGLossless(string filePath)
        {
            try
            {
                // Specify the encoding to be used when opening the DICOM file
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                Encoding gb18030Encoding = Encoding.GetEncoding("GB18030");

                Dicom.DicomFile dicomFile = Dicom.DicomFile.Open(filePath, gb18030Encoding);
                Dicom.DicomTransferSyntax transferSyntax = dicomFile.Dataset.InternalTransferSyntax;


                return transferSyntax.UID.Name.Contains("Lossless");
                // TransferSyntax.JPEGLSLossless corresponds to JPEGLossless
                //return transferSyntax == DicomTransferSyntax.JPEGLSLossless;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ConvertToLEExplicit(string sourceFilePath, string destinationFilePath)
        {
            try
            {
                Convert.DicomConverter.ConvertToLEExplicit(sourceFilePath, destinationFilePath);
            }
            catch (Exception ex)
            {
                // An exception occurred; handle the error
                Console.WriteLine($"Error converting DICOM file: {ex.Message}");
            }
        }

        public void CopyFilesRecursively(string sourcePath, string destinationPath, DateTime fromDate, DateTime toDate)
        {
            var files = Directory.GetFiles(sourcePath, "*.*").Where(file => File.GetLastWriteTime(file) >= fromDate
                                                                            && File.GetLastWriteTime(file) <= toDate &&
                                                                            (file.EndsWith(".dcm") ||
                                                                             file.EndsWith(".dicom"))).ToArray();

            // Get the files in the source directory and copy them to the destination directory
            foreach (var file in files)
            {
                string fileName = Path.GetFileName(file);
                string destinationFile = Path.Combine(destinationPath, fileName);
                string sentFilePath = Path.Combine(destinationPath, Properties.Settings.Default.SentFilesFolderName,
                    fileName);
                if (!File.Exists(destinationFile) && !File.Exists(sentFilePath))
                {
                    try
                    {
                        File.Copy(file, destinationFile,
                            true); // Set the third parameter to 'true' to overwrite existing files
                        LogMessage(
                            $"file name : {file} \n \t source path : {sourcePath} \n \t destination path : {destinationPath} \n \t date : {DateTime.Now}");
                    }
                    catch (Exception e)
                    {
                        LogError(
                            $"error message :{e.Message} \n \t file name : {file} \n \t source path : {sourcePath} \n \t destination path : {destinationPath} \n \t date : {DateTime.Now}");
                    }

                    //if (IsJPEGLossless(file))
                    //{
                    //    ConvertToLEExplicit(file, destinationFile);
                    //}
                    //else
                    //{
                    //    File.Copy(file, destinationFile, true); // Set the third parameter to 'true' to overwrite existing files
                    //}
                }
            }

            //Get the subdirectories in the source directory and recursively copy their files
            foreach (var subdirectory in Directory.GetDirectories(sourcePath))
            {
                string directoryName = Path.GetFileName(subdirectory);
                string destinationSubdirectory = Path.Combine(destinationPath, directoryName);
                CopyFilesRecursively(subdirectory, destinationPath, fromDate, toDate);
            }
        }

        private void SourceFileBrwoserButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            DialogResult result = folderBrowser.ShowDialog();
            if (result == DialogResult.OK)
            {
                SourceDirectorylabel.Text = folderBrowser.SelectedPath;
                Properties.Settings.Default.SourceDirectory = folderBrowser.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        private void DestinationFileBrwoserButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            DialogResult result = folderBrowser.ShowDialog();
            if (result == DialogResult.OK)
            {
                DestinationDirectoryLabel.Text = folderBrowser.SelectedPath;
                Properties.Settings.Default.DestinationDirectory = folderBrowser.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SourceDirectorylabel.Text = Properties.Settings.Default.SourceDirectory;
            DestinationDirectoryLabel.Text = Properties.Settings.Default.DestinationDirectory;
            ClinicAETitleTextBox.Text = Properties.Settings.Default.ClinicAETitle;
            ClinicUsernameTextBox.Text = Properties.Settings.Default.ClinicUsername;
            ClinicPasswordTextBox.Text = Properties.Settings.Default.ClinicPassword;

            //CloudAETitleTextBox.Text = Properties.Settings.Default.CloudAETitle;
            //CloudHostTextBox.Text = Properties.Settings.Default.CloudHost;
            //CloudPortTextBox.Text = Properties.Settings.Default.CloudPort;

            timer.Start();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Show a confirmation dialog before closing
                //DialogResult result = MessageBox.Show("Are you sure you want to close the application?", "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // If the user confirms, close all open forms, including MainForm
                //if (result != DialogResult.Yes)
                //{
                //    e.Cancel = true;

                //}
                e.Cancel = true;
                Hide();
            }
        }

        private async void TestConnectionButton_Click(object sender, EventArgs e)
        {
            progressBar.Visible = true;
            MessageLabel.Text = "";

            progressBar.Value = 0;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    progressBar.Value = 10;
                    // Report progress during the API call
                    httpClient.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.Add("X-Progress-ID", "unique_id");

                    // Set the base URL of your API
                    string apiUrl = Properties.Settings.Default.HostAddress + "/auth/login";

                    var credentials = new Credentials
                    {
                        Username = ClinicUsernameTextBox.Text.Trim(),
                        Password = ClinicPasswordTextBox.Text.Trim()
                    };
                    // Serialize the credentials to JSON format
                    string jsonData = JsonConvert.SerializeObject(credentials);

                    // Create a StringContent object with JSON data and specify the content type
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    progressBar.Value = 20;
                    // Send the POST request to the Login API and await the response
                    HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);
                    progressBar.Value = 30;

                    // Read and handle the response
                    if (response.IsSuccessStatusCode)
                    {
                        // Request was successful
                        string responseContent = await response.Content.ReadAsStringAsync();
                        CurrentStatus = UploaderStatuses.ClinicConnected;
                        Properties.Settings.Default.ClinicUsername = ClinicUsernameTextBox.Text;
                        Properties.Settings.Default.ClinicPassword = ClinicPasswordTextBox.Text;
                        Properties.Settings.Default.ClinicAETitle = ClinicAETitleTextBox.Text;
                        Properties.Settings.Default.Save();
                        progressBar.Value = 100;
                        MessageBox.Show("Connected Successfully!");
                        TestConnectionButton.Text = "Connected";
                        LogMessage("Connected Successfully!");
                        GetMore = true;
                    }
                    else
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        CurrentStatus = UploaderStatuses.NotConnected;
                        LogError("Invalid User or Password!" + ClinicUsernameTextBox.Text + " & " +
                                 ClinicPasswordTextBox.Text);
                        MessageLabel.Text = "Invalid User or Password!";
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
                SendButton.Enabled = false;
                CurrentStatus = UploaderStatuses.NotConnected;
            }
            finally
            {
                progressBar.Visible = false;
                SendButton.Enabled = true;
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            sendTimer.Start();
            CanSend = true;
            StopButton.Enabled = true;
            SendButton.Enabled = false;
            SendButton.Text = "Sending";
        }

        public async Task<DicomClient> SendRequest(string[] files)
        {
            CalculateAllFilesCount(Properties.Settings.Default.DestinationDirectory, ".dcm", ".dicom");
            var movedSuccessfully = true;

            string callingAE = ClinicAETitleTextBox.Text.Trim();
            DicomClient client = new(CloudHost, CloudPort, false, callingAE, CloudAETitle);
            client.NegotiateAsyncOps();

            List<Task> requestQueueTasks = new();
            LogMessage("Start to sending " + files.Count() + " Dicom files...");
            try
            {
                foreach (var item in files)
                {
                    string dicomFile = Path.Combine(Properties.Settings.Default.DestinationDirectory, item);
                    if (!File.Exists(dicomFile))
                        throw new FileNotFoundException($"Dicom file in {dicomFile} was not found");

                    Dicom.Network.DicomCStoreRequest request = new(dicomFile);
                    request.OnResponseReceived = (req, response) =>
                    {
                        if (response.Status.State != Dicom.Network.DicomState.Success)
                        {
                            movedSuccessfully = false;
                        }
                        else
                        {
                            LogMessage("Sending successfully: " + item);
                        }
                    };
                    requestQueueTasks.Add(client.AddRequestAsync(request));
                }

                await Task.WhenAll(requestQueueTasks);
                await client.SendAsync();
                ChangeDoneRemainCount(Properties.Settings.Default.SentFilesFolderName, ".dcm", ".dicom");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                LogError(ex.Message + " - " + ex.StackTrace);
                throw ex;
            }
            finally
            {
            }

            if (movedSuccessfully == false) throw new Dicom.Network.DicomNetworkException("Failed to send DICOMs");
            return client;
        }

        private string GetLogFilePath()
        {
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            string logFileName = Path.Combine(logFolderPath, LogFilePrefix + currentDate + ".txt");
            if (!File.Exists(logFileName))
            {
                using (FileStream fs = File.Create(logFileName))
                {
                    // You can write initial content to the file if needed
                    // For example, writing a header or some default content
                    string initialContent =
                        "Log file created on " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\n";
                    byte[] initialContentBytes = System.Text.Encoding.UTF8.GetBytes(initialContent);
                    fs.Write(initialContentBytes, 0, initialContentBytes.Length);
                }
            }

            return logFileName;
        }

        private void LogError(string errorMessage)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(GetLogFilePath(), true))
                {
                    writer.WriteLine($"[Error - {DateTime.Now}] \n \t  {errorMessage}  \n \n ");
                }
            }
            catch (Exception)
            {
                // If an error occurs while writing to the log file, ignore it to prevent an infinite loop.
            }
        }

        private void LogMessage(string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(GetLogFilePath(), true))
                {
                    writer.WriteLine($"[{DateTime.Now}] \n \t {message} \n \n ");
                }
            }
            catch (Exception)
            {
                // If an error occurs while writing to the log file, ignore it to prevent an infinite loop.
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            SendButton.Enabled = true;
            StopButton.Enabled = false;
            SendButton.Text = "Start Sending";
            sendTimer.Stop();
        }

        private void LogDirectoryBrwoserButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            DialogResult result = folderBrowser.ShowDialog();
            if (result == DialogResult.OK)
            {
                logFolderPath = folderBrowser.SelectedPath;
                LogDirectoryLabel.Text = logFolderPath;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide(); // Hide the form when minimized
            }
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SettingGroupBox_Enter(object sender, EventArgs e)
        {
        }
    }

    public class Credentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public enum UploaderStatuses
    {
        NotStarted = 0,
        ClinicConnected = 1,
        CloudConnected = 2,
        NotConnected = 3
    }
}