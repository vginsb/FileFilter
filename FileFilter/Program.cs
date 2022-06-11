using FileFilter.Filters;
using FileFilter.Implementation;
using FileFilter.Interfaces;
using System;
using System.Collections.Generic;

namespace FileFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");

            if (args.Length == 0)
            {
                Console.WriteLine("Input file is not provided");
            }
            else
            {
                var engine = Bootstrap();

                engine.ProcessFile(args[0]);
            }

            Console.WriteLine("Finished");
            Console.ReadLine();
        }

        private static FilteringEngine Bootstrap()
        {
            var reader = new FileReader();           

            var filter = new FilterProvider();

            // this composition should be done with ioc container like Unity
            // but it's overkill in this particular case
            return new FilteringEngine(reader, filter);
        }
    }
}
