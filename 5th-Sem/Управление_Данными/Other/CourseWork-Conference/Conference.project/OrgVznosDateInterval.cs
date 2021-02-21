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
    public partial class OrgVznosDateInterval : Form
    {
        SqlConnection sqlConnection;
        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
                    @"C:\Users\arthu\source\repos\Conference\Conference.mdf;Integrated Security=True";
        public OrgVznosDateInterval(string idConference, DateTime from, DateTime to)
        {
            InitializeComponent();
            FormLoad(idConference, from, to);
        }

        private async void FormLoad(string idConference, DateTime from, DateTime to)
        {
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();

            //даты "с" и "до" //вывод
            fromlabel.Text= from.ToString("yyyy-MM-dd");
            tolabel.Text = to.ToString("yyyy-MM-dd");

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
            string cmd2 = "SELECT Участники.id_участник, Авторы.Фамилия, Авторы.Имя, " +
                "Авторы.Отчество, Участники.Дата_поступления_оргвзноса " +
                "FROM  Участники INNER JOIN Авторы ON Участники.id_автор = Авторы.id_автор " +
                "WHERE (Участники.id_конференция = @id_конференция " +
                        "AND (Дата_поступления_оргвзноса BETWEEN @fromdate AND @todate))";
            SqlCommand command2 = new SqlCommand(cmd2, sqlConnection);
            command2.Parameters.AddWithValue("id_конференция", idConference);
            command2.Parameters.AddWithValue("fromdate", from.ToString("yyyy-MM-dd"));
            command2.Parameters.AddWithValue("todate", to.ToString("yyyy-MM-dd"));

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
