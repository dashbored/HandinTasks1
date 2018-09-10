using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TärningsSimulator
{
    class TärningsSimulator
    {
        static void Main(string[] args)
        {
            int count = 0;

            Console.WriteLine("Välkommen till tärningssimulatorn!");
            Console.Write("Omgångar? ");
            int omgångar = int.Parse(Console.ReadLine());

            Console.Write("Tärningar? ");
            int tärningar = int.Parse(Console.ReadLine());

            Console.Write("Sidor? ");
            int sidor = int.Parse(Console.ReadLine());

            int[] tal1 = new int[omgångar];
            int[] tal2 = new int[omgångar];
            int[] tal3 = new int[omgångar];
            int[] tal4 = new int[omgångar];
            int[] tal5 = new int[omgångar];

            int[] svar = new int[omgångar];

            Random slumpare = new Random();

            foreach (int value in tal1)
            {
                tal1[count] = slumpare.Next(1, sidor+1);
                tal2[count] = slumpare.Next(1, sidor+1);
                tal3[count] = slumpare.Next(1, sidor + 1);
                tal4[count] = slumpare.Next(1, sidor + 1);
                tal5[count] = slumpare.Next(1, sidor + 1);
                count++;
            }

            for (int i = 0; i < omgångar; i++)
            {
                svar[i] = tal1[i] + tal2[i] + tal3[i] + tal4[i] + tal5[i];
                Console.WriteLine("Omgång " + (i + 1) + ": " + tal1[i] + " " + tal2[i] + " " + tal3[i] + " " + tal4[i] + " " + tal5[i] + " = " + svar[i]);
            }

            Console.WriteLine("Total summa: " + svar.Sum());
            Console.WriteLine("Medelvärde per omgång: " + (svar.Sum() / (double)omgångar));
            Console.ReadLine();
        }
    }
}
