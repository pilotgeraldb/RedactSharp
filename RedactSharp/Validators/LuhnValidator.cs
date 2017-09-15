using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedactSharp.Validators
{
    public sealed class LuhnValidator : IValidator
    {
        public LuhnValidator()
        {

        }

        public bool Validate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            string number = input.Trim().Replace("-", "").Replace(" ", "");

            int length = number.Length;

            int checkSum = int.Parse(number[length - 1].ToString());

            IEnumerable<int> n = number.Select(x => int.Parse(x.ToString()))
                .Reverse()
                .Skip(1);

            IEnumerable<int> d_odd = n.Where((value, index) => { return (index) % 2 != 0; });

            IEnumerable<int> d_even = n.Where((value, index) => { return (index) % 2 == 0; });

            IEnumerable<int> d_even_doubled = d_even.Select(x => x * 2);

            IEnumerable<int> d_even_doubled_sum = d_even_doubled.Select(x => (x > 9 ? x - 9 : x));

            IEnumerable<int> result = Enumerable.Empty<int>();

            if (d_even_doubled_sum.Count() < d_odd.Count())
            {
                result = d_even_doubled_sum.SelectMany((x, idx) => new[] { d_odd.ToList()[idx], x })
                   .Concat(d_odd.Skip(d_even_doubled_sum.Count()));
            }
            else
            {
                result = d_odd.SelectMany((x, idx) => new[] { d_even_doubled_sum.ToList()[idx], x })
                   .Concat(d_even_doubled_sum.Skip(d_odd.Count()));
            }

            int calculatedCheckSum = (result.Sum() * 9) % 10;

            bool valid = checkSum == calculatedCheckSum;

            if (!valid)
            {
                System.Diagnostics.Trace.WriteLine("luhn validation failed for credit card number " + number + ". expected checksum " + checkSum + " and got " + calculatedCheckSum);
            }

            return valid; 
        }
    }
}