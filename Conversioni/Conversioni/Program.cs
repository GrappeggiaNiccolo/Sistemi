using System;

namespace Conversioni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool[] b = { true, false, false, false, true };           
            int[] dp = { 1, 2, 3, 4 };

            Console.WriteLine("Numero binario convertito: " + Convert_Binario_To_Decimale(b));

            Console.WriteLine("Numero decimale puntato convertito: " + Convert_Decimale_Puntato_To_Decimale(dp));

            Console.ReadLine();
        }
        static int Convert_Binario_To_Decimale(bool[] b)
        {
            int binDec = 0;
            int esponente = 0;

            for (int i = b.Length - 1; i >= 0; i--)
            {
                if (b[i])
                {
                    binDec += (int)Math.Pow(2, esponente);
                }
                esponente++;
            }

            return  binDec;
        }
        static int Convert_Decimale_Puntato_To_Decimale(int[] dp)
        {
            int dpDec = 0;
            int potenza = 0;

            for (int i = dp.Length - 1; i >= 0; i--)
            {
                dpDec += dp[i] * (int)Math.Pow(256, potenza);
                potenza++;
            }

            return dpDec;
        }
    }
}
