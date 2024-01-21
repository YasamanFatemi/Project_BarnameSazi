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
    public partial class SabtNobat : Form
    {
        public SabtNobat()
        {
            InitializeComponent();
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string line = comboBox1.SelectedItem.ToString();
            string[] cs = line.Split('-');
            string CH = "";
            string CS = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True";
            SqlConnection cn = new SqlConnection(CS);
            cn.Open();
            string query = $"select Code_herfe from [dbo].[Service] where Code_Sevice={cs[1]}";
            SqlCommand cmd = new SqlCommand(query, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CH = dr["Code_herfe"].ToString();
            }
            dr.Close();
            string query2 = $"select Name,Family,CODE from [dbo].[Karmandan] where Code_Herfe={CH}";
            SqlCommand cmd2 = new SqlCommand(query2, cn);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                string Line = dr2["Name"].ToString() + "-"+ dr2["Family"].ToString() +"-"+ dr2["CODE"].ToString() ;
                comboBox2.Items.Add(Line);
            }
            dr2.Close();
            cn.Close();

        }

        private void SabtNobat_Load(object sender, EventArgs e)
        {
            string CS = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True";
            SqlConnection cn = new SqlConnection(CS);
            cn.Open();
            string query = $"select * from [dbo].[Service]";
            SqlCommand cmd = new SqlCommand(query, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string Name = dr["Name_Sevice"].ToString();
                string code = dr["Code_Sevice"].ToString();
                string line = Name + "-" + code;
                comboBox1.Items.Add(line);
            }
            dr.Close();
            cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string family = textBox2.Text;
            string phone = textBox3.Text;
            string saat = textBox4.Text;
            string date = textBox5.Text;
            string service = comboBox1.Text;
            string karmand = comboBox2.Text;
            string serviscode = service.Split('-')[1];
            string codekarmand = karmand.Split('-')[2];
            string CS = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename|DataDirectory|Database1.mdf;Integrated Security=True";
            SqlConnection cn = new SqlConnection(CS);
            cn.Open();
            string q = $"insert into [dbo].[Nobat](Name,Family,Code_Karmand,Saat,Date,Phone,Code_Sevice)values ('{name}','{family}','{codekarmand}','{saat }','{date}','{phone}','{serviscode}')";
            SqlCommand cmd = new SqlCommand(q, cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Nobat sabt shod");

        }
    }
}
