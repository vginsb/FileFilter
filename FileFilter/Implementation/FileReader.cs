using FileFilter.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileFilter.Implementation
{
    public class FileReader : IFileReader
    {
        public string[] ReadFileData(string fileName)
        {
            try
            {
                if (!File.Exists(fileName))
                {
                    Console.WriteLine($"File {fileName} doesn't exist");
                    return null;
                }

                return File.ReadAllLines(fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error on reading the file", e);
                return null;
            }
        }
    }
}
