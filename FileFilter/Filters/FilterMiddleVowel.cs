using FileFilter.Implementation;
using FileFilter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileFilter.Filters
{
    public class FilterMiddleVowel : IFilter
    {
        public int Order => 30;


        public void ProcessLine(List<string> words)
        {
            if (words == null) return;

            words.RemoveAll(x => 
                    !FilterConstants.WordDelimiters.Contains(x) 
                    && 
                    HasVowel(x));
        }

        // as I understood the task, I should filter out 
        // words if one or BOTH middle letters are vowels
        // if one is vowel, and another is not, then I keep the word
        // If this is wrong, I can easily fix it.
        private bool IsInVowelList(string letters)
        {
            switch (letters?.Length ?? 0)
            {
                case 1:
                    return FilterConstants.Vowels.Contains(letters, StringComparer.InvariantCultureIgnoreCase);
                case 2:
                    return FilterConstants.Vowels.Contains(letters[0].ToString(), StringComparer.InvariantCultureIgnoreCase)
                            &&
                            FilterConstants.Vowels.Contains(letters[1].ToString(), StringComparer.InvariantCultureIgnoreCase);
                default:
                    throw new ArgumentException("input word should have only 1 or 2 characters");
            }
        }

        private bool HasVowel(string word)
        {
            if (string.IsNullOrWhiteSpace(word)) return false;            

            if (word.Length < 3) return IsInVowelList(word);

            var isOddLength = (word.Length % 2 == 0);

            var middle = isOddLength
                ? word.Substring(word.Length / 2 - 1, 2)
                : word.Substring((int)(word.Length / 2), 1);

            return IsInVowelList(middle);
        }
    }
}
