using FileFilter.Filters;
using FileFilter.Implementation;
using FileFilter.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FileFilter.Tests
{
    public class FilterProviderTest
    {
        [Fact]
        public void OneLine()
        {
            var target = CreateEngine();

            var input = "Alice was beginning to ;get 'very' tired of 'smth' wondfrl";            
            
            var expected = "  beginning  ; 'very'   '' wondfrl";
            var result = target.FilterData((new List<string> { input }).ToArray());

            var resultLine = string.Join("", result);

            Assert.Equal(expected, resultLine);
        }

        [Fact]
        public void TwoLines()
        {
            var target = CreateEngine();

            var input1 = "Alice was beginning to ;get 'very' tired of 'smth' wondfrl";
            var input2 = " bb tttt micro! ###";

            var expected1 = "  beginning  ; 'very'   '' wondfrl";
            var expected2 = "   micro! ###";
            
            var result = target.FilterData((new List<string> { input1, input2 }).ToArray());            

            Assert.Equal(expected1, result[0]);
            Assert.Equal(expected2, result[1]);
        }

        private FilterProvider CreateEngine()
        {
            var filterList = new List<IFilter>()
            {
                new FilterMiddleVowel(),
                new FilterLessThanThree(),
                new FilterContainingT()
            };

            return new FilterProvider(filterList);
        }
    }
}
