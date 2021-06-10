


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace labRSA
{
    public class Program
    {
        public static char[] characters = new char[] { '#', 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И',
                                                        'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
                                                        'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ',
                                                        'Э', 'Ю', 'Я', ' ', '1', '2', '3', '4', '5', '6', '7',
                                                        '8', '9', '0' };
        
        static void Main(string[] args)
        { long p = 1;
            long q = 1;

            Console.WriteLine("Введите p:");
            while (!IsTheNumberSimple(p))
            {
                p = Convert.ToInt64(Console.ReadLine());
            }
            Console.WriteLine("Введите q:");
            while (!IsTheNumberSimple(q))
            {
                q = Convert.ToInt64(Console.ReadLine());
            }
            string s = "";
            Console.WriteLine("1 - зашифровать, 2-расшифровать");
            int k = Convert.ToInt32(Console.ReadLine());
            long n = p * q;
            long m = (p - 1) * (q - 1);
            long d = Calculate_d(m);
            long e_ = Calculate_e(d, m);
            Console.WriteLine("q = {0}, p = {1}, d = {2}, e = {3}", q, p, d, e_);
            if (k == 1)
            {
                Console.WriteLine("Введите исходный текст:");
                s = Console.ReadLine();
                s = s.ToUpper();
                List<string> result = RSA_Endoce(s, e_, n);
                StreamWriter sw = new StreamWriter("out1.txt");
                foreach (string item in result)
                {
                    sw.WriteLine(item);
                    Console.WriteLine(item);
                }
                sw.Close();
            }
            else if(k == 2)
            {
                List<string> input = new List<string>();

                StreamReader sr = new StreamReader("out1.txt");

                while (!sr.EndOfStream)
                {
                    input.Add(sr.ReadLine());
                }

                sr.Close();

                string result = RSA_Dedoce(input, d, n);

                StreamWriter sw = new StreamWriter("out2.txt");
                Console.WriteLine(result);
                sw.WriteLine(result);
                sw.Close();
            }
            else
            {
                Console.WriteLine("Введено неверное число");
                throw new ArgumentOutOfRangeException();
            }
            
        }

        private static bool IsTheNumberSimple(long n)
        {
            if (n < 2)
                return false;

            if (n == 2)
                return true;

            for (long i = 2; i < n; i++)
                if (n % i == 0)
                    return false;

            return true;
        }
        private static long Calculate_e(long d, long m)
        {
            long e = 10;

            while (true)
            {
                if ((e * d) % m == 1)
                    break;
                else
                    e++;
            }

            return e;
        }
        public static long Calculate_d(long m)
        {
            long d = m - 1;

            for (long i = 2; i <= m; i++)
                if ((m % i == 0) && (d % i == 0)) //если имеют общие делители
                {
                    d--;
                    i = 1;
                }

            return d;
        }

        private static List<string> RSA_Endoce(string s, long e, long n)
        {
            List<string> result = new List<string>();

            BigInteger bi;

            for (int i = 0; i < s.Length; i++)
            {
                int index = Array.IndexOf(characters, s[i]);

                bi = new BigInteger(index);
                bi = BigInteger.Pow(bi, (int)e);

                BigInteger n_ = new BigInteger((int)n);

                bi = bi % n_;

                result.Add(bi.ToString());
            }

            return result;
        }

        //расшифровать
        private static string RSA_Dedoce(List<string> input, long d, long n)
        {
            string result = "";

            BigInteger bi;

            foreach (string item in input)
            {
                bi = new BigInteger(Convert.ToDouble(item));
                bi = BigInteger.Pow(bi, (int)d);

                BigInteger n_ = new BigInteger((int)n);

                bi = bi % n_;

                int index = Convert.ToInt32(bi.ToString());

                result += characters[index].ToString();
            }

            return result;
        }

    }
}
