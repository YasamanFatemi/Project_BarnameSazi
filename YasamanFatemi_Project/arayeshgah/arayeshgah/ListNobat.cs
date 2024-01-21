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
    public partial class ListNobat : Form
    {
        public ListNobat()
        {
            InitializeComponent();
        }

        private void ListNobat_Load(object sender, EventArgs e)
        {
            string CS = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True";
            SqlConnection cn = new SqlConnection(CS);
            cn.Open();
            string query = $"select * from [dbo].[Nobat]";
            SqlCommand cmd = new SqlCommand(query,cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string line = dr["Name"].ToString() + "-" + dr["Family"].ToString() + "-" + dr["Saat"].ToString() + "-" + dr["Date"] + "-" + dr["Code_Karmand"].ToString() + dr["Code_Sevice"].ToString();
                listBox1.Items.Add(line);
            }
            dr.Close();
            cn.Close();
        }
    }
}
