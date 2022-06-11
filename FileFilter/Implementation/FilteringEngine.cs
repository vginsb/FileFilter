using FileFilter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileFilter.Implementation
{
    public class FilteringEngine
    {
        private readonly IFileReader _fileReader;
        private readonly IFilterProvider _filterProvider;

        // we can stub IFileReader for unit tests
        public FilteringEngine(IFileReader fileReader, IFilterProvider filterProvider)
        {
            _fileReader = fileReader ?? throw new ArgumentNullException(nameof(fileReader));
            _filterProvider = filterProvider ?? throw new ArgumentNullException(nameof(filterProvider));
        }

        public void ProcessFile(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentNullException(nameof(fileName)); 

            var lines = _fileReader.ReadFileData(fileName);

            if (lines == null || !lines.Any())
            {
                Console.WriteLine("No lines to filter.");
                return;
            }

            var filtered = _filterProvider.FilterData(lines);            

            Console.WriteLine("---------------");

            filtered.ToList().ForEach(x => Console.WriteLine(x));

            Console.WriteLine("---------------");
        }
    }
}
