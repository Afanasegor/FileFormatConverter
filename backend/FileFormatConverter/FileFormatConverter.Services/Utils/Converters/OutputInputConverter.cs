using FileFormatConverter.Services.Interfaces.Business.Models.Enums;
using FileFormatConverter.Services.Interfaces.Business.Models.Input;
using FileFormatConverter.Services.Interfaces.Business.Models.Output;

namespace FileFormatConverter.Services.Utils.Converters
{
    public static class OutputInputConverter
    {
        public static InputFileInfo ConvertToInputFileInfo(this OutputFileInfo outputFileInfo, FileFormat fileFormat, ConverterType converterType)
        {
            var result = new InputFileInfo()
            {
                Id = outputFileInfo.FileId,
                FilePath = outputFileInfo.FilePath,
                FileHash = outputFileInfo.FileHash,
                FileFormat = fileFormat,
                ConverterType = converterType
            };
            return result;
        }
    }
}
