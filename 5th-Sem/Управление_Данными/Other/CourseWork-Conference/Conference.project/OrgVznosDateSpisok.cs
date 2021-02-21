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
    public partial class OrgVznosDateSpisok : Form
    {
        SqlConnection sqlConnection;
        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
                    @"C:\Users\arthu\source\repos\Conference\Conference.mdf;Integrated Security=True";
        public OrgVznosDateSpisok(string idConference)
        {
            InitializeComponent();
            Form_load(idConference);
        }

        private async void Form_load(string idConference)
        {
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();

            //название конференции //выводим
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
            string cmd2 = "SELECT Участники.id_участник, Авторы.Фамилия, Авторы.Имя, " +
                "Авторы.Отчество, Участники.Дата_поступления_оргвзноса " +
                "FROM  Участники INNER JOIN Авторы ON Участники.id_автор = Авторы.id_автор " +
                "WHERE Участники.id_конференция = @id_конференция";
            SqlCommand command2 = new SqlCommand(cmd2, sqlConnection);
            command2.Parameters.AddWithValue("id_конференция", idConference);

            try
            {
                SqlDataReader reader2 = command2.ExecuteReader();

                List<string[]> data2 = new List<string[]>();
                while (reader2.Read())
                {
                    data2.Add(new string[5]);
                    for (int i = 0; i < 5; i++)
                        data2[data2.Count - 1][i] = reader2[i].ToString();
                }
                reader2.Close();

                foreach (string[] s in data2)
                    dataGridView1.Rows.Add(s);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            sqlConnection.Close();
        }
    }
}
