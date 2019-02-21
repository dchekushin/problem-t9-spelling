using System;
using System.Collections.Generic;
using System.Linq;

namespace ProblemT9Spelling
{
    /// <summary> Translates characters to keypresses </summary>
    public static class MessageToKeyTranslator
    {
        private static readonly string[] Keypad = {
            " ",
            "",
            "abc",
            "def",
            "ghi",
            "jkl",
            "mno",
            "pqrs",
            "tuv",
            "wxyz"
        };

        /// <summary> Translate single line </summary>
        public static string Translate(string input)
        {
            var prevKey = '\0';
            var result = string.Empty;
            
            foreach (var current in input)
            {
                var currKey = Keypad
                    .Select((key, i) => new {i, key})
                    .Single(_ => _.key.IndexOf(current) > -1).i;

                var currKeyChar = currKey.ToString()[0];
                
                if (prevKey == currKeyChar)
                    result += ' ';
                
                result += new string(currKeyChar, Keypad[currKey].IndexOf(current) + 1);
                prevKey = currKeyChar;
            }

            return result;
        }
        
        /// <summary> Translate all lines </summary>
        public static string TranslateDateSet(string inputDataSet)
        {
            if (string.IsNullOrEmpty(inputDataSet))
                throw new ArgumentNullException(nameof(inputDataSet));

            var caseResults = new List<string>();
            
            var lines = inputDataSet.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
            var numberOfCases = int.Parse(lines[0]);
            
            for (var lineIndex = 1; lineIndex <= numberOfCases; lineIndex++)
            {
                var str = Translate(lines[lineIndex]);
                caseResults.Add($"Case #{lineIndex}: {str}" );
            }

            return string.Join(Environment.NewLine, caseResults);
        }
    }
}