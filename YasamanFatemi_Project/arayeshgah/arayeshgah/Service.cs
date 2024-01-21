using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arayeshgah
{
    public partial class Service : Form
    {
        public Service()
        {
            InitializeComponent();
        }

        private void Service_Load(object sender, EventArgs e)
        {
            string CS = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True";
            SqlConnection cn = new SqlConnection(CS);
            cn.Open();
            string query = $"select * from [dbo].[Herfe]";
            SqlCommand cmd = new SqlCommand(query, cn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string code = reader["Code_Herfe"].ToString();
                string Name = reader["Name_Herfe"].ToString();
                string line = code + "-" + Name;
                comboBox1.Items.Add(line);
            }
            reader.Close();
            cn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string CodeService = textBox2.Text;
            string Gheymat = textBox3.Text;
            string herfe = comboBox1.SelectedItem.ToString();
            string[] Code_herfe = herfe.Split('-');
            string CS = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True";
            SqlConnection cn = new SqlConnection(CS);
            cn.Open();
            string query =$"insert into[dbo].[Service] (Code_Sevice,Name_Sevice, Mablaq, Code_herfe) values('{CodeService}','{name}','{Gheymat}','{Code_herfe[0]}')";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show($"service {name} added");

        }
    }
}
