using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GoogleCompiler
{
    class FileManager
    {
        private List<string> filePaths = new List<string>();

        public List<string> GetDocuments(string extension, string path, bool recursive)
        {
            var dir = new DirectoryInfo(path);

            if (recursive)
            {
                foreach (var dirs in dir.GetDirectories())
                {
                    GetDocuments(extension, dirs.FullName, true);
                }
            }

            foreach (var file in dir.GetFiles())
            {
                if (file.Extension == extension)
                    filePaths.Add(file.FullName);
            }

            return filePaths.OrderBy(f => f).ToList();
        }

        public void Clear()
        {
            filePaths.Clear();
        }
    }
}
