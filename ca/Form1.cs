using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ca
{
    public partial class calculator : Form
    {
        double result = 0;
        string operation = "";
            bool enter_value = false;
            string firstnum, secondnum;
        public calculator()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void number_only(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if((txtdisplay.Text =="0") ||(enter_value))
                    txtdisplay.Text = "";
            enter_value = false;

            if (b.Text == ".")
            {
                if (!txtdisplay.Text.Contains("."))
                    txtdisplay.Text = txtdisplay.Text + b.Text;
            }
            else
            {
                txtdisplay.Text = txtdisplay.Text + b.Text;
            }
        }

        private void op(object sender, EventArgs e)
        {
            secondnum = txtdisplay.Text;
            lblshopop.Text = "";
         Button b = (Button)sender;

            if(result != 0)
            {
                btnequal.PerformClick();
                enter_value=true;
                operation = b.Text;
                lblshopop.Text = System.Convert.ToString(result) + "    " + operation;
            }
            else
            {

            operation = b.Text;
            result = double.Parse(txtdisplay.Text);
            txtdisplay.Text = "";
            lblshopop.Text = System.Convert.ToString(result) + "   " + operation;
            }
            firstnum = lblshopop.Text;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtdisplay.Text = "0";
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtdisplay.Text = "0";
            result = 0;
            cl.Visible = true;
            richClear.AppendText(firstnum + "  " + secondnum + " = " + "\n");
            richClear.AppendText("\n\t" + txtdisplay + "\n\t");
            history.Text = "";
        }


        private void btnequal_Click(object sender, EventArgs e)
        {
            lblshopop.Text = "";
            switch (operation)
            {
                case "+":
                    txtdisplay.Text = (result + double.Parse(txtdisplay.Text)).ToString();
                    break;

                case "-":
                    txtdisplay.Text = (result - double.Parse(txtdisplay.Text)).ToString();
                    break;
                case "*":
                    txtdisplay.Text = (result * double.Parse(txtdisplay.Text)).ToString();
                    break;
                case "/":
                    txtdisplay.Text = (result / double.Parse(txtdisplay.Text)).ToString();
                    break;
                default:
                    break;

            }
            result = double.Parse(txtdisplay.Text);
            operation = "";
        }

        private void cl_Click(object sender, EventArgs e)
        {
            richClear.Clear();
            if (history.Text == "")
            {
                history.Text = "there is no hisroty";
            }
            cl.Visible = false;
            richClear.ScrollBars = 0;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(txtdisplay.Text.Length > 0)
            {
                txtdisplay.Text = txtdisplay.Text.Remove(txtdisplay.Text.Length - 1, 1);
         
            }
            if (txtdisplay.Text == "")
            {
                txtdisplay.Text = "0";
            }
        }
    }
}
