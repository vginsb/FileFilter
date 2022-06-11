using System;
using System.Collections.Generic;
using System.Text;

namespace FileFilter.Interfaces
{
    public interface IFilter
    {
        // I need Order property to be able to run Filters in specified order
        // It can help with performance of the process
        int Order { get; }
        void ProcessLine(List<string> words);
    }
}
