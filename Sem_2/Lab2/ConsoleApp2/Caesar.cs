using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace ConsoleApp2
{
    class Caesar
    {
        private static string alpha = "abcdefghijklmnopqrstuvwxyz";
        private static char[] newAlpha = new char[26];
 
        public static string encrypt(string Message)
        {
            string res = "";
            foreach (char ch in Message)
            {
                for (int i = 0; i < alpha.Length; i++)
                {
                    if (ch == alpha[i])
                    {
                        res += newAlpha[i];
                        break;
                    }
                    if(ch==' ')
                    {
                        res += " ";
                        break;
                    }
                }
            }
            return res;
        }
 
        public static string decrypt(string Message)
        {
            string res = "";
            foreach (char ch in Message)
            {
                for (int i = 0; i < newAlpha.Length; i++)
                {
                    if (ch == newAlpha[i])
                    {
                        res += alpha[i];
                        break;
                    }
                    if (ch == ' ')
                    {
                        res += " ";
                        break;
                    }
                }
            }
            return res;
        }
 
        public static void createNewAlpha( int key) // создаёт новый алфавит с помощью ключа
        {
            
            for(int i = 7; i <26;i++)
            {
                newAlpha[i - key] = alpha[i];
            }
            for(int i = 19; i <26; i++)
            {
                newAlpha[i] = alpha[i - 19];
            }
           
        }
 
        public static string getNewAlpha()
        {
            string strNewAlpha = new string(newAlpha);
            return strNewAlpha;
        }
    }
}
