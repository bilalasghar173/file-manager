using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileManager.API.Models
{
    public class FileDto
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int FileTypeId { get; set; }

        public string FileExtension { get; set; }
    }
}