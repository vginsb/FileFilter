using FileFilter.Filters;
using FileFilter.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace FileFilter.Tests.Filters
{
    public class FilterMiddleVowelTests

    {
        [Fact]
        public void Input_Null()
        {
            var target = new FilterMiddleVowel();

            target.ProcessLine(null);

            Assert.True(1 == 1, "no exception should happen");
        }

        [Theory]
        [InlineData("a,bb,z,dd,oo", "bb,z,dd")]
        [InlineData("currently,cat,clean,smooth,what,the,tea,rather", "what,the,rather")]
        public void Input_DifferentLines(string inputLine, string expectedResult)
        {
            var target = new FilterMiddleVowel();

            var input = inputLine.Split(",").ToList();
            
            target.ProcessLine(input);

            var result = string.Join(",", input);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Input_WithDelimiters()
        {
            var target = new FilterMiddleVowel();

            var input = new List<string>()
            {
                "currently", ";", "mexico", ".","=", "soe", "z", "!"
            };

            var expectedResult = ";,mexico,.,=,z,!";

            target.ProcessLine(input);

            var result = string.Join(",", input);

            Assert.Equal(expectedResult, result);
        }
    }
}
