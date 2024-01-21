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
    public partial class SabteKarmand : Form
    {
        public SabteKarmand()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

                string name = textBox1.Text;
                string family = textBox2.Text;
                string address = textBox3.Text;
                string Phone = textBox4.Text;
                string email = textBox5.Text;
                string sh = textBox6.Text;
                string herfe = comboBox1.SelectedItem.ToString();
                int Code = int.Parse(textBox7.Text);
                string precent = comboBox2.SelectedItem.ToString();
                int pre = int.Parse(precent);
                string H_Code = herfe.Split('-')[0];
                string CS = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True";
                SqlConnection cn = new SqlConnection(CS);
                cn.Open();
                string Query = $"insert into [dbo].[Karmandan](Name,Family,Address,Phone,Email,ShomareHesab,Code_Herfe,CODE) values ('{name}','{family}','{address}','{Phone}','{email}','{sh}','{H_Code}','{Code}')";
                string Query2 = $"insert into [dbo].[Mali](CODE_Karmand,Darsad_Kar) values ({Code},{pre})";
                SqlCommand cmd2 = new SqlCommand(Query2, cn);
                cmd2.ExecuteNonQuery();
                SqlCommand cmd = new SqlCommand(Query, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Succeced");

        }

        private void SabteKarmand_Load(object sender, EventArgs e)
        {
            string CS = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True";
            SqlConnection cn = new SqlConnection(CS);
            cn.Open();
            string Query = "select * from [dbo].[Herfe]";
            SqlCommand cmd = new SqlCommand(Query, cn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string item = reader["Code_Herfe"].ToString() + "-" + reader["Name_Herfe"].ToString();
                comboBox1.Items.Add(item);

            }
            reader.Close();
            cmd.Dispose();
            cn.Close();
            int[] precent = { 40, 50, 60, 70, 80, 90 };
            for (int i = 0; i < precent.Length; i++)
            {
                comboBox2.Items.Add(precent[i]);
            }

        }
    }
}
