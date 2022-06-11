using FileFilter.Filters;
using FileFilter.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace FileFilter.Tests.Filters
{
    public class FilterContainingTTests
    {
        [Fact]
        public void Input_Null()
        {
            var target = new FilterContainingT();

            target.ProcessLine(null);

            Assert.True(1 == 1, "no exception should happen");
        }

        [Theory]
        [InlineData("fix,t,  ,create,creaTe,tea,not,Else", "fix,  ,creaTe,Else")]
        // there can be more test cases, but no time for it
        public void Input_DifferentLines(string inputLine, string expectedResult)
        {
            var target = new FilterContainingT();

            var input = inputLine.Split(",").ToList();
            
            target.ProcessLine(input);

            var result = string.Join(",", input);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Input_WithDelimiters()
        {
            var target = new FilterContainingT();

            var input = new List<string>()
            {
                "At", ";", "mexico", ".",",", "some", "z", "!"
            };

            var expectedResult = ";,mexico,.,,,some,z,!";

            target.ProcessLine(input);

            var result = string.Join(",", input);

            Assert.Equal(expectedResult, result);
        }
    }
}
