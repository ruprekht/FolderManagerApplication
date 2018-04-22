using FolderManagerApplication.Helpers;
using FolderManagerApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FolderManagerApplication.Controllers
{
    public class HomeController : Controller
    {
        private string startFolder = Environment.CurrentDirectory + "\\Sandbox";
        public IActionResult Index(string path)
        {
            if (path == null)
                if (TempData["path"] != null)
                    path = TempData["path"].ToString();
                else
                    path = startFolder;

            var entries = EntriesCreationHelper.GetEntriesInCurrentFolder(path);

            ViewBag.entries = entries;
            ViewBag.currentFolder = path;
            return View();
        }

        [HttpPost]
        public IActionResult CreateFolder(FolderEntry folder)
        {
            FolderCreationHelper.TryCreateFolder(folder.FullPath, folder.Name);
            TempData["path"] = folder.FullPath;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CreateTextFile(FileEntry file, string fileText)
        {
            FileCreationHelper.TryCreateTextFile(file.FullPath, file.Name, fileText);
            TempData["path"] = file.FullPath;
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return RedirectToAction("Index");
        }
    }
}
