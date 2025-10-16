using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegatehomework
{
    // A class that walks a directory of files and emits an event when each file is found.
    public class FileSearcher
    {
        private readonly string _startDirectory;

        public delegate void EventHandler<T>(object sender, T e) where T : EventArgs;

        public event EventHandler<FileArgs> FileFound;

        public FileSearcher(string startDirectory)
        {
            _startDirectory = startDirectory ?? throw new ArgumentNullException(nameof(startDirectory));
        }

        public void Search()
        {
            if (!Directory.Exists(_startDirectory))
            {
                Console.WriteLine($"Folder {_startDirectory} not found!");
                return;
            }

            Traverse(_startDirectory);
        }

        private bool Traverse(string directory)
        {
            foreach (var file in Directory.GetFiles(directory))
            {
                var args = new FileArgs(file);
                OnFileFound(args); // calling a method is the standard way to trigger events

                if (args.Cancel)
                {
                    Console.WriteLine("Search canceled.");
                    return false; // Stop traversing
                }
            }

            foreach (var subDir in Directory.GetDirectories(directory))
            {
                if (!Traverse(subDir))
                    return false; // Terminate on cancellation
            }

            return true; // Search completed without cancellation
        }

        protected virtual void OnFileFound(FileArgs e)
        {
            FileFound?.Invoke(this, e);
        }
    }
}

