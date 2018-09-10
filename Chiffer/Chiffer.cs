using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Chiffer
{
    class Chiffer
    {
        static void Main(string[] args)
        {
            Console.Write("Skriv en text med VERSALER: ");
            string meddelande = Console.ReadLine();

            meddelande = meddelande.ToUpper();
            meddelande = Regex.Replace(meddelande, "[^A-Z]", "");

            Console.Write("Skriv in ett tal som nyckel: ");
            int nyckel = int.Parse(Console.ReadLine());

            byte[] ASCIIKod = Encoding.ASCII.GetBytes(meddelande);

            for (int i = 0; i < meddelande.Length; i++)
            {
                if (nyckel > 0)
                {
                    for (int j = 1; j < nyckel + 1; j++)
                    {
                        ASCIIKod[i]++;
                        if (ASCIIKod[i] > 90)
                        {
                            ASCIIKod[i] = 65;
                        }
                    }
                }
                else
                {
                    for (int j = 1; j < Math.Abs(nyckel) + 1; j++)
                    {
                        ASCIIKod[i]--;
                        if (ASCIIKod[i] < 65)
                        {
                            ASCIIKod[i] = 90;
                        }
                    }
                }
            }

            string encrypted = System.Text.Encoding.Default.GetString(ASCIIKod);
            Console.Write("Resultat: {0}", encrypted);
            Console.ReadLine();
        }
    }
}
