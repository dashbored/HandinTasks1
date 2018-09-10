using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandinTasks1
{
    class PangBom
    {
        static void Main(string[] args)
        {
            int pang = 3;
            int bom = 5;

            for (int i = 1; i < 101; i++)
            {
                if (i % pang == 0)
                {
                    Console.Write("Pang");
                }
                if (i % bom == 0)
                {
                    Console.Write("Bom");
                }
                if (i % pang != 0 && i % bom != 0)
                {
                    Console.Write(i);
                }
                Console.WriteLine("");
            }
            Console.ReadLine();
        }
    }
}
