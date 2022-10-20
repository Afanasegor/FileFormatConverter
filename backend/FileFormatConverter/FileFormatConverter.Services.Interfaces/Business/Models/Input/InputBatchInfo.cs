using FileFormatConverter.Services.Interfaces.Business.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileFormatConverter.Services.Interfaces.Business.Models.Input
{
    public class InputBatchInfo
    {
        public string OriginPath { get; set; }
        public FileFormat OriginFileFormat { get; set; }

        public string TargetPath { get; set; }
        public FileFormat TargetFileFormat { get; set; }
    }
}
