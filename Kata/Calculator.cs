using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string numbersString)
        {
            if(string.IsNullOrEmpty(numbersString))
                return 0;

            var splitters = GetSpeparators(numbersString);
            var numbers = GetNumbers(numbersString, splitters);

            return Add(numbers);
        }

        private string[] GetSpeparators(string numbersString)
        {
            List<string> separators = new List<string>
                {
                    ",", "\n"
                };

            if (numbersString.StartsWith("//"))
            {
                var segments = numbersString.Split('\n');
                if (segments.Any())
                {
                    var splitters = segments[0].Substring(2).Replace("[", "");
                    separators.AddRange(splitters.Split(']'));
                }

            }
            return separators.ToArray();
        }

        private IEnumerable<int> GetNumbers(string numbersString, string[] separators)
        {
            List<int> array = new List<int>();
            var characters = numbersString.Split(separators, StringSplitOptions.None);
            int temp;
            string exceptionMessageParams = string.Empty;
            foreach (var character in characters)
            {
                if (int.TryParse(character, out temp))
                {
                    if(temp > 0)
                        array.Add(temp);
                    else
                    {
                        if (string.IsNullOrEmpty(exceptionMessageParams))
                            exceptionMessageParams += temp;
                        else
                        {
                            exceptionMessageParams += "," + temp;
                        }
                    }
                }
            }
            
            if(!string.IsNullOrEmpty(exceptionMessageParams))
                throw new ArgumentException("negatives not allowed", exceptionMessageParams);
            return array;
        }

        private int Add(IEnumerable<int> numbers)
        {
            return numbers.Where(n => n <= 1000).Sum();
        }
    }

}