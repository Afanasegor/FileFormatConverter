using System;

namespace FileFormatConverter.Services.Interfaces.Business.Models.Output
{
    public class OutputFileInfo
    {
        public Guid FileId { get; set; }
        public string FilePath { get; set; }
        public string FileHash { get; set; }
    }
}
