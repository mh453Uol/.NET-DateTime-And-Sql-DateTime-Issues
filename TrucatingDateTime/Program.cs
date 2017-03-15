using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrucatingDateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            var now1 = DateTime.Now;

            now1 = now1.Truncate(TimeSpan.FromMilliseconds(1));

            var now2 = DateTime.Now;

            now2 = now2.Truncate(TimeSpan.FromSeconds(1));

            var now3 = DateTime.Now;

            now3 = now3.Truncate(TimeSpan.FromMinutes(1));           

        }
    }
}
