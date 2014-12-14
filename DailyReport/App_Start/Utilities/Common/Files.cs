using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;


    public static partial class Puwu
    {
        public static class Files
        {
            public static string ReadTextsWithPath(string path)
            {
                if (!File.Exists(path)) { return null; }
                return File.ReadAllText(path);
            }

            public static void WriteTextsToPath(string path, string contents)
            {
                if (!File.Exists(path)) File.Create(path).Close();
                File.WriteAllText(path, contents);
            }
        }
    }

   
