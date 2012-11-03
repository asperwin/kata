using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata
{
    public class Calculator
    {
        public int Add(string items)
        {
            int sum = 0;

            if (string.IsNullOrEmpty(items))
                return sum;

            List<char> delimeters = new[] { ',', '\n' }.ToList();
            if (items.StartsWith("//"))
            {
                delimeters.Add(items[2]);
            }

            var numbers = items.Split(delimeters.ToArray());

            int tempVal = 0;

            string negatives = string.Empty;
            foreach (var number in numbers)
            {
                if (int.TryParse(number, out tempVal))
                {
                    if (tempVal > 0)
                    {
                        sum += tempVal;
                    }
                    else
                    {
                        negatives += tempVal + ";";
                    }
                }
            }
            if (!string.IsNullOrEmpty(negatives))
            {
                throw new ArgumentException("negatives not allowed", negatives);
            }

            return sum;
        }
    }
}
