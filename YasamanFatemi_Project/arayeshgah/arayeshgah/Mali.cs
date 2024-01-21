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
    public partial class Mali : Form
    {
        public Mali()
        {
            InitializeComponent();
        }

        private void Mali_Load(object sender, EventArgs e)
        {
            int total = 0;
            int sod = 0;
            string l = "CODE KARMAND - DARSAD - DARAMAD - SODESHOMA - TOTAL";
            listBox1.Items.Add(l);
            string CS = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True";
            SqlConnection cn = new SqlConnection(CS);
            cn.Open();
            string query = $"select * from [dbo].[Mali]";
            SqlCommand cmd = new SqlCommand(query, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string Code = dr["CODE_Karmand"].ToString();
                string Darsad = dr["Darsad_Kar"].ToString();
                string Daramad = dr["Daramad"].ToString();
                string Sode_Shoma = dr["Sode_Shoma"].ToString();
                string Total = dr["Total"].ToString();
                total += int.Parse(Total);
                string Line = $"{Code},{Darsad},{Daramad},{Sode_Shoma},{Total}";
                listBox1.Items.Add(Line);
                comboBox1.Items.Add(Code);
            }
            dr.Close();
            cn.Close();
            label6.Text = total.ToString();
            foreach (string Item in listBox1.Items)
            {
                if (!Item.Contains('-'))
                {
                    string[] item = Item.Split(',');
                    int so = int.Parse(item[3]);
                    sod += so;
                }
            }
            label8.Text = sod.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string CS = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True";
            SqlConnection cn = new SqlConnection(CS);
            cn.Open();
            string Code = comboBox1.SelectedItem.ToString();
            string qurey = $"select Name,Family from [dbo].[Karmandan] where CODE={Code}";
            SqlCommand cmd = new SqlCommand(qurey, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                label1.Text = dr["Name"].ToString() + " " + dr["Family"].ToString();
            }
            dr.Close();
            string qurey2 = $"select Darsad_Kar,Daramad from [dbo].[Mali] where CODE_Karmand={Code}";
            SqlCommand cmd2 = new SqlCommand(qurey2, cn);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                label2.Text = dr2["Darsad_Kar"].ToString();
                label4.Text = dr2["Daramad"].ToString();
            }
            dr2.Close();
            cn.Close();
        }
    }
}
