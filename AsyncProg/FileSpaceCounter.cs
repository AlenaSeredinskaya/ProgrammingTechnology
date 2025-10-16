namespace AsyncProg
{
    public class FileSpaceCounter
    {
        /// <summary>
        /// Asynchronous method for counting spaces in files
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="readWholeFile"></param>
        /// <returns></returns>
        public async Task<ProcessingResult> CountSpacesInFilesAsync(string folderPath, bool readWholeFile = true)
        {
            // Get all files in the folder
            string[] files = Directory.GetFiles(folderPath, "*.txt");

            ProcessingResult result = new ProcessingResult();

            if (files.Length == 0)
            {
                Console.WriteLine("В папке нет файлов для обработки.");
                return result; 
            }

            long totalSpaces = 0;

            // Create tasks for each file
            var fileTasks = new List<Task>();

            foreach (string file in files)
            {
                fileTasks.Add(Task.Run(() =>
                {
                    try
                    {
                        if (readWholeFile)
                        {
                            // Scenario 1: Read the entire file and count spaces
                            string content = File.ReadAllText(file);
                         
                            int spacesInFile = 0;
                            foreach (char c in content)
                            {
                                if (c == ' ')
                                {
                                    spacesInFile++;
                                }
                            }
                            Interlocked.Add(ref totalSpaces, spacesInFile);
                        }
                        else
                        {
                            // Scenario 2: Read line by line and run a Task for each line
                            var lines = File.ReadLines(file).ToList();

                            // operations can be executed in parallel in different threades
                            Parallel.ForEach(lines, line =>
                            {
                                int spacesInLine = 0;
                                foreach (char c in line)
                                {
                                    if (c == ' ')
                                    {
                                        spacesInLine++;
                                    }
                                }
                                Interlocked.Add(ref totalSpaces, spacesInLine);
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка при обработке файла {file}: {ex.Message}");
                    }
                }));
            }

            // Wait for all tasks to complete
            await Task.WhenAll(fileTasks);

            result.TotalSpaces = totalSpaces;
            return result;
        }
    }
}
