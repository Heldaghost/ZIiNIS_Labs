using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {

        public int first;
        public int second;
        public int nod1, nod2, nod3;
        bool flag;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            first = Convert.ToInt32(textBox1.Text);
            textBox1.Text = "";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            second = Convert.ToInt32(textBox2.Text);
            textBox2.Text = "";
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            flag = true;
            richTextBox1.Text = String.Format("Простые числа от {0} до {1}", first, second);
            while (first < second)
            {
                for (int i = 2; i <= Math.Round(Math.Sqrt(first)); i++)
                {
                   
                    if (first % i == 0 && first != 2)
                    {
                        flag = false;
                        break;
                    }
                    else
                    {
                        flag = true;
                    }
                }
                if(flag)
                {
                    richTextBox1.Text += "\n";
                    richTextBox1.Text += first.ToString();
                }
                first++;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                nod2 = Convert.ToInt32(textBox4.Text);
                textBox4.Text = "";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                richTextBox1.Text = String.Format("НОД чисел {0} и {1}", nod1, nod2);
            }
            else
            {
                richTextBox1.Text = String.Format("НОД чисел {0}, {1} и {2}", nod1, nod2, nod3);
            }
            
            int tmp;
            int k;
            int j = 0;
            bool flag = true; 
            while(flag)
            {
                if (nod1 > nod2)
                {
                    j = nod2;
                    tmp = nod1 % nod2;
                    k = tmp;
                    while (tmp != 0)
                    {
                     
                        tmp = j % k;
                        j = k;
                        k = tmp;
                    }
                    richTextBox1.Text += "\n";
                    richTextBox1.Text += "НОД 1 и 2 числа:";
                    richTextBox1.Text += "\n";
                    richTextBox1.Text += j.ToString();
                    flag = false;
                }
                else
                {
                    j = nod1;
                    tmp = nod2 % nod1;
                    k = tmp;
                    while (tmp != 0)
                    {
                        
                        tmp = j % k;
                        j = k;
                        k = tmp;
                    }
                    richTextBox1.Text += "\n";
                    richTextBox1.Text += "НОД 1 и 2 числа:";
                    richTextBox1.Text += "\n";
                    richTextBox1.Text += j.ToString();
                    flag = false;
                }
            }
            if(radioButton2.Checked)
            {
                flag = true;
                while (flag)
                {
                    if (nod3 > j)
                    {
                       
                        tmp = nod3 % j;
                        k = tmp;
                        while (tmp != 0)
                        {

                            tmp = j % k;
                            j = k;
                            k = tmp;
                        }
                        richTextBox1.Text += "\n";
                        richTextBox1.Text += "НОД 3 чисел";
                        richTextBox1.Text += "\n";
                        richTextBox1.Text += j.ToString();
                        flag = false;
                    }
                    else
                    {
                        int f = j;
                        j = nod3;
                        tmp = f % nod3;
                        k = tmp;
                        while (tmp != 0)
                        {

                            tmp = j % k;
                            j = k;
                            k = tmp;
                        }
                        richTextBox1.Text += "\n";
                        richTextBox1.Text += "НОД 3 чисел";
                        richTextBox1.Text += "\n";
                        richTextBox1.Text += j.ToString();
                        flag = false;
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox3.Text!="")
            {
                nod1 = Convert.ToInt32(textBox3.Text);
                textBox3.Text = "";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                nod3 = Convert.ToInt32(textBox5.Text);
                textBox5.Text = "";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                label5.Visible = false;
                button6.Visible = false;
                textBox5.Visible = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                label5.Visible = true;
                button6.Visible = true;
                textBox5.Visible = true;
            }
        }
    }
}
