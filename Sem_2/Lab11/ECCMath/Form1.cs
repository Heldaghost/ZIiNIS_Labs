using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECMath
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(kVar.Text == "" || lVar.Text == "" || pX.Text == "" || pY.Text == "" || qX.Text == "" || qY.Text == "")
            {
                MessageBox.Show("You must enter all information to compute operations!");
            }
            else
            {
                int XP = Convert.ToInt32(pX.Text);
                int YP = Convert.ToInt32(pY.Text);
                int XQ = Convert.ToInt32(qX.Text);
                int YQ = Convert.ToInt32(qY.Text);
                int lambda = ((YQ - YP) / (XQ - XP))%23;
                Lambda.Text = Convert.ToString(lambda);
            }
        }
    }
}
