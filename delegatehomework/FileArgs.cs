using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegatehomework
{
    // Event arguments class inheriting from EventArgs
    public class FileArgs : EventArgs
    {
        public string FileName { get; }
        public bool Cancel { get; set; } // Allows you to cancel the bypass

        public FileArgs(string fileName)
        {
            FileName = fileName;
            Cancel = false;
        }
    }
}
