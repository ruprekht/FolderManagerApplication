using System;
using System.Diagnostics;
using System.IO;

namespace FolderManagerApplication.Helpers
{
    public static class FileCreationHelper
    {
        public static void TryCreateTextFile(string currentFolder, string name, string text)
        {
            name = ValidateFileExtension(name);
            try
            {
                if (!File.Exists(currentFolder + "\\" + name))
                {
                    File.WriteAllText(currentFolder + "\\" + name, text);
                }
                File.AppendAllText(currentFolder + "\\" + name, text);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private static string ValidateFileExtension(string name)
        {
            if (Path.GetExtension(name) != ".txt")
                return name + ".txt";
            return name;
        }
    }
}
