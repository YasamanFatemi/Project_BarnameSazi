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
    public partial class Modiriyat : Form
    {
        public Modiriyat()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            herfe Herfe = new herfe();
            Herfe.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SabteKarmand sk = new SabteKarmand();
            sk.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mali mali = new Mali();
            mali.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Service service = new Service();
            service.Show();
        }

        private void Modiriyat_Load(object sender, EventArgs e)
        {

        }
    }
}
