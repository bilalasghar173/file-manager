using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using FileManager.API.Data;
using FileManager.API.Models;

namespace FileManager.API.Controllers
{
    public class FilesController : ApiController
    {
        private readonly Managers.FileManager _fileManager;

        public FilesController()
        {
            _fileManager = new Managers.FileManager();
        }

        public List<FileDto> GetAllFiles([FromUri] string ext = null)
        {
            return _fileManager.GetAllFiles(ext);
        }
        public bool AddFile()
        {
            var file = HttpContext.Current.Request.Files[0];
            return _fileManager.AddFile(file);
        }

        [HttpDelete]
        public bool DeleteFile([FromUri] int fileId)
        {
            return _fileManager.DeleteFile(fileId);
        }

        [Route("~/api/file-extensions")]
        public List<string> GetAllExtensions()
        {
            return _fileManager.GetAllExtensions();
        }
    }
}
