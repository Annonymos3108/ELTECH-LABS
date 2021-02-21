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
    public partial class UpdateAutor : Form
    {
        SqlConnection sqlConnection;
        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
                    @"C:\Users\arthu\source\repos\Conference\Conference.mdf;Integrated Security=True";
        public UpdateAutor()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();

            if (!string.IsNullOrEmpty(id_авторTextBox.Text) && (checkBox1.Checked ||
                checkBox2.Checked || checkBox3.Checked || checkBox4.Checked || checkBox15.Checked ||
                checkBox6.Checked || checkBox7.Checked || checkBox8.Checked || checkBox9.Checked ||
                checkBox10.Checked || checkBox11.Checked || checkBox12.Checked || checkBox13.Checked ||
                checkBox14.Checked))
            {
                //Фамилия
                if (checkBox1.Checked)
                {
                    string cmd = "UPDATE Авторы SET Фамилия=@Фамилия WHERE id_автор = @id_автор";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Фамилия", textBox1.Text);
                    command.Parameters.AddWithValue("id_автор", id_авторTextBox.Text);
                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //Имя
                if (checkBox2.Checked)
                {
                    string cmd = "UPDATE Авторы SET Имя=@Имя WHERE id_автор = @id_автор";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Имя", textBox2.Text);
                    command.Parameters.AddWithValue("id_автор", id_авторTextBox.Text);
                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //Отчество
                if (checkBox3.Checked)
                {
                    string cmd = "UPDATE Авторы SET Отчество=@Отчество WHERE id_автор = @id_автор";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Отчество", textBox3.Text);
                    command.Parameters.AddWithValue("id_автор", id_авторTextBox.Text);
                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //Адрес
                if (checkBox4.Checked)
                {
                    string cmd = "UPDATE Авторы SET Адрес=@Адрес WHERE id_автор = @id_автор";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Адрес", textBox4.Text);
                    command.Parameters.AddWithValue("id_автор", id_авторTextBox.Text);
                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //Почтовой индекс
                if (checkBox6.Checked)
                {
                    string cmd = "UPDATE Авторы SET Почтовой_индекс=@Почтовой_индекс WHERE id_автор = @id_автор";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Почтовой_индекс", textBox5.Text);
                    command.Parameters.AddWithValue("id_автор", id_авторTextBox.Text);
                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
               
                //рабочий телефон
                if (checkBox7.Checked)
                {
                    string cmd = "UPDATE Авторы SET Рабочий_телефон=@Рабочий_телефон WHERE id_автор = @id_автор";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Рабочий_телефон", textBox6.Text);
                    command.Parameters.AddWithValue("id_автор", id_авторTextBox.Text);
                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //Домашний телефон
                if (checkBox8.Checked)
                {
                    string cmd = "UPDATE Авторы SET Домашний_телефон=@Домашний_телефон WHERE id_автор = @id_автор";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Домашний_телефон", textBox7.Text);
                    command.Parameters.AddWithValue("id_автор", id_авторTextBox.Text);
                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //е-mail
                if (checkBox9.Checked)
                {
                    string cmd = "UPDATE Авторы SET e_mail=@e_mail WHERE id_автор = @id_автор";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("e_mail", textBox8.Text);
                    command.Parameters.AddWithValue("id_автор", id_авторTextBox.Text);
                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //ученая степень
                if (checkBox10.Checked)
                {
                    string cmd = "UPDATE Авторы SET Ученая_степень=@Ученая_степень WHERE id_автор = @id_автор";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Ученая_степень", textBox9.Text);
                    command.Parameters.AddWithValue("id_автор", id_авторTextBox.Text);
                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //ученое звание
                if (checkBox11.Checked)
                {
                    string cmd = "UPDATE Авторы SET Ученое_звание=@Ученое_звание WHERE id_автор = @id_автор";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Ученое_звание", textBox10.Text);
                    command.Parameters.AddWithValue("id_автор", id_авторTextBox.Text);
                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //научное направление
                if (checkBox12.Checked)
                {
                    string cmd = "UPDATE Авторы SET Научное_направлвние=@Научное_направлвние WHERE id_автор = @id_автор";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Научное_направлвние", textBox11.Text);
                    command.Parameters.AddWithValue("id_автор", id_авторTextBox.Text);
                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //кафедра
                if (checkBox13.Checked)
                {
                    string cmd = "UPDATE Авторы SET Кафедра=@Кафедра WHERE id_автор = @id_автор";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Кафедра", textBox12.Text);
                    command.Parameters.AddWithValue("id_автор", id_авторTextBox.Text);
                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //место работы
                if (checkBox14.Checked)
                {
                    string cmd = "UPDATE Авторы SET Место_работы=@Место_работы WHERE id_автор = @id_автор";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Место_работы", textBox13.Text);
                    command.Parameters.AddWithValue("id_автор", id_авторTextBox.Text);
                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //должность
                if (checkBox15.Checked)
                {
                    string cmd = "UPDATE Авторы SET Должность=@Должность WHERE id_автор = @id_автор";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Должность", textBox14.Text);
                    command.Parameters.AddWithValue("id_автор", id_авторTextBox.Text);
                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }     
            }
            sqlConnection.Close();
            MessageBox.Show("Данные успешно изменени!\n\n", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
