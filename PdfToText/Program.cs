using AzureSearchDocumentClassiferLib;
using System;
using System.IO;

namespace PdfToText
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: PdtToText <FILENAME>");
                return;
            }

            string filePath = args[0];
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File {0} does not exist",filePath);
                return;
            }

            FileStream fs = new FileStream(filePath, FileMode.Open);
            byte[] fileBytes = PdfHelper.ReadFully(fs);
            string content = PdfHelper.GetTextFromPdfBytes(fileBytes);

            Console.WriteLine(content);

            File.WriteAllText(filePath + ".txt", content);

        }
    }
}
