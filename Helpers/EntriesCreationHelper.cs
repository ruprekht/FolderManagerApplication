using FolderManagerApplication.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace FolderManagerApplication.Helpers
{
    public static class EntriesCreationHelper
    {
        public static List<BaseEntry> GetEntriesInCurrentFolder(string path)
        {
            var entries = new List<BaseEntry>();

            if (Directory.GetParent(path) != null)
            {
                try
                {
                    var parent = Directory.GetParent(path);
                    entries.Add(new FolderEntry()
                    {
                        FullPath = Directory.GetParent(path).FullName,
                        Name = "..",
                        NavigationButton = "<Up>",
                        DateTime = GetDateTime(parent.FullName)
                    });
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

            try
            {
                foreach (var item in Directory.GetDirectories(path))
                {
                    entries.Add(new FolderEntry()
                    {
                        FullPath = item,
                        Name = GetFolderName(item),
                        NavigationButton = "<Folder>",
                        DateTime = GetDateTime(item)
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            try
            {
                foreach (var item in Directory.GetFiles(path))
                {
                    entries.Add(new FileEntry()
                    {
                        FullPath = item,
                        Name = GetName(item),
                        Extension = GetExtension(item),
                        Size = (int)new FileInfo(item).Length,
                        DateTime = GetDateTime(item)
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return entries;
        }

        private static string GetName(string path)
        {
            if (path.Contains('\\'))
                path = path.Substring(path.LastIndexOf('\\') + 1);
            if (Path.GetExtension(path) != "" && path.LastIndexOf('.') != 0)
                path = path.Replace(Path.GetExtension(path), string.Empty);
            return path;
        }

        private static string GetExtension(string path)
        {
            string extension = string.Empty;
            if (path.Contains('\\'))
                path = path.Substring(path.LastIndexOf('\\') + 1);
            if (Path.GetExtension(path) != "" && path.LastIndexOf('.') != 0)
                extension = Path.GetExtension(path).Substring(1);
            return extension;
        }

        private static string GetFolderName(string path)
        {
            if (path.Contains('\\'))
                path = path.Substring(path.LastIndexOf('\\') + 1);
            return path;
        }

        private static DateTime GetDateTime(string path)
        {
            return Directory.GetCreationTime(path);
        }
    }
}
