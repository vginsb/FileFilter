using FileFilter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FileFilter.Implementation
{
    public class FilterProvider : IFilterProvider
    {
        private List<IFilter> _filters;

        // this constructor is for custom loading
        public FilterProvider(IEnumerable<IFilter> filters)
        {
            SetFilters(filters);
        }

        // this constructor is for autoloading all available classes that implement IFilter interface
        public FilterProvider()
        {
            SetFilters(LoadAllFilters());
        }

        private void SetFilters(IEnumerable<IFilter> filters)
        {
            if (filters == null || !filters.Any())
            {
                throw new ArgumentException("Filters should be provided");
            }
            _filters = filters.OrderBy(x => x.Order).ToList();

            LoadAllFilters();
        }

        private List<IFilter> LoadAllFilters()
        {
            var list = new List<IFilter>();
            IEnumerable <Type> filters = AppDomain.CurrentDomain
                                        .GetAssemblies()
                                        .SelectMany(x => x.GetTypes())
                                        .Where(t => t.GetInterfaces().Contains(typeof(IFilter)))
                                        .ToList();
            
            foreach (Type tp in filters)
            {
                var instance = Activator.CreateInstance(tp);
                list.Add(instance as IFilter);
            }

            return list;
        }


        public string[] FilterData(string[] lines)
        {        

            if (lines == null || !lines.Any()) return lines;

            var resultList = new List<string>();

            foreach (var item in lines)
            {
                //var splitted = item.Split(FilterConstants.WordDelimiters, StringSplitOptions.RemoveEmptyEntries).ToList();
                var splitted = SplitWithKeepingDelimiters(item);

                foreach (var filter in _filters)
                {
                    filter.ProcessLine(splitted);
                }

                resultList.Add(string.Join(string.Empty, splitted));
            }

            return resultList.ToArray();
        }

        private List<string> SplitWithKeepingDelimiters(string line)
        {
            //var pattern = @"(?<=[XXX])".Replace("XXX", string.Join(string.Empty, FilterConstants.WordDelimiters));
            //string[] splitted = Regex.Split(line, pattern);

            //return splitted.ToList();

            var resultList = new List<string>();

            string buffer = string.Empty;

            if (!string.IsNullOrWhiteSpace(line))
            {
                
                foreach (var item in line.ToArray())
                {
                    var asStr = item.ToString();
                    if (FilterConstants.WordDelimiters.Contains(asStr))
                    {
                        if (buffer != string.Empty) resultList.Add(buffer);
                        buffer = "";
                        resultList.Add(asStr);
                        continue;
                    }

                    buffer += item;
                }
            }

            if (buffer != string.Empty) resultList.Add(buffer);

            return resultList;
        }
    }
}
