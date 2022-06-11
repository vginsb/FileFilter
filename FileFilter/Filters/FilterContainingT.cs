using FileFilter.Implementation;
using FileFilter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileFilter.Filters
{
    public class FilterContainingT : IFilter
    {
        public int Order => 20;

        // btw, it's not clear should I remove just words with 't' or with 'T' as well.
        // I'll go just lowercase.
        public void ProcessLine(List<string> words)
        {
            if (words == null) return;

            words.RemoveAll(x => !FilterConstants.WordDelimiters.Contains(x) && x != null && x.Contains('t'));
        }
    }
}
