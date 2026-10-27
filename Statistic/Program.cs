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
        {   List<double> numbers = new List<double> { 3, 5, 5, 3, 2, 3, 5, 5, 5, 1 };

   //average
   var count = numbers.Count;
   var output = numbers.Sum() / count;
   Console.WriteLine(output);

   //median 
   numbers.Sort();
   double median;

   if (count % 2 == 0)
   {
       median = numbers[count / 2 - 1] + numbers[count / 2] / 2;
   }
   else
   {
       median = numbers[count / 2];
   }

   //mode for only one
   var mode = numbers.GroupBy(n => n)
       .OrderByDescending(g => g.Count())
       .Select(g => g.Key)
       .FirstOrDefault();

   //mode for multiple

   var groups = numbers.GroupBy(n => n).ToList();
   int maxCount = groups.Max (g => groups.Count());
   List<double> modes = groups.Where(g => g.Count() == maxCount).Select(g => g.Key).ToList();

   Console.WriteLine(median);
   Console.WriteLine(modes);

   var modeMultiple = numbers.GroupBy(n => n)
       .OrderByDescending(g => g.Count())
       .Where(g => g.Count() == numbers.GroupBy(n => n).Max(g2 => g2.Count()))
       .Select(g => g.Key)
       .ToList();

        }
    }
}
