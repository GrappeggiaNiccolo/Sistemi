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

            int[] nums = Convert_Numero_Decimale_To_Decimale_Puntato(4294967295);
            foreach (int n in nums)
            {
                Console.Write(n + ".");
            }

            int[] num = Convert_Binario_To_Decimale_Puntato(b);
            foreach (int n in num)
            {
                Console.WriteLine(n);
            }

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

        static int[] Convert_Numero_Decimale_To_Decimale_Puntato(uint numero)
        {
            int[] decPuntato = new int[4];
            for (int i = decPuntato.Length - 1; i >= 0; i--)
            {
                decPuntato[i] = (int)(numero % 256);
                numero /= 256;
                if (numero < 0)
                {
                    break;
                }
            }
            return decPuntato;
        }
        static bool[] Convert_Numero_Decimale_To_Binario(uint numero)
        {
            bool[] bollArr = new bool[32];
            for (int i = bollArr.Length - 1; i >= 0; i--)
            {
                if (numero % 2 == 1)
                {
                    bollArr[i] = true;
                }
                numero /= 2;
                if (numero < 0)
                {
                    break;
                }
            }
            return bollArr;
        }

        static bool[] Convert_Decimale_Puntato_To_Binario(int[] decimalePuntato)
        {
            bool[] bools = new bool[decimalePuntato.Length * 8]; // calcola i byte
            int numero;
            for (int i = 0; i < decimalePuntato.Length; i++)
            {
                numero = decimalePuntato[i];
                for (int j = 7; j >= 0; j--) // converto ogni byte
                {
                    if (numero % 2 == 1)
                    {
                        bools[j + i * 8] = true;
                    }
                    numero /= 2;
                    if (numero < 0) // significa che la conversione è finita
                    {
                        break;
                    }
                }
            }
            return bools;
        }

        static int[] Convert_Binario_To_Decimale_Puntato(bool[] bools)
        {
            int[] decimalePuntato = new int[4];
            int numero;
            for (int i = decimalePuntato.Length - 1; i >= 0; i--)
            {
                numero = 0;
                for (int j = 0; j < 8; j++) // 8 = bit in un byte
                {
                    if (bools[j + 8 * i])
                    {
                        numero += (int)Math.Pow(2, 7 - j); // da binario ad intero
                    }
                }
                decimalePuntato[i] = numero;
            }
            return decimalePuntato;
        }
    }
}
