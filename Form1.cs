using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace PhoneInfoBookTRPO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Main();
        }

        private void Main()
        {
            using (SqlConnection cn = new SqlConnection())
            {
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AllowUserToAddRows = false;

                cn.ConnectionString = @"Data Source=MMVL015\SQLEXPRESS;Initial Catalog=PhoneInfo_db;" +
                    "Integrated Security=SSPI;Pooling=False";
                try
                {
                    cn.Open();
                    //string strSQL = "SELECT * FROM Users";
                    //SqlCommand myCommand = new SqlCommand(strSQL, cn);
                    //SqlDataReader dr = myCommand.ExecuteReader();
                    //SqlDataAdapter adapter = new SqlDataAdapter(strSQL, cn);

                    //DataSet ds = new DataSet();
                    //adapter.Fill(ds);
                    //dataGridView1.DataSource = ds.Tables[0];

                    string strSQL = "SELECT * FROM Users";
                    SqlCommand myCommand = new SqlCommand(strSQL, cn);
                    SqlDataReader dr = myCommand.ExecuteReader();
                    while (dr.Read())
                    {
                        TBConsole.Text += String.Format(@" {0} : {1}" + "\r\n", dr[0], dr[1]);
                        dataGridView1.Rows.Add(dr[0], dr[1]);
                    }


                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    cn.Close();
                }
               
            }
        }

    }
}
