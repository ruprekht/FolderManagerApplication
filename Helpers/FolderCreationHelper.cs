using System;
using System.Diagnostics;
using System.IO;

namespace FolderManagerApplication.Helpers
{
    public static class FolderCreationHelper
    {
        public static void TryCreateFolder(string currentFolder, string name)
        {
            try
            {
                Directory.CreateDirectory(currentFolder + "\\" + name);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
