using FileFormatConverter.Services.Interfaces.Business.Models.Enums;
using FileFormatConverter.Services.Interfaces.Business.Models.Output;
using System.Threading.Tasks;

namespace FileFormatConverter.Services.Interfaces.Business.Interfaces
{
    public interface IFileConverter
    {
        ConverterType ConverterType { get; }

        Task<OutputFileInfo> Convert(string originFilePath);
    }
}
