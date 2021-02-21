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
    public partial class PervoePriglashenie : Form
    {
        SqlConnection sqlConnection;
        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
                    @"C:\Users\arthu\source\repos\Conference\Conference.mdf;Integrated Security=True";
        public PervoePriglashenie(DateTime dateTime, string idConference)
        {
            InitializeComponent();
            Form_Load(dateTime, idConference);
        }

        private async void Form_Load(DateTime dateTime, string idConference)
        {
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();

            //для какой даты инфа о приглашенных //выводим
            датаLabel.Text = dateTime.ToString("yyyy-MM-dd");

            //заполнение таблицы Приглашенных
            string cmd2 = "SELECT Участники.id_участник, Авторы.Фамилия, Авторы.Имя, Авторы.Отчество " +
                "FROM Участники INNER JOIN Авторы ON Участники.id_автор = Авторы.id_автор " +
                "WHERE (Участники.Дата_рассылки_1_ого_приглашения = @Дата " +
                            "AND Участники.id_конференция = @id_конференция)";
            SqlCommand command2 = new SqlCommand(cmd2, sqlConnection);
            command2.Parameters.AddWithValue("Дата", dateTime.ToString("yyyy-MM-dd"));
            command2.Parameters.AddWithValue("id_конференция", idConference);

            try
            {
                SqlDataReader reader2 = command2.ExecuteReader();

                List<string[]> data2 = new List<string[]>();
                while (reader2.Read())
                {
                    data2.Add(new string[4]);
                    for (int i = 0; i < 4; i++)
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

            //подсчет количества приглашенных
            //заполнение таблицы Приглашенных
            string cmd = "SELECT COUNT(id_участник) FROM Участники " +
                "WHERE (id_конференция = @id_конференция " +
                        "AND Дата_рассылки_1_ого_приглашения = @Дата) " +
                "GROUP BY id_конференция";
            SqlCommand command = new SqlCommand(cmd, sqlConnection);
            command.Parameters.AddWithValue("Дата", dateTime.ToString("yyyy-MM-dd"));
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
                    количество.Text = s[0].ToString();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            sqlConnection.Close();
        }
    }
}
