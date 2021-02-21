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

namespace WindowsFormsAppFinal
{
    public partial class RaspisanieNaDen : Form
    {
        public RaspisanieNaDen(string den, string klass)
        {
            InitializeComponent();
            Form_Load(den, klass);
        }

        private async void Form_Load(string den, string klass)
        {
            деньlabel.Text = den;
            классlabel.Text = klass;
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\arthu\source\repos\WindowsFormsAppFinal\School1.mdf;Integrated Security=True";
            SqlConnection myConnection = new SqlConnection(connectionString);
            await myConnection.OpenAsync();
            string cmd = "SELECT Номер_урока, Предмет, Кабинет FROM Расписание WHERE (Класс=@Класс AND День=@День)";
            SqlCommand command = new SqlCommand(cmd, myConnection);
            command.Parameters.AddWithValue("Класс", klass);
            command.Parameters.AddWithValue("День", den);
           
            try
            {
                SqlDataReader reader = command.ExecuteReader();

                List<string[]> data = new List<string[]>();
                while (reader.Read())
                {
                    data.Add(new string[2]);

                    data[data.Count - 1][0] = reader[0].ToString();
                    data[data.Count - 1][1] = reader[1].ToString();
                }
                reader.Close();
                myConnection.Close();
                foreach (string[] s in data)
                    dataGridView1.Rows.Add(s);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
