using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace arayeshgah
{
    public partial class herfe : Form
    {
        public herfe()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int Code = int.Parse(textBox1.Text);
                string Name = textBox2.Text;

                string CS = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True";
                SqlConnection cn = new SqlConnection(CS);
                cn.Open();
                string Query = $"insert into [dbo].[Herfe](Code_Herfe,Name_Herfe) Values ('{Code}','{Name}')";
                SqlCommand cmd = new SqlCommand(Query, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Bamovafaghiyat sabt shod");
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
        }

        private void herfe_Load(object sender, EventArgs e)
        {

        }
    }
}
