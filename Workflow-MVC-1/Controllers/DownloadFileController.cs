using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Workflow_MVC_1.Models;

namespace Workflow_MVC_1.Controllers
{
    [Authorize]
    public class DownloadFileController : Controller
    {

        public ActionResult Index()
        {
            List<DownloadFile> ObjFiles = new List<DownloadFile>();
            foreach (string strfile in Directory.GetFiles(Server.MapPath("~/UploadedFiles")))
            {
                FileInfo fi = new FileInfo(strfile);
                DownloadFile obj = new DownloadFile();
                obj.File = fi.Name;
                obj.Size = fi.Length;
                obj.Type = GetFileTypeByExtension(fi.Extension);
                obj.Url = string.Format(@HttpContext.Request.Url.Host + ":" + @HttpContext.Request.Url.Port + "/UploadedFiles/" + fi.Name);
                //@Url.Action("Information", "Admin");

                ObjFiles.Add(obj);
            }

            return View(ObjFiles);
        }

        public FileResult Download(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/UploadedFiles"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        private string GetFileTypeByExtension(string fileExtension)
        {
            switch (fileExtension.ToLower())
            {
                case ".docx":
                case ".doc":
                    return "Microsoft Word Document";
                case ".xlsx":
                case ".xls":
                    return "Microsoft Excel Document";
                case ".txt":
                    return "Text Document";
                case ".jpg":
                case ".png":
                    return "Image";
                case ".pdf":
                    return "Pdf";
                default:
                    return "Unknown";
            }
        }
        [HttpPost]
        public ActionResult Index(DownloadFile doc)
        {
            foreach (var file in doc.files)
            {

                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(Server.MapPath("~/UploadedFiles"), fileName);
                    file.SaveAs(filePath);
                }
            }
            TempData["Message"] = "files uploaded successfully";
            return RedirectToAction("Index");
        }
    }
}
