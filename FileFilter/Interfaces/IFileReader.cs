using System;
using System.Collections.Generic;
using System.Text;

namespace FileFilter.Interfaces
{
    public interface IFileReader
    {
        string[] ReadFileData(string fileName);
    }
}
