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

            string filePath = "";

            // Globals for inputted file extension.
            int dotLocation = 0;
            string fileExtension = "";
            Console.WriteLine(fileExtension);

            bool fileTypeCheck = false;

            // Check inputted file extension is valid.
            while (!fileTypeCheck)
            {
                Console.WriteLine("Please provide a file path (you can drag & drop):");
                filePath = Console.ReadLine();

                // If drag & dropped file path contains a space, command prompt will wrap the path in quotes, these need to be removed to avoid an exception being thrown.
                if (filePath.IndexOf("\"") == 0)
                {
                    filePath = filePath.Substring(1, filePath.Length - 2);
                }

                // Check inputting file extension type.
                dotLocation = filePath.LastIndexOf('.');
                fileExtension = filePath.Substring(dotLocation + 1);
  
                try
                {
                    switch (fileExtension)
                    {
                        case "markdown":
                        case "md":
                        case "mdown":
                        case "mkdn":
                        case "mkd":
                        case "mdtext":
                        case "mdtxt":
                        case "text":
                        case "txt":
                        case "rmd":
                            fileTypeCheck = true;
                            break;
                        default:
                            fileTypeCheck = false;
                            Console.WriteLine("Invalid file type. Please try again!");
                            break;
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("Please try again.");
                }

            }
            
            // Replace valid file extension with .html
            string finalFilePath = filePath.Replace(fileExtension, "html");

            // Read markdown file.
            string fileContent = FileManagement.readFile(filePath);

            string markdown = Markdown.requestMarkdown(fileContent);

            FileManagement file = new FileManagement();
            file.writeFile(markdown, finalFilePath);

        }
    }
}


