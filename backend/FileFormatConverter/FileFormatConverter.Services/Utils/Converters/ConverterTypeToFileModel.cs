using FileFormatConverter.Services.Interfaces.Business.Models.Enums;

namespace FileFormatConverter.Services.Utils.Converters
{
    public static class ConverterTypeToFileModel
    {
        public static FileFormat ConvertToOriginalFileFormat(this ConverterType converterType)
        {
            switch (converterType)
            {
                case ConverterType.HTML_TO_PDF:
                    return FileFormat.HTML;
                default:
                    return FileFormat.UNKNOWN;
            }
        }

        public static FileFormat ConvertToTargetFileFormat(this ConverterType converterType)
        {
            switch (converterType)
            {
                case ConverterType.HTML_TO_PDF:
                    return FileFormat.PDF;
                default:
                    return FileFormat.UNKNOWN;
            }
        }
    }
}
