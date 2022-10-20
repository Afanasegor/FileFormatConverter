using FileFormatConverter.Services.Interfaces.Business.Models.Enums;
using System;

namespace FileFormatConverter.Services.Interfaces.Business.Models.Output
{
    public class OutputBatchModel
    {
        public Guid Id { get; set; }
        public Guid OriginFileId { get; set; }
        public Guid TargetFileId { get; set; }
        public ConverterType ConverterType { get; set; }
        public ProcessStatus ProcessStatus { get; set; }
    }
}
