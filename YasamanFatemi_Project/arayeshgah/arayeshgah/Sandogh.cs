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
    public partial class Sandogh : Form
    {
        public Sandogh()
        {
            InitializeComponent();
        }
        string num = "";
        private void textBox1_Leave(object sender, EventArgs e)
        {
            string number = textBox1.Text;
            num = number;
            int i = 0;
            string[] line = new string[i+1];
            string CS = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True";
            SqlConnection cn = new SqlConnection(CS);
            cn.Open();
            string q = $"select Code_Sevice,Code_Karmand from [dbo].[Nobat] where Phone={number}";
            SqlCommand cmd = new SqlCommand(q, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string cservic = dr["Code_Sevice"].ToString();
                string ckarmand = dr["Code_Karmand"].ToString();
                line[i] = ckarmand+"-"+cservic ;
                i++;
            }
            dr.Close();
            for (int j = 0; j < line.Length; j++)
            {
                string lines = line[j];
                string cservic = lines.Split('-')[1];
                string q2 = $"select Name_Sevice,Mablaq from [dbo].[Service] where Code_Sevice={cservic}";
                SqlCommand cmd2 = new SqlCommand(q2, cn);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    string name = dr2["Name_Sevice"].ToString();
                    string mablagh = dr2["Mablaq"].ToString();
                    string khat = name+"-"+mablagh + "-" + line[j];
                    comboBox1.Items.Add(khat);
                }
                dr2.Close();

            }
            
            cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int DKar = 0;
            int Daramad = 0;
            int sShoma = 0;
            int total = 0;
            string line = comboBox1.SelectedItem.ToString();
            int money = int.Parse(textBox2.Text);
            string ckarmand = line.Split('-')[2];
            string cservic = line.Split('-')[3];
            string CS = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True";
            SqlConnection cn = new SqlConnection(CS);
            cn.Open();
            string q = $"select * from [dbo].[Mali] where CODE_Karmand={ckarmand}";
            SqlCommand command = new SqlCommand(q,cn);
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                 DKar = int.Parse(dr["Darsad_Kar"].ToString());
                 Daramad = int.Parse(dr["Daramad"].ToString());
                 sShoma = int.Parse(dr["Sode_Shoma"].ToString());
                 total = int.Parse(dr["Total"].ToString());
            }
            dr.Close();
            int sodshoma = (money / 100) * (100-DKar);
            int dar = money - sodshoma;
            Daramad += dar;
            sShoma += sodshoma;
            total += money;
            string q2 = $"update [dbo].[Mali] set Daramad={Daramad},Sode_Shoma={sShoma}, Total={total}";
            SqlCommand command2 = new SqlCommand(q2,cn);
            command2.ExecuteNonQuery();
            string q3 = $"delete from [dbo].[Nobat] where Phone={num}";
            SqlCommand cmd3 = new SqlCommand(q3,cn);
            cmd3.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Pardakht SHod");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string line = comboBox1.SelectedItem.ToString();
            string mablagh = line.Split('-')[1];
            textBox2.Text = mablagh;
        }

        private void Sandogh_Load(object sender, EventArgs e)
        {

        }
    }
}
