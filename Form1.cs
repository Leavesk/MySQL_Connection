using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        String connectionString = "server=127.0.0.1;user=root;database=mydb;SSLmode=None";
        
        public Form1()
        {
            InitializeComponent();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection cn = new MySqlConnection(connectionString))
            {
                cn.Open();
                string Marka = textBox1.Text;
                decimal Price = Convert.ToDecimal(textBox2.Text);
                string Color = textBox3.Text;
                string Model = textBox4.Text;
                int Count = Convert.ToInt32(textBox5.Text);
                string query = "INSERT INTO Avto(Color, Marka, Model, Price, Count) " +
                    "VALUES(@Color, @Marka, @Model, @Price, @Count)";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                MySqlParameter ColorParam = new MySqlParameter("@Color", Color);
                cmd.Parameters.Add(ColorParam);
                MySqlParameter nameParam = new MySqlParameter("@Marka", Marka);
                cmd.Parameters.Add(nameParam);
                MySqlParameter ModelParam = new MySqlParameter("@Model", Model);
                cmd.Parameters.Add(ModelParam);
                MySqlParameter priceParam = new MySqlParameter("@Price", Price);
                cmd.Parameters.Add(priceParam);
                MySqlParameter CountParam = new MySqlParameter("@Count", Count);
                cmd.Parameters.Add(CountParam);
                int CT = cmd.ExecuteNonQuery();
                string qy = "SELECT * FROM Avto";
                MySqlCommand cm = new MySqlCommand(qy, cn);
                MySqlDataReader reader = cm.ExecuteReader();

                while(reader.Read())
                {
                    richTextBox1.AppendText($"{reader[0]} \t " +
                                            $"{reader[1], -8} \t " +
                                            $"{reader[2], -8} \t " +
                                            $"{reader[3], -8} \t " );
                }
                reader.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection cn = new MySqlConnection(connectionString))
            {
                cn.Open();
                string qy = "SELECT * FROM Avto";
                MySqlCommand cm = new MySqlCommand(qy, cn);
                MySqlDataReader reader = cm.ExecuteReader();

                while (reader.Read())
                {
                    richTextBox1.AppendText($"{reader[0], +7} \t " +
                                            $"{reader[1],-7} \t " +
                                            $"{reader[2],-8} \t " +
                                            $"{reader[3],-10} \t " +
                                            $"{reader[4],-25} \t ");
                }
                reader.Close();
            }
        }
    }
}