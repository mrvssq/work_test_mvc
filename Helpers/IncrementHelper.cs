using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace work_test_mvc.Helpers
{
    public static class IncrementHelper
    {
        public static string IncrementString(string text_in, int increment)
        {
            var segmentList = SplitSegmentsString(text_in);
            var resultString = "";

            foreach (var segment in segmentList)
            {
                var success = Int32.TryParse(segment, out int result);
                if (success)
                {
                    result += increment;
                    resultString += result.ToString()[..segment.Length];
                }
                else
                    resultString += segment;
                
            }

            return resultString;
        }

        private static string[] SplitSegmentsString(string text_in)
        {
            string pattern = @"(?<=\d)(?!\d)|(?<!\d)(?=\d)";
            var matches = Regex.Replace(text_in, pattern, "\n");
            
            var segments = matches.Split("\n");

            return segments;
        }
    }
}
