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
    public partial class UpdateDoklad : Form
    {
        SqlConnection sqlConnection;
        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
                    @"C:\Users\arthu\source\repos\Conference\Conference.mdf;Integrated Security=True";
        public UpdateDoklad()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();

            if (!string.IsNullOrEmpty(id_TextBox.Text) && (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked || checkBox4.Checked))
            {
                if (checkBox2.Checked)
                {
                    string cmd = "UPDATE Доклады SET Тема_доклада = @Тема_доклада WHERE id_участник = @id_участник";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Тема_доклада", textBox2.Text);
                    command.Parameters.AddWithValue("id_участник", id_TextBox.Text);

                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (checkBox1.Checked)
                {
                    string cmd = "UPDATE Доклады SET Количество_страниц = @Количество_страниц WHERE id_участник = @id_участник";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Количество_страниц", textBox1.Text);
                    command.Parameters.AddWithValue("id_участник", id_TextBox.Text);

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
                    string cmd = "UPDATE Доклады SET Отметка_о_поступлении_тезисов = @Отметка WHERE id_участник = @id_участник";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Отметка", checkBox5.Checked);
                    command.Parameters.AddWithValue("id_участник", id_TextBox.Text);

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
                    string cmd = "UPDATE Доклады SET Соавторы = @Соавторы WHERE id_участник = @id_участник";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Соавторы", textBox3.Text);
                    command.Parameters.AddWithValue("id_участник", id_TextBox.Text);

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



            sqlConnection.Close();
        }
    }
}
