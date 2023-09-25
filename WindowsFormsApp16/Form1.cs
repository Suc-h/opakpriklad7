using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public double mocni(long n, int cislo)
        {
            double umocnen = cislo;
            if (n == 0)
            {
                umocnen = 1;
            }
            else
            {
                if(n>0)
                {
                    for (int i = 1; i < n; i++)
                    {
                        umocnen = umocnen * cislo;
                    }
                }
                else
                {
                    for (int i = 1; i > n; i--)
                    {
                        umocnen = umocnen / cislo;
                    }
                }

            }

            return umocnen;
        }
        public double podil(long n, double cislo)
        {
            double podil=0;
            if(n==0||cislo==0)
            {

            }
            else
            {
                podil = cislo / n;
            }


            return podil;


        }

        private void button1_Click(object sender, EventArgs e)
        {

            int umocnen = 0;
            int soucet = 0;
            StreamReader sr = null;
            try
            {
                long n = Convert.ToInt64(textBox1.Text);

                     sr = new StreamReader("cisla.txt");
                    for(int i=0;i<5;i++)
                    {
                        umocnen = Convert.ToInt32(sr.ReadLine());

                    }
                    sr.BaseStream.Position = 0;

                MessageBox.Show("Umocněné 5. číslo na n:" + n + " " + mocni(n, umocnen));
                MessageBox.Show("Podíl v realných číslech: " + podil(n, umocnen));
                MessageBox.Show("Podíl v celých číslech: " + Math.Round(podil(n, umocnen)));

                while(!sr.EndOfStream)
                {

                    soucet = soucet + Convert.ToInt32(sr.ReadLine());
                }
                MessageBox.Show("Součet je: " + soucet);
            }
            catch(FormatException ex)
            {
                MessageBox.Show(ex.ToString());


            }
            catch(StackOverflowException ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("" + soucet);
            }
            catch(FileNotFoundException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch(DivideByZeroException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch(IOException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch(OverflowException ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("" + soucet);
            }
            finally
            {
                if(sr!=null)
                {
                    sr.Close();
                }
            }



        }
    }
}
