using FileFormatConverter.Services.Interfaces.Business.Models.Enums;
using FileFormatConverter.Services.Interfaces.Business.Models.Output;
using System;
using System.Threading.Tasks;

namespace FileFormatConverter.Services.Interfaces.Business.Interfaces
{
    public interface IFileService
    {
        Task<OutputFileInfo> GetById(Guid id);
        Task<OutputFileInfo> CreateFile(byte[] blob, string path, string fileName, FileFormat fileFormat);

        //Task<OutputFileInfo> CreateFile(byte[] blob, FileFormat fileFormat);
        Task<OutputFileInfo> CreateRecordOfFile(string fullPath, FileFormat fileFormat);

    }
}
