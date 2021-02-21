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
    public partial class UpdateConference : Form
    {
        SqlConnection sqlConnection;
        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
                    @"C:\Users\arthu\source\repos\Conference\Conference.mdf;Integrated Security=True";
        public UpdateConference()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();

            if (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked || checkBox4.Checked || checkBox5.Checked)
            {
                if (checkBox1.Checked)
                {
                    string cmd = "UPDATE Конференции SET Название = @Название WHERE id_конференция = @id_конференция";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Название", textBox1.Text);
                    command.Parameters.AddWithValue("id_конференция", id_конференцияTextBox.Text);

                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (checkBox2.Checked)
                {
                    string cmd = "UPDATE Конференции SET Организатор = @Организатор WHERE id_конференция = @id_конференция";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Организатор", textBox2.Text);
                    command.Parameters.AddWithValue("id_конференция", id_конференцияTextBox.Text);

                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (checkBox3.Checked)
                {
                    string cmd = "UPDATE Конференции SET Статус = @Статус WHERE id_конференция = @id_конференция";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Статус", textBox3.Text);
                    command.Parameters.AddWithValue("id_конференция", id_конференцияTextBox.Text);

                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (checkBox4.Checked)
                {
                    string cmd = "UPDATE Конференции SET Оргвзнос = @Оргвзнос WHERE id_конференция = @id_конференция";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Оргвзнос", textBox4.Text);
                    command.Parameters.AddWithValue("id_конференция", id_конференцияTextBox.Text);

                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (checkBox5.Checked)
                {
                    string cmd = "UPDATE Конференции SET Дата_начало = @Дата_начало WHERE id_конференция = @id_конференция";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Дата_начало", дата_началоDateTimePicker.Value);
                    command.Parameters.AddWithValue("id_конференция", id_конференцияTextBox.Text);

                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                sqlConnection.Close();
                MessageBox.Show("Данные успешно изменени!\n\n", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            
        }
    }
}
