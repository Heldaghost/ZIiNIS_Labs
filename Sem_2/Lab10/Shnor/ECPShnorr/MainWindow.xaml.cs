using Microsoft.Win32;
using System;
using System.IO;
using System.Numerics;
using System.Text;
using System.Windows;
using System.Linq;

namespace ECPShnorr
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static class T
        {
            public static ulong p;
            public static ulong q;
            public static ulong b;
            public static ulong a;
            public static BigInteger v;
        }
        public class MD5
    {
        public static string ConvertToHexString(uint value)
        {
            string str = Convert.ToString(value, 16).PadLeft(8, '0');
            var tmp = "";
            for (int i = 0; i < 4; i++)
            {
                tmp = str.Substring(0, 2) + tmp;
                str = str.Remove(0, 2) + tmp;
            }
            return tmp;
        }

        public static uint F(uint x, uint y, uint z)
        {
            return x & y | ~x & z;
        }

        public static uint G(uint x, uint y, uint z)
        {
            return x & z | y & ~z;
        }

        public static uint I(uint x, uint y, uint z)
        {
            return y ^ (x | ~z);
        }

        public static uint H(uint x, uint y, uint z)
        {
            return x ^ y ^ z;
        }

        public static uint RotateLeft(uint x, int n)
        {
            return (x << n) | (x >> (32 - n));
        }

        public static void FF(ref uint a, uint b, uint c, uint d, uint x, int s, uint ac)
        {
            a = RotateLeft(a + F(b, c, d) + x + ac, s) + b;
        }

        public static void GG(ref uint a, uint b, uint c, uint d, uint x, int s, uint ac)
        {
            a = RotateLeft(a + G(b, c, d) + x + ac, s) + b;
        }

        public static void HH(ref uint a, uint b, uint c, uint d, uint x, int s, uint ac)
        {
            a = RotateLeft(a + H(b, c, d) + x + ac, s) + b;
        }

        public static void II(ref uint a, uint b, uint c, uint d, uint x, int s, uint ac)
        {
            a = RotateLeft(a + I(b, c, d) + x + ac, s) + b;
        }



        public static string Encryption(string str)
        {
            var arra = Encoding.UTF8.GetBytes(str);
            var array = arra.ToList();

            int count = array.Count / 64;
            if (count * 64 + 56 - array.Count <= 0)
            {
                count++;
            }

            int res = count * 64 + 56 - array.Count;

            array.Add(128);
            for (int i = 0; i < res - 1; i++)
            {
                array.Add(0);
            }

            byte[] newarray = BitConverter.GetBytes(arra.Length * 8);
            array.AddRange(newarray);
            for (int i = 0; i < 8 - newarray.Length; i++)
            {
                array.Add(0);
            }

            uint A = 0x67452301;
            uint B = 0xefcdab89;
            uint C = 0x98badcfe;
            uint D = 0x10325476;



            int S11 = 7;
            int S12 = 12;
            int S13 = 17;
            int S14 = 22;
            int S21 = 5;
            int S22 = 9;
            int S23 = 14;
            int S24 = 20;
            int S31 = 4;
            int S32 = 11;
            int S33 = 16;
            int S34 = 23;
            int S41 = 6;
            int S42 = 10;
            int S43 = 15;
            int S44 = 21;


            for (int k = 0; k <= count; k++)
            {

                var x = new uint[16];

                for (int i = k * 64, j = 0; i < k * 64 + 64; i += 4, j++)
                {
                    var tt = array.GetRange(i, 4).ToList();
                    var X = BitConverter.ToUInt32(tt.ToArray(), 0);
                    x[j] = X;
                }


                uint a = A, b = B, c = C, d = D;
                /* Round 1 */
                FF(ref a, b, c, d, x[0], S11, 0xd76aa478); /* 1 */
                FF(ref d, a, b, c, x[1], S12, 0xe8c7b756); /* 2 */
                FF(ref c, d, a, b, x[2], S13, 0x242070db); /* 3 */
                FF(ref b, c, d, a, x[3], S14, 0xc1bdceee); /* 4 */
                FF(ref a, b, c, d, x[4], S11, 0xf57c0faf); /* 5 */
                FF(ref d, a, b, c, x[5], S12, 0x4787c62a); /* 6 */
                FF(ref c, d, a, b, x[6], S13, 0xa8304613); /* 7 */
                FF(ref b, c, d, a, x[7], S14, 0xfd469501); /* 8 */
                FF(ref a, b, c, d, x[8], S11, 0x698098d8); /* 9 */
                FF(ref d, a, b, c, x[9], S12, 0x8b44f7af); /* 10 */
                FF(ref c, d, a, b, x[10], S13, 0xffff5bb1); /* 11 */
                FF(ref b, c, d, a, x[11], S14, 0x895cd7be); /* 12 */
                FF(ref a, b, c, d, x[12], S11, 0x6b901122); /* 13 */
                FF(ref d, a, b, c, x[13], S12, 0xfd987193); /* 14 */
                FF(ref c, d, a, b, x[14], S13, 0xa679438e); /* 15 */
                FF(ref b, c, d, a, x[15], S14, 0x49b40821); /* 16 */

                /* Round 2 */
                GG(ref a, b, c, d, x[1], S21, 0xf61e2562); /* 17 */
                GG(ref d, a, b, c, x[6], S22, 0xc040b340); /* 18 */
                GG(ref c, d, a, b, x[11], S23, 0x265e5a51); /* 19 */
                GG(ref b, c, d, a, x[0], S24, 0xe9b6c7aa); /* 20 */
                GG(ref a, b, c, d, x[5], S21, 0xd62f105d); /* 21 */
                GG(ref d, a, b, c, x[10], S22, 0x2441453); /* 22 */
                GG(ref c, d, a, b, x[15], S23, 0xd8a1e681); /* 23 */
                GG(ref b, c, d, a, x[4], S24, 0xe7d3fbc8); /* 24 */
                GG(ref a, b, c, d, x[9], S21, 0x21e1cde6); /* 25 */
                GG(ref d, a, b, c, x[14], S22, 0xc33707d6); /* 26 */
                GG(ref c, d, a, b, x[3], S23, 0xf4d50d87); /* 27 */
                GG(ref b, c, d, a, x[8], S24, 0x455a14ed); /* 28 */
                GG(ref a, b, c, d, x[13], S21, 0xa9e3e905); /* 29 */
                GG(ref d, a, b, c, x[2], S22, 0xfcefa3f8); /* 30 */
                GG(ref c, d, a, b, x[7], S23, 0x676f02d9); /* 31 */
                GG(ref b, c, d, a, x[12], S24, 0x8d2a4c8a); /* 32 */

                /* Round 3 */
                HH(ref a, b, c, d, x[5], S31, 0xfffa3942); /* 33 */
                HH(ref d, a, b, c, x[8], S32, 0x8771f681); /* 34 */
                HH(ref c, d, a, b, x[11], S33, 0x6d9d6122); /* 35 */
                HH(ref b, c, d, a, x[14], S34, 0xfde5380c); /* 36 */
                HH(ref a, b, c, d, x[1], S31, 0xa4beea44); /* 37 */
                HH(ref d, a, b, c, x[4], S32, 0x4bdecfa9); /* 38 */
                HH(ref c, d, a, b, x[7], S33, 0xf6bb4b60); /* 39 */
                HH(ref b, c, d, a, x[10], S34, 0xbebfbc70); /* 40 */
                HH(ref a, b, c, d, x[13], S31, 0x289b7ec6); /* 41 */
                HH(ref d, a, b, c, x[0], S32, 0xeaa127fa); /* 42 */
                HH(ref c, d, a, b, x[3], S33, 0xd4ef3085); /* 43 */
                HH(ref b, c, d, a, x[6], S34, 0x4881d05); /* 44 */
                HH(ref a, b, c, d, x[9], S31, 0xd9d4d039); /* 45 */
                HH(ref d, a, b, c, x[12], S32, 0xe6db99e5); /* 46 */
                HH(ref c, d, a, b, x[15], S33, 0x1fa27cf8); /* 47 */
                HH(ref b, c, d, a, x[2], S34, 0xc4ac5665); /* 48 */

                /* Round 4 */
                II(ref a, b, c, d, x[0], S41, 0xf4292244); /* 49 */
                II(ref d, a, b, c, x[7], S42, 0x432aff97); /* 50 */
                II(ref c, d, a, b, x[14], S43, 0xab9423a7); /* 51 */
                II(ref b, c, d, a, x[5], S44, 0xfc93a039); /* 52 */
                II(ref a, b, c, d, x[12], S41, 0x655b59c3); /* 53 */
                II(ref d, a, b, c, x[3], S42, 0x8f0ccc92); /* 54 */
                II(ref c, d, a, b, x[10], S43, 0xffeff47d); /* 55 */
                II(ref b, c, d, a, x[1], S44, 0x85845dd1); /* 56 */
                II(ref a, b, c, d, x[8], S41, 0x6fa87e4f); /* 57 */
                II(ref d, a, b, c, x[15], S42, 0xfe2ce6e0); /* 58 */
                II(ref c, d, a, b, x[6], S43, 0xa3014314); /* 59 */
                II(ref b, c, d, a, x[13], S44, 0x4e0811a1); /* 60 */
                II(ref a, b, c, d, x[4], S41, 0xf7537e82); /* 61 */
                II(ref d, a, b, c, x[11], S42, 0xbd3af235); /* 62 */
                II(ref c, d, a, b, x[2], S43, 0x2ad7d2bb); /* 63 */
                II(ref b, c, d, a, x[9], S44, 0xeb86d391); /* 64 */

                A += a;
                B += b;
                C += c;
                D += d;

            }
            return ConvertToHexString(A) + ConvertToHexString(B) + ConvertToHexString(C) + ConvertToHexString(D);

        }
    }
        public static class Shnor
        {
            public static bool IsPrime(ulong a)
            {
                ulong i;
                if (a == 2)
                    return true;
                if (a == 0 || a == 1 || a % 2 == 0)
                    return false;

                for (i = 3; i * i <= a && Convert.ToBoolean(a % i); i += 2) ;

                return i * i > a;
            }

            public static ulong Efficient(ulong p)
            {
                ulong q = 0;
                for (var i = p / 2 - 1; i > 0; i--)
                {
                    if (p % i == 0)
                    {
                        q = i; break;
                    }
                }
                return q;
            }


            public static ulong PowMod(ulong a, ulong b, ulong p)
            {
                ulong res = 1;
                while (b != 0)
                    if (Convert.ToBoolean(b & 1))
                    {
                        res = res * 1L * a % p;
                        --b;
                    }
                    else
                    {
                        a = (a * 1L * a % p);
                        b >>= 1;
                    }
                return res;
            }

            public static ulong PrimitiveRoot(ulong q, ulong p)
            {
                ulong i = 0;
                for (i = (p - 1) / 2; i > 0; i--)
                {
                    ulong x = PowMod(i, q, p);
                    if (x == 1) break;
                }
                return i;
            }


            public static void ExtendedEuclid(BigInteger a, BigInteger b, ref BigInteger x, ref BigInteger y, ref BigInteger d)
            {
                BigInteger q, r, x1, x2, y1, y2;

                if (b.IsZero)
                {
                    d = a;
                    x = 1;
                    y = 0;
                    return;
                }

                x2 = 1;
                x1 = 0;
                y2 = 0;
                y1 = 1;

                while (b.CompareTo(0) > 0)
                {
                    q = BigInteger.Divide(a, b);
                    r = BigInteger.Subtract(a, BigInteger.Multiply(q, b));

                    x = BigInteger.Subtract(x2, BigInteger.Multiply(q, x1));
                    y = BigInteger.Subtract(y2, BigInteger.Multiply(q, y1));

                    a = b; b = r;

                    x2 = x1;
                    x1 = x;
                    y2 = y1;
                    y1 = y;
                }

                d = a;
                x = x2; y = y2;

            }


            public static BigInteger Inverse(BigInteger a, BigInteger n)
            {
                BigInteger d = 0, x = 0, y = 0;

                ExtendedEuclid(a, n, ref x, ref y, ref d);

                if (d.IsOne) return (x.Sign < 0 ? x + n : x);

                return 0;
            }
           
            public static void GetKeys()
            {
                
                Random rand = new Random();
                ulong p = (ulong)rand.Next(1000, 100000);
               
                while (!IsPrime(p))
                {     p++;       }
                T.p = p;
                ulong q = Efficient(p - 1);
                T.q = q;
               
                ulong b = PrimitiveRoot(q, p);
                T.b = b;
                
                ulong a = (ulong)rand.Next(1, (int)q - 1);
                T.a = a;
               
                BigInteger v = Inverse(BigInteger.Pow(b, (int)a), p);
                T.v = v;
            }


       
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Shnor.GetKeys();
            try
            {
                var openFileDialog1 = new OpenFileDialog{Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*", FilterIndex = 2, RestoreDirectory = true, Title = "File"};

                StringBuilder stringBuilder = new StringBuilder();
                string tmpFilePath = "";
                if (openFileDialog1.ShowDialog() == true)
                {
                    tmpFilePath = openFileDialog1.FileName;
                    try
                    {
                        using (var sr = new StreamReader(openFileDialog1.FileName))
                        {
                         
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                            
                                Text_for_crypt.Text = line;
                                stringBuilder.Append(line);
                            }
                          
                            sr.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }
                
                string hashMd5 = "";
                string cryptohash = "";
               
                    int p = int.Parse(T.p.ToString()), q = int.Parse(T.q.ToString()), b = int.Parse(T.b.ToString()), a = int.Parse(T.a.ToString());

                    Random rand = new Random();
                    ulong r = (ulong)rand.Next(1, (int)q - 1);

                    BigInteger x = BigInteger.ModPow(b, r, p);

                    stringBuilder.Append(x);
                    hashMd5 = MD5.Encryption(stringBuilder.ToString());

                    BigInteger E = new BigInteger(Encoding.ASCII.GetBytes(hashMd5));

                    BigInteger y = (a * E + r) % q;

                    cryptohash += E + y.ToString().PadLeft(8, '0');
                Hash.Text = cryptohash;
                using (StreamWriter fs = new StreamWriter(tmpFilePath, true))
                {
                    fs.Write(cryptohash);
                    fs.Close();
                }

                MessageBox.Show("ECP Success!");
            }
            catch (Exception ex)
            {

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                var openFileDialog1 = new OpenFileDialog { Filter = @"txt files (*.txt)|*.txt|All files (*.*)|*.*", FilterIndex = 2, RestoreDirectory = true, Title = "File" };

                StringBuilder stringBuilder = new StringBuilder();
                string tmpFilePath = "";
                if (openFileDialog1.ShowDialog() == true)
                {
                    tmpFilePath = openFileDialog1.FileName;
                    try
                    {
                        using (var sr = new StreamReader(openFileDialog1.FileName))
                        {
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                Text_for_ver.Text = line;
                                stringBuilder.Append(line);
                            }
                            sr.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }
                
                string Hash = stringBuilder.ToString().Substring(stringBuilder.Length - 85);
                BigInteger E = BigInteger.Parse(Hash.Substring(0, 77));
                int y = Convert.ToInt32(Hash.Substring(78));

                stringBuilder.Remove(stringBuilder.Length - 85, 85);

                string newHash = "";
                BigInteger E1 = 0;
                
                    int p = int.Parse(T.p.ToString()), q = int.Parse(T.q.ToString()), b = int.Parse(T.b.ToString()),v= int.Parse(T.v.ToString());
                    BigInteger z = (BigInteger.ModPow(b, y, p) * BigInteger.ModPow(v, E, p)) % p;

                    stringBuilder.Append(z);
                    newHash = MD5.Encryption(stringBuilder.ToString());
                    E1 = new BigInteger(Encoding.ASCII.GetBytes(newHash));
                
                using (StreamWriter fs = new StreamWriter(tmpFilePath, false))
                {
                    fs.Write(stringBuilder.ToString());
                    fs.Close();
                }
                E1_text.Text = E.ToString();
                E2_text.Text = E1.ToString();
                if (E == E1)
                {
                    MessageBox.Show("true message");
                }
                else
                {
                    MessageBox.Show("false message");
                }
               
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
