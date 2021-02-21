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


namespace Conference
{
    public partial class TeseusDokladus : Form
    {
        SqlConnection sqlConnection;
        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
                    @"C:\Users\arthu\source\repos\Conference\Conference.mdf;Integrated Security=True";
        public TeseusDokladus(string gorod, string idConference)
        {
            InitializeComponent();
            Form_Load(gorod, idConference);
        }

        private async void Form_Load(string gorod, string idConference)
        {
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();

            //город название //вывод
            городlabel.Text = gorod;
            
            //название конференции
            string cmd = "SELECT Название FROM Конференции " +
                "WHERE id_конференция = @id_конференция";
            SqlCommand command = new SqlCommand(cmd, sqlConnection);
            command.Parameters.AddWithValue("id_конференция", idConference);

            try
            {
                SqlDataReader reader = command.ExecuteReader();

                List<string[]> data = new List<string[]>();
                while (reader.Read())
                {
                    data.Add(new string[1]);
                    data[data.Count - 1][0] = reader[0].ToString();
                }
                reader.Close();

                foreach (string[] s in data)
                    конференция.Text = "\"" + s[0].ToString() + "\"";
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //заполнение таблицы 
            string cmd2 = "SELECT Доклады.Тема_доклада " +
                            "FROM Доклады " +
                                "INNER JOIN (Участники INNER JOIN " +
                                                "(Авторы INNER JOIN Локация " +
                                                            "ON Авторы.id_локация = Локация.id_локация) " +
                                            "ON Участники.id_автор = Авторы.id_автор) " +
                                "ON Участники.id_участник = Доклады.id_участник " +
                            "WHERE(Локация.Город = @город AND Участники.id_конференция = @id_конференция)";
            SqlCommand command2 = new SqlCommand(cmd2, sqlConnection);
            command2.Parameters.AddWithValue("id_конференция", idConference);
            command2.Parameters.AddWithValue("город", gorod);

            try
            {
                SqlDataReader reader2 = command2.ExecuteReader();

                List<string[]> data2 = new List<string[]>();
                while (reader2.Read())
                {
                    data2.Add(new string[1]);
                    data2[data2.Count - 1][0] = reader2[0].ToString();
                }
                reader2.Close();

                foreach (string[] s in data2)
                    dataGridView1.Rows.Add(s);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
