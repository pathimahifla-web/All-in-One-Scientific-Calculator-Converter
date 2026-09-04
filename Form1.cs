using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public static Form1 instance;
        double enterFirstValue, enterSecondValue;
        String op;
        String x, b;
        
        public Form1()
        {
//image slider
            //this.BackgroundImage = Properties.Resources.green_cal;
            InitializeComponent();
            instance = this;
        }

//starting of image slider click event
        private void ImageSlider(object sender, EventArgs e)
        {
            
            //List<Bitmap> a = new List<Bitmap>();
            //a.Add(Properties.Resources.blue_cal);
            //a.Add(Properties.Resources.dark_cal);
            //a.Add(Properties.Resources.green_cal);
            //a.Add(Properties.Resources.light_cal);
            //a.Add(Properties.Resources.sc_cal);
            //int index = DateTime.Now.Second % a.Count;
            //this.BackgroundImage = a[index];
        }
        

// adding numbers to txtResult.Text with (.)
        private void EnterNumbers(object sender, EventArgs e)
        {
  
            Button num = (Button)sender;

            if (txtResult.Text == "0")
                txtResult.Text = "";
            {
                if (num.Text == ".")
                {
                    if (!txtResult.Text.Contains("."))
                        txtResult.Text = txtResult.Text + num.Text;
                }
                else
                {
                    txtResult.Text = txtResult.Text + num.Text;
                }
            }
           
        }

