using System;
using System.Collections.Generic;
using System.IO;

namespace delegatehomework
{  
    class Program
    {
        static void Main()
        {
            string path = "."; // Current directory
            // C:\\Users\\User\\Desktop\\технологии программирования\\ConsoleApp3

            var searcher = new FileSearcher(path);

            // Subscribe to the event
            searcher.FileFound += (sender, e) =>
            {
                Console.WriteLine($"File found: {e.FileName}");

                // Example of cancellation: if the file name contains "stop", abort the search
                if (e.FileName.Contains("stop", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Timeout on file with name '{e.FileName}'. Stop the search.");
                    e.Cancel = true;
                }
            };

            Console.WriteLine("Starting file search...");
            searcher.Search();

            // Get a list of files for the maximum search example
            var files = Directory.GetFiles(path);

            // Apply the expansion function: maximum file size
            var maxFile = files.GetMax(f => new FileInfo(f).Length);

            Console.WriteLine();
            if (maxFile != null)
                Console.WriteLine($"Largest file: {maxFile} — with size {new FileInfo(maxFile).Length} byte");
            else
                Console.WriteLine("No files found for analysis.");

        }
    }
}
