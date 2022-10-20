namespace FileFormatConverter.Core.Interfaces.Common.Models
{
    public interface IFileBlob
    {
        public byte[] File { get; set; }
        public long FileLength { get; set; }
    }
}
