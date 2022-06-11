using FileFilter.Implementation;
using FileFilter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileFilter.Filters
{
    public class FilterLessThanThree : IFilter
    {
        public int Order => 10;

        public void ProcessLine(List<string> words)
        {
            if (words == null) return;

            words.RemoveAll(x =>
                !FilterConstants.WordDelimiters.Contains(x)
                &&
                (string.IsNullOrWhiteSpace(x) || x.Length < 3));
        }
    }
}
