using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2
{
    class Program
    {
        static void Main(string[] args)
        {
            string strang = "Du studerar C# programmering på Nackademin";

            strang = strang.Replace(" ", "!");
            string[] strangArr = strang.Split('!');
            int x = strang.Split('!').Length;
            Console.ReadLine();
        }
    }
}
