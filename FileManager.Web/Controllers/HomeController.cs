using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileManager.Web.Models;
using FileManager.Web.ServiceClients;

namespace FileManager.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly FilesServiceClient _filesServiceClient;

        public HomeController()
        {
            _filesServiceClient = new FilesServiceClient();
        }

        public ActionResult Index(string ext = null)
        {
            ViewBag.Ext = ext;
            ViewBag.Files = _filesServiceClient.GetAllFiles(ext);
            ViewBag.FileExtensions = _filesServiceClient.GetAllExtensions();
            return View();
        }
        [HttpPost]
        public ActionResult AddFile(HttpPostedFileBase file)
        {
            var status = _filesServiceClient.AddFile(file);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteFile(int fileId)
        {
            var status = _filesServiceClient.DeleteFile(fileId);
            return RedirectToAction("Index");
        }
    }
}