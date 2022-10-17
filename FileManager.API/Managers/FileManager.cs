using FileManager.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using FileManager.API.Models;

namespace FileManager.API.Managers
{
    public class FileManager
    {
        private readonly FileManagerDbEntities _db = new FileManagerDbEntities();
        private readonly string _logFilePath;
        public FileManager()
        {
            _logFilePath = HostingEnvironment.MapPath("~/Logs/") + "logfile.txt";
        }

        public List<FileDto> GetAllFiles(string ext = null)
        {
            try
            {
                var files = !string.IsNullOrEmpty(ext) ? _db.Files.Where(a => a.FileExtension == ext).ToList() : _db.Files.ToList();
                var retDto = new List<FileDto>();
                foreach (var file in files)
                {
                    retDto.Add(new FileDto
                    {
                        FileId = file.FileId,
                        FileName = file.FileName,
                        FilePath = file.FilePath,
                        FileExtension = file.FileExtension,
                    });
                }

                return retDto;
            }
            catch { }
            return null;
        }

        public bool AddFile(HttpPostedFile file)
        {
            try
            {

                // add file to folder
                string path = HostingEnvironment.MapPath("~/Files/");
                file.SaveAs(path + file.FileName);

                // add file to db
                var fileExtension = file.FileName.Split('.').LastOrDefault();
                var fileObj = new File
                {
                    FileName = file.FileName,
                    FilePath = "~/Files/" + file.FileName,
                    FileExtension = !string.IsNullOrEmpty(fileExtension) ? "." + fileExtension : null
                };
                _db.Files.Add(fileObj);
                _db.SaveChanges();

                LogMessage("AddFile", "Success: File added");

                return fileObj.FileId > 0;
            }
            catch (Exception ex)
            {
                LogMessage("AddFile", "Exception: " + ex.Message);
                return false;
            }
        }

        public bool DeleteFile(int fileId)
        {
            try
            {
                var file = _db.Files.Find(fileId);

                // delete file from folder
                string path = HostingEnvironment.MapPath("~/Files/") + file.FileName;
                System.IO.File.Delete(path);

                // delete file from db
                _db.Files.Remove(file);
                _db.SaveChanges();

                LogMessage("DeleteFile", "Success: File deleted");

                return true;
            }
            catch (Exception ex)
            {
                LogMessage("DeleteFile", "Exception: " + ex.Message);
                return false;
            }
            ;
        }
        public List<string> GetAllExtensions()
        {
            try
            {
                return _db.Files.Select(a => a.FileExtension).Distinct().ToList();
            }
            catch { }
            return null;
        }

        private void LogMessage(string method, string message)
        {
            System.IO.File.AppendAllText(_logFilePath, "\n\n=============================\n" +
                                                       "Timestamp:" + DateTime.Now +
                                                       "Method: " + method +
                                                       "Message: " + message +
                                                       "\n=============================\n\n");
        }
    }
}