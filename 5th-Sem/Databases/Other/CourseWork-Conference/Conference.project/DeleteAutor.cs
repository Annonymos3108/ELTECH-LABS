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
    public partial class DeleteAutor : Form
    {
        SqlConnection sqlConnection;
        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
                    @"C:\Users\arthu\source\repos\Conference\Conference.mdf;Integrated Security=True";
        public DeleteAutor()
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
                if (checkBox2.Checked)
                {
                    int id_uchast = 0;
                    string searchId = "SELECT id_участник, COUNT(id_участник) " +
                                        "FROM Участники " +
                                        "WHERE  id_автор= @id_автор " +
                                        "GROUP BY id_участник";
                    SqlCommand commandID = new SqlCommand(searchId, sqlConnection);
                    commandID.Parameters.AddWithValue("id_автор", textBox1.Text);
                    List<string[]> data = new List<string[]>();
                    try
                    {
                        SqlDataReader sqlDataReader = await commandID.ExecuteReaderAsync();
                        while (sqlDataReader.Read())
                        {
                            data.Add(new string[2]);
                            for (int i = 0; i < 2; i++)
                            {
                                data[data.Count - 1][i] = sqlDataReader[i].ToString();
                            }
                        }
                        sqlDataReader.Close();
                        if (data.Count != 0)
                        {
                            id_uchast = Convert.ToInt32(data[0][0].ToString());
                            string cmd = "DELETE FROM Доклады WHERE id_участник=@id_участник";
                            SqlCommand command = new SqlCommand(cmd, sqlConnection);
                            command.Parameters.AddWithValue("id_участник", id_uchast);
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
                            command3.Parameters.AddWithValue("id_участник", id_uchast);
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
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                string cmd2 = "DELETE FROM Авторы WHERE id_автор=@id_автор";
                SqlCommand command2 = new SqlCommand(cmd2, sqlConnection);
                command2.Parameters.AddWithValue("id_автор", textBox1.Text);
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
                        "или поставьте галочку 'Удалить все данные в базе связанные с этим автором, " + 
                        "включая участников и доклады'", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
