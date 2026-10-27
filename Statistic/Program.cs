using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = new List<double> { 3.82, 3.94, 4.05, 5.28, 4.34, 6.00, 5.82, 5.01, 3.23 };

            //average
            var count = numbers.Count;
            var output = numbers.Sum() / count;
            Console.WriteLine(output);

            //median 
            numbers.Sort();
            double median;

            if (count % 2 == 0)
            {
                median  = numbers[count / 2 - 1] + numbers[count/2] /2;
            }
            else
            {
                median = numbers[count/2];
            }
            
            //mode for only one
            var mode = numbers.GroupBy(n => n)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();

            //mode for multiple
            var modeMultiple = numbers.GroupBy(n => n)
                .OrderByDescending(g => g.Count())
                .Where(g => g.Count() == numbers.GroupBy(n => n).Max(g2 => g2.Count()))
                .Select(g => g.Key)
                .ToList();
        }
    }
}
