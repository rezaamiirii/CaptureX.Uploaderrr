//using Dicom.Imaging.Codec;
using Dicom.Imaging.Codec;
using FellowOakDicom;
using FellowOakDicom.Imaging.Codec;

namespace Convert
{
    public static class DicomConverter
    {
        public static bool ConvertToLEExplicit(string source, string destination)
		{
			try
			{

                var file = FellowOakDicom.DicomFile.Open(source);

                

                var newFile = file.Clone(FellowOakDicom.DicomTransferSyntax.ExplicitVRLittleEndian);

                newFile.Save(destination);
            }
			catch (System.Exception ex)
			{
				throw ex;
			}
            return true;
        }
    }
}
