using FileFormatConverter.Services.Interfaces.Business.Models.Enums;

namespace FileFormatConverter.Services.Utils.Converters
{
    public static class ConverterTypeValidator
    {
        public static bool IsFileValid(string fileName, ConverterType converterType)
        {
            var validFileFormat = converterType.ConvertToOriginalFileFormat();
            var validFileFormatString = validFileFormat.ConvertToString();

            if (!string.IsNullOrEmpty(validFileFormatString))
            {
                return false;
            }

            if (fileName.EndsWith(validFileFormatString))
            {
                return true;
            }

            return false;
        }
    }
}
