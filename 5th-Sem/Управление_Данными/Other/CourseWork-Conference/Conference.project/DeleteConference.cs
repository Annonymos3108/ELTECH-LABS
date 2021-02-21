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
    public partial class DeleteConference : Form
    {
        SqlConnection sqlConnection;
        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
                    @"C:\Users\arthu\source\repos\Conference\Conference.mdf;Integrated Security=True";
        public DeleteConference()
        {
            InitializeComponent();
        }

        //кнопка удалить
        private async void button1_Click(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                if (checkBox1.Checked)
                {
                    string searchId = "SELECT id_участник " +
                                        "FROM Участники " +
                                        "WHERE  id_конференция= @id_конференция";
                    SqlCommand commandID = new SqlCommand(searchId, sqlConnection);
                    commandID.Parameters.AddWithValue("id_конференция", textBox1.Text);
                    List<string[]> data = new List<string[]>();
                    try
                    {
                        SqlDataReader sqlDataReader = await commandID.ExecuteReaderAsync();
                        while (sqlDataReader.Read())
                        {
                            data.Add(new string[1]);
                            data[data.Count - 1][0] = sqlDataReader[0].ToString();                         
                        }
                        sqlDataReader.Close();
                        if (data.Count != 0)
                        {
                            foreach (string[] item in data)
                            {

                                string cmd = "DELETE FROM Доклады WHERE id_участник=@id_участник";
                                SqlCommand command = new SqlCommand(cmd, sqlConnection);
                                command.Parameters.AddWithValue("id_участник", item[0].ToString());
                                try
                                {
                                    await command.ExecuteNonQueryAsync();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                string cmd3 = "DELETE FROM Участники WHERE id_участник=@id_участник";
                                SqlCommand command3 = new SqlCommand(cmd3, sqlConnection);
                                command3.Parameters.AddWithValue("id_участник", item[0].ToString());
                                try
                                {
                                    await command3.ExecuteNonQueryAsync();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                string cmd2 = "DELETE FROM Конференции WHERE id_конференция=@id_конференция";
                SqlCommand command2 = new SqlCommand(cmd2, sqlConnection);
                command2.Parameters.AddWithValue("id_конференция", textBox1.Text);
                try
                {
                    await command2.ExecuteNonQueryAsync();
                    MessageBox.Show("Удалено!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка!\n\nПрежде чем удалить данные участника удалите данные" +
                        "участника, связанного с ним, а также данные его " +
                        "доклада во вкладках 'Участник' и 'Доклады' соответственно " +
                        "или поставьте галочку 'Удалить данные всех зарегистрированных учатников и их " +
                        "докладов на эту конференцию'", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ошибка!\n\nПоле 'id_автор' должен быть заполнен.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            sqlConnection.Close();
        }
    }
}
