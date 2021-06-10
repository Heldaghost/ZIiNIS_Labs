using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace эль_гамаль
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
    }
        public string s = "qwertyuiopasdfghjklzxcvbnm";

        public long p;
        public long g;
        public long cv;
        public long k;

        public long dv;
        public long ee;

        public long r;
        public byte[] hash;



        private void button1_Click(object sender, EventArgs e)
        {
            string s0 = textBox1.Text.ToString();
            string sitog = "";

            p = Convert.ToInt32(textBox3.Text.ToString());
            g = Convert.ToInt32(textBox4.Text.ToString());
            cv = Convert.ToInt32(textBox5.Text.ToString());
            k = Convert.ToInt32(textBox6.Text.ToString());

            dv = Convert.ToInt32((Math.Pow(g, cv))%p);
            richTextBox1.Text = "";
            richTextBox1.Text +="y="+dv+"\n";
            r = Convert.ToInt32((Math.Pow(g, k)) % p);

        //    ee = Convert.ToInt32(Math.Pow(g, k) % p);
            char c ;
            for (int i = 0; i < s0.Length; i++)
            {
                c = s0[i];
                int l = s.IndexOf(c);
                richTextBox1.Text += "\n"+c+"=" + l;
                ee = Convert.ToInt32((l*Math.Pow(dv, k)) % p);
                textBox2.Text += r + " " + ee+" "; 

            }
            var md5 = MD5.Create();
            hash = md5.ComputeHash(Encoding.UTF8.GetBytes(s0));
            richTextBox1.Text += "\n";
            richTextBox1.Text += Convert.ToBase64String(hash);






        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s0 = textBox2.Text.ToString();

            string sb="";
            char c;
            long ch1=0,ch2=0;
            int itog=0;//определит сколько чисел 
            for (int i = 0; i < s0.Length; i++)
            {
                c = s0[i];
                if (c != ' ') { sb += c; }
                else {

                    if (itog == 0)
                    {
                        ch1 = Convert.ToInt32(sb);
                        itog++;
                        sb = "";
                    }
                    else {
                        if (itog == 1)
                        {
                            ch2 = Convert.ToInt32(sb);
                            //richTextBox2.Text += ch1 + "-" + ch2+"\n";
                            itog = 0;
                            //
                     //       richTextBox2.Text += "\n" + ch1 + " " + ch2 + "\n" +"-----"+Convert.ToInt32((ch2 * Math.Pow(ch1, p - (1 + cv))) % p);

                       // richTextBox2.Text +=s[Convert.ToInt32((ch2 *Math.Pow(ch1, p-(1+cv)))%p)];
                            sb = "";
                        }
                    }

                    
                    
                    }

            }
            richTextBox2.Text += Convert.ToBase64String(hash);





        }
    }
}
