using FileFilter.Filters;
using FileFilter.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace FileFilter.Tests.Filters
{
    public class FilterLessThanThreeTests
    {
        [Fact]
        public void Input_Null()
        {
            var target = new FilterLessThanThree();

            target.ProcessLine(null);

            Assert.True(1 == 1, "no exception should happen");
        }

        [Theory]
        [InlineData("a,create,n,      ,788,by", "create,788")]
        // there can be more test cases, but no time for it
        public void Input_DifferentLines(string inputLine, string expectedResult)
        {
            var target = new FilterLessThanThree();

            var input = inputLine.Split(",").ToList();
            
            target.ProcessLine(input);

            var result = string.Join(",", input);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Input_WithDelimiters()
        {
            var target = new FilterLessThanThree();

            var input = new List<string>()
            {
                "A", ";", "mexico", ".", "some", "z", "!"
            };

            var expectedResult = ";,mexico,.,some,!";

            target.ProcessLine(input);

            var result = string.Join(",", input);

            Assert.Equal(expectedResult, result);
        }
    }
}
