using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using FileManager.Web.Models;

namespace FileManager.Web.ServiceClients
{
    public class FilesServiceClient : ServiceClientBase
    {
        public List<FileModel> GetAllFiles(string ext = null)
        {
            var response = ServiceClient.GetAsync("files?ext=" + ext).Result;
            var result = response.Content.ReadAsAsync<List<FileModel>>().Result;
            return result;
        }

        public bool AddFile(HttpPostedFileBase file)
        {
            using (var client = new HttpClient())
            {
                using (var content = new MultipartFormDataContent())
                {
                    byte[] Bytes = new byte[file.InputStream.Length + 1];
                    file.InputStream.Read(Bytes, 0, Bytes.Length);
                    var fileContent = new ByteArrayContent(Bytes);
                    fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment") { FileName = file.FileName };
                    content.Add(fileContent);
                    var requestUri = "http://localhost:56754/api/files";
                    var result = client.PostAsync(requestUri, content).Result;
                    return result.StatusCode == System.Net.HttpStatusCode.Created;

                }
            }
        }

        //public bool AddFile(HttpPostedFileBase postedFile)
        //{
        //    using (var content = new MultipartFormDataContent())
        //    {
        //        byte[] Bytes = new byte[postedFile.InputStream.Length + 1];
        //        postedFile.InputStream.Read(Bytes, 0, Bytes.Length);
        //        var fileContent = new ByteArrayContent(Bytes);
        //        fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment") { FileName = postedFile.FileName };
        //        content.Add(fileContent);

        //        var response = ServiceClient.PostAsJsonAsync("files", content).Result;
        //        var result = response.Content.ReadAsAsync<bool>().Result;
        //        return result;
        //    }
        //}

        public bool DeleteFile(int fileId)
        {
            var response = ServiceClient.DeleteAsync("files?fileId=" + fileId).Result;
            var result = response.Content.ReadAsAsync<bool>().Result;
            return result;
        }

        public List<string> GetAllExtensions()
        {
            var response = ServiceClient.GetAsync("file-extensions").Result;
            var result = response.Content.ReadAsAsync<List<string>>().Result;
            return result;
        }
    }
}