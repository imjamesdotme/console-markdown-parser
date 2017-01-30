using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace console_markdown_parser
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please provide a file path (you can drag & drop):");
            string filePath = Console.ReadLine();

            // Find the original directory path.
            string[] originalFilePath = filePath.Split('\\');
            string finalFilePath = "";
            string fileName = "";

            foreach (var directory in originalFilePath)
            {
                if (!directory.Contains(".md"))
                {
                    finalFilePath += directory + "\\";
                }
                else
                {
                    fileName = directory.Replace(".md", ".html");
                }
            }

            // Escape backslashes in the file path.
            filePath = filePath.Replace(@"\", @"\\");

            // Read markdown file.
            string fileContent = FileManagement.readFile(filePath);

            string markdown = Markdown.requestMarkdown(fileContent);

            FileManagement file = new FileManagement();
            file.writeFile(markdown, fileName);

        }
    }
}


