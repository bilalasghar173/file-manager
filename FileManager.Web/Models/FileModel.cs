using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileManager.Web.Models
{
    public class FileModel
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileExtension { get; set; }

    }

}