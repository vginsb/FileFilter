using System;
using System.Collections.Generic;
using System.Text;

namespace FileFilter.Implementation
{
    public static class FilterConstants
    {
        // HashSet is being used because is't most performant structure for our goals
        public static HashSet<string> Vowels = new HashSet<string> { "a", "e", "i", "o", "u" };

        // list not full but enough for our test
        public static string[] WordDelimiters = new string[] 
            { " ", ",", "?", "/", @"\", "'", ".", ",",
            "\"", 
            "!", "?", ":", "(", ")", ";",
            "+", "-", "="}; 
    }
}


