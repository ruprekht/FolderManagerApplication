using System;

namespace FolderManagerApplication.Models
{
    public class BaseEntry
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public DateTime DateTime { get; set; }
        public string FullPath { get; set; }
    }
}
