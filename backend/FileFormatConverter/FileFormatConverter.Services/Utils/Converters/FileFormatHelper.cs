using FileFormatConverter.Services.Interfaces.Business.Models.Enums;
using FileFormatConverter.Services.Interfaces.Business.Models.Input;

namespace FileFormatConverter.Services.Utils.Converters
{
    public static class FileFormatHelper
    {
        public static string ConvertToString(this FileFormat fileFormat)
        {
            switch (fileFormat)
            {
                case FileFormat.HTML:
                    return ".html";
                case FileFormat.PDF:
                    return ".pdf";
                default:
                    return string.Empty;
            }
        }

        public static ConverterType GetConverterType(InputBatchInfo inputBatchInfo)
        {
            if (inputBatchInfo.OriginFileFormat == FileFormat.HTML)
            {
                if (inputBatchInfo.TargetFileFormat == FileFormat.PDF)
                {
                    return ConverterType.HTML_TO_PDF;
                }
            }

            return ConverterType.UNKNOWN;
        }
    }
}
