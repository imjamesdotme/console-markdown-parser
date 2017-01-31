using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console_markdown_parser
{
    class FileManagement
    {
        // Reading & writing files.

        public static string readFile(string filePath)
        {
            string result = "";

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    result += sr.ReadLine() + "\\n";
                }
                sr.Close();
            }

            return result;
        }

        public void writeFile(string fileContents, string finalFilePath)
        {

            using (StreamWriter sw = new StreamWriter(finalFilePath))
            {
                sw.WriteLine(fileContents);
                sw.Close();
                Console.WriteLine("Your markdown has been converted to HTML sucessfully!");
            }

        }
    }
}
