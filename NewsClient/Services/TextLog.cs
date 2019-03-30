using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsClient.Services
{
    public static class TextLog
    {
        private static string _fileName= "log.txt";

        public static void LogText(string text)
        {
            string docPath = Directory.GetCurrentDirectory();
            try
            {
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, _fileName), true))
                {
                    outputFile.WriteLine(text);
                }
            }
            catch { }
        }
    }
}
