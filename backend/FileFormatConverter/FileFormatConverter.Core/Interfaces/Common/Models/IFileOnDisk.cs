namespace FileFormatConverter.Core.Interfaces.Common.Models
{
    public interface IFileOnDisk
    {   
        public string FilePath { get; set; }
        public string FileName { get; set; }
    }
}
