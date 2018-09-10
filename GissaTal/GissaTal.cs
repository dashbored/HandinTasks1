using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GissaTal
{
    class GissaTal
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string guess;
            int guessNumber;
            string forts = "Ja";

            while (forts == "Ja")
            {
                Console.Clear();

                int count = 0;
                int n = random.Next(1, 101);

                Console.WriteLine("Gissa ett tal mellan 1 och 100. ");

                do
                {
                    count++;
                    Console.Write("Gissning " + count + ": ");
                    guess = Console.ReadLine();
                    if (int.TryParse(guess, out guessNumber))
                    {
                        if (guessNumber < n)
                        {
                            Console.WriteLine("Talet är större.");
                        }
                        else if (guessNumber > n)
                        {
                            Console.WriteLine("Talet är lägre.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Du kan bara skriva ett tal med siffror. Försök igen!");
                        count--;
                    }
                } while (guessNumber != n);

                Console.WriteLine("Rätt! Du gissade rätt på " + count + " försök.");

                do
                {
                    Console.WriteLine("Vill du spela igen (Ja/Nej)?");
                    forts = Console.ReadLine();
                } while ((forts != "Nej") && (forts != "Ja"));
            }
            Console.WriteLine("Tack och hej, leverpastej!");
            System.Threading.Thread.Sleep(3000);
        }
    }
}
