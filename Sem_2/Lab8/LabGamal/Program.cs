using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab8_1
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger[] a = { 13,17 };
            BigInteger[] x = {BigInteger.Pow(10,10), BigInteger.Pow(10, 20), BigInteger.Pow(10, 30), BigInteger.Pow(10, 40), BigInteger.Pow(10, 50), BigInteger.Pow(10, 60),
            BigInteger.Pow(10,70),BigInteger.Pow(10,80),BigInteger.Pow(10,90),BigInteger.Pow(10,100) };
            BigInteger n1 = new BigInteger(new byte[] {1,2,3,4,5,6,7,8,9,10,1,2,3,4,5,6,7,8,9,10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
            1,2,3,4,5,6,7,8,9,10,1,2,3,4,5,6,7,8,9,10,1,2,3,4,5,6,7,8,9,10,1,2,3,4,5,6,7,8,9,10,1,2,3,4,5,6,7,8,9,10,
            1,2,3,4,5,6,7,8,9,10,1,2,3,4,5,6,7,8,9,10,1,2,3,4,5,6,7,8,9,10,1,2,3,4,5,6,7,8,9,10,1,2,3,4,5,6,7,8});
            BigInteger n2 = new BigInteger(new byte[] {1,2,3,4,5,6,7,8,9,10,1,2,3,4,5,6,7,8,9,10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
            1,2,3,4,5,6,7,8,9,10,1,2,3,4,5,6,7,8,9,10,1,2,3,4,5,6,7,8,9,10,1,2,3,4,5,6,7,8,9,10,1,2,3,4,5,6,7,8,9,10,
            1,2,3,4,5,6,7,8,9,10,1,2,3,4,5,6,7,8,9,10,1,2,3,4,5,6,7,8,9,10,1,2,3,4,5,6,7,8,9,10,1,2,3,4,5,6,7,8,
            1,2,3,4,5,6,7,8,9,10,1,2,3,4,5,6,7,8,9,10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
            1,2,3,4,5,6,7,8,9,10,1,2,3,4,5,6,7,8,9,10,1,2,3,4,5,6,7,8,9,10,1,2,3,4,5,6,7,8,9,10,1,2,3,4,5,6,7,8,9,10,
            1,2,3,4,5,6,7,8,9,10,1,2,3,4,5,6,7,8,9,10,1,2,3,4,5,6,7,8,9,10,1,2,3,4,5,6,7,8,9,10,1,2,3,4,5,6,7,8});

            Console.WriteLine("N1 = 1024b");
            Calculate(a, x, n1);
            Console.WriteLine("N2 =2048b");
            Calculate(a, x, n2);

        }

        static void Calculate(BigInteger[] a,BigInteger[]x,BigInteger n)
        {
            Stopwatch stopWatch = new Stopwatch();
                  for(int i = 0; i <a.Length; i++)
            {
                for(int g = 0; g<x.Length;g++)
                {
                    stopWatch.Start();
                    BigInteger y = BigInteger.ModPow(a[i], x[g], n);
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours,
                        ts.Minutes,
                        ts.Seconds,
                        ts.Milliseconds / 10);
                    Console.WriteLine("a = {0}, x = 10^{1}, Time = {2}", a[i], (g+1)*10,elapsedTime);
                }
            }
            
        }

    }
}
