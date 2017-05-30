using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrCalculator
{
    public class StringCalculator
    {
        private List<string> Delimiters = new List<string> { ",", "\n" };
        private string CustomDelimiter = "//";


        public int Add(string numbers)
        {
            List<int> splitNumbers;
            if (string.IsNullOrEmpty(numbers)) return 0;




            if (numbers.StartsWith(CustomDelimiter))
            {
                splitNumbers = SplitWithCustomDelimiter(numbers);

            }
            else
            {
                splitNumbers = SplitNumbers(numbers);
            }


           
         
            CheckForNegativeNumbers(splitNumbers);

            return splitNumbers.Sum();



        }

        public List<int> SplitNumbers(string numbers)
        {
            var splitNumbers = numbers.Split(Delimiters.ToArray(), StringSplitOptions.None).ToList();
            splitNumbers.RemoveAll(x => x == string.Empty);

            return splitNumbers.Select(int.Parse).ToList();
        }


        public List<int> SplitWithCustomDelimiter(string numbers)
        {
            var delimiter = GetCustomDelimiter(numbers);
            Delimiters.Add(delimiter);


            return SplitNumbers(numbers.Remove(0, CustomDelimiter.Length + delimiter.Length));
        }

        private string GetCustomDelimiter(string numbers)
        {
            return numbers.Substring(2, numbers.IndexOf('\n') - 2);

        }

        private void CheckForNegativeNumbers(List<int> numbers)
        {
            if (numbers.Any(x => x < 0))
            {
                throw new NegativeNumberException(numbers.Where(x => x < 0).ToList());
            }
        }
    }
}