// adding operators to calculator
        private void numberOperators(object sender, EventArgs e)
        {
            Button num = (Button)sender;
            try
            {
                enterFirstValue = Convert.ToDouble(txtResult.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            op = num.Text;
            txtResult.Text = "";
            txtPre.Text = enterFirstValue + " " + op + " " + " " + num ; 
        }

        private void btnEquals(object sender, EventArgs e)
        {
            try
            {
                enterSecondValue = Convert.ToDouble(txtResult.Text);
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }

            switch (op)
            { 
                case "+":
                    txtResult.Text = (enterFirstValue + enterSecondValue).ToString();
                break;

                case "-":
                    txtResult.Text = (enterFirstValue - enterSecondValue).ToString();
                break;

                case "/":
                    txtResult.Text = (enterFirstValue / enterSecondValue).ToString();
                break;

                case "*":
                    txtResult.Text = (enterFirstValue * enterSecondValue).ToString();
                break;

                case "Mod":
                txtResult.Text = (enterFirstValue % enterSecondValue).ToString();
                break;

                case "Exp":
                double i = Convert.ToDouble(enterFirstValue);
                double j ;
                    j = enterSecondValue;
                    txtResult.Text = Math.Exp(i * Math.Log(j * 4)).ToString();
                break;

                case "x^y":
                double x = Convert.ToDouble(enterFirstValue);
                double y;
                y = enterSecondValue;
                txtResult.Text = Math.Pow(enterFirstValue, y).ToString(); 
                break;
                        
                default:
                break;
            }
        }

// changing the mode according to Strip menu item
        private void Form1_Load_1(object sender, EventArgs e)
        {

            this.Width = 242;
            this.Height = 426;
            txtResult.Width = 184;
            txtResult.Height = 44;

            txtPre.Width = 184;
            txtPre.Height = 26;
           
        }

         private void standardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.st;
            this.Text = "Standard Calculator";
            this.Width = 242;
            this.Height = 426;
            txtResult.Width = 184;
            txtResult.Height = 44;

            txtPre.Width = 184;
            txtPre.Height = 26;

        }

        private void scientificToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            this.Icon = Properties.Resources.sc;
            this.Text = "Scientific Calculator";
            this.Width = 500;
            this.Height = 426;
            
            txtResult.Width = 443;
            txtResult.Height = 44;

            txtPre.Width = 443;
            txtPre.Height = 26;


        }
            
        
        private void unitConvertorToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            Form2 form = new Form2();
            form.Show();
            this.Hide();

        }

        // Exit from the calculator
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            DialogResult exitCal;
            exitCal = MessageBox.Show("Are you want to exit?","Calculator",MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (exitCal == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //calculations with pi
        private void btnPi_Click_1(object sender, EventArgs e)
        {
            txtResult.Text = "3.14159265358979323";
        }
        
        
       //calculations with x^3
        private void btnXthree_Click_1(object sender, EventArgs e)
        {
            double x, p;
            p = Convert.ToDouble(txtResult.Text);
            x = (p * p * p);

            txtResult.Text = Convert.ToString(x);
        }

        //calculations with x^2
        private void btnXtwo_Click_1(object sender, EventArgs e)
        {
            double x;
            x = Convert.ToDouble(txtResult.Text) * Convert.ToDouble(txtResult.Text);
            txtResult.Text = Convert.ToString(x);
        }
       

        //calculations with sin^-1 
        private void btnSinh_Click(object sender, EventArgs e)
        {
            double sih = Convert.ToDouble(txtResult.Text);
            sih = Math.Sinh(sih);
            txtResult.Text = Convert.ToString(sih);
        }

        //calculations with sin
        private void btnSin_Click(object sender, EventArgs e)
        {
            double si = Convert.ToDouble(txtResult.Text);
            si = Math.Sin(si);
            txtResult.Text = Convert.ToString(si);
        }

        //calculations with cos^-1
        private void btnCosh_Click(object sender, EventArgs e)
        {
            double coh = Convert.ToDouble(txtResult.Text);
            coh = Math.Cosh(coh);
            txtResult.Text = Convert.ToString(coh);
        }

        //calculations with cos
        private void btnCos_Click(object sender, EventArgs e)
        {
            double co = Convert.ToDouble(txtResult.Text);
            co = Math.Cos(co);
            txtResult.Text = Convert.ToString(co);
        }

        //calculations with tan^-1
        private void btnTanh_Click(object sender, EventArgs e)
        {
            double tah = Convert.ToDouble(txtResult.Text);
            tah = Math.Tanh(tah);
            txtResult.Text = Convert.ToString(tah);
        }

        //calculations with tan
        private void btnTan_Click(object sender, EventArgs e)
        {
            double ta = Convert.ToDouble(txtResult.Text);
            ta = Math.Tanh(ta);
            txtResult.Text = Convert.ToString(ta);
        }

        //calculations with 1/x
        private void btnInvx_Click(object sender, EventArgs e)
        {
            double a;
            a = Convert.ToDouble(1.0 / Convert.ToDouble(txtResult.Text));
            txtResult.Text = Convert.ToString(a);
        }

        //calculations with lnx
        private void btnLnx_Click(object sender, EventArgs e)
        {
            double lnx = Convert.ToDouble(txtResult.Text);
            lnx = Math.Log(lnx);
            txtResult.Text = Convert.ToString(lnx);
        }

        
        //calculations with decimal , binary, octal ,hexadecimal
      
        private void btnBin_Click(object sender, EventArgs e)
        {
            int a = int.Parse(txtResult.Text);
            txtResult.Text = Convert.ToString(a, 2);
        
        }
      
        private void btnDec_Click(object sender, EventArgs e)
        {
            double dec = Convert.ToDouble(txtResult.Text);

            int i1 = Convert.ToInt32(dec);
            int i2 = (int)dec;
            txtResult.Text = Convert.ToString(i2);
        }

        private void btnHex_Click(object sender, EventArgs e)
        {
            int a = int.Parse(txtResult.Text);
            txtResult.Text = Convert.ToString(a, 16);
        }

        private void btnOct_Click(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(txtResult.Text);
                txtResult.Text = Convert.ToString(a, 8);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        
        //calculations with factorials
        private void btnN_Click(object sender, EventArgs e)
        {
            try
            {
                long fact = 1;
                for (int i = 1; i <= Convert.ToInt32(txtResult.Text); i++)
                {
                    fact = fact * i;
                }
                txtResult.Text = Convert.ToString(fact);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //calculations with percentage
        private void btnPer_Click(object sender, EventArgs e)
        {
           
            double a;
            a = Convert.ToDouble( txtResult.Text)/Convert.ToDouble(100);
            txtResult.Text = Convert.ToString(a);
        }

        //CE button
        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
            String first, second;
            first = Convert.ToString(enterFirstValue);
            second = Convert.ToString(enterSecondValue);

            first = "";
            second = "";
            txtPre.Text = "";
           
        }

        //C button
        
        private void btnClear_Click(object sender, EventArgs e)
        {
             txtResult.Text = "0";
             txtPre.Text = "";
        }

        //Del button
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtResult.Text.Length > 0) {
                txtResult.Text = txtResult.Text.Remove(txtResult.Text.Length - 1, 1);
            }
        }

        //calculations with log10
        private void btnLog_Click(object sender, EventArgs e)
        {
            
            try
            {
                if(txtResult.Text.Length !=0)
                {
                    double l;
                    l = Math.Log10(Convert.ToDouble(txtResult.Text));
                    txtResult.Text = Convert.ToString(l);

                }
                //sign = 1;
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Ex button
        private void btnEx_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (txtResult.Text.Length != 0)
                {
                    double h;
                    h = Math.Exp(Convert.ToDouble(txtResult.Text));
                    txtResult.Text = Convert.ToString(h);

                }
                //sign = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
      //calculations with sqrt
        private void btnSqrt_Click_1(object sender, EventArgs e)
        {
            double sqr = Convert.ToDouble(txtResult.Text);
            sqr = Math.Sqrt(sqr);
            txtResult.Text = Convert.ToString(sqr);
        }
      //+- button 
        private void btnPN_Click(object sender, EventArgs e)
        {
            try
            {
                double q = Convert.ToDouble(txtResult.Text);
                txtResult.Text = Convert.ToString(-1 * q);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        // <- button 
        private void btnBS_Click(object sender, EventArgs e)
        {
            b = txtResult.Text;
            int a = b.Length;
            for (int i = 0; i < a - 1; i++) 
            {
                x += b[i];
            }
            txtResult.Text = x;
            x = "";
        }
        //calculations with log
        private void btnLog1_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (txtResult.Text.Length != 0)
                {
                    double l;
                    l = Math.Log(Convert.ToDouble(txtResult.Text));
                    txtResult.Text = Convert.ToString(l);

                }
               // sign = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

  



    }
}
