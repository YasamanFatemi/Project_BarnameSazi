using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arayeshgah
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Modiriyat mo = new Modiriyat(); 
            mo.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SabtNobat sabtNobat = new SabtNobat();
            sabtNobat.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListNobat ln = new ListNobat();
            ln.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Sandogh sandogh = new Sandogh();
            sandogh.Show();
        }
    }
}
