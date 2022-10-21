using FileFormatConverter.Services.Interfaces.Business.Models.Enums;
using System;

namespace FileFormatConverter.Services.Interfaces.Business.Models.Input
{
    public class InputFileInfo
    {
        public Guid Id { get; set; }
        public string FilePath { get; set; }
        public string FileHash { get; set; }
        public FileFormat FileFormat { get; set; }
        public ConverterType ConverterType { get; set; }
        public string FileName { get; set; }
    }
}
