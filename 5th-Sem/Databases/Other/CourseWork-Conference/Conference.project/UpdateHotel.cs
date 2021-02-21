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
    public partial class UpdateHotel : Form
    {
        SqlConnection sqlConnection;
        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
                    @"C:\Users\arthu\source\repos\Conference\Conference.mdf;Integrated Security=True";
        public UpdateHotel()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();

            if (checkBox1.Checked || checkBox4.Checked || checkBox5.Checked)
            {
                if (checkBox1.Checked)
                {
                    string cmd = "UPDATE Гостиницы SET Название = @Название WHERE id_гостиница = @id_гостиница";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Название", textBox4.Text);
                    command.Parameters.AddWithValue("id_гостиница", id_hotelTextBox.Text);

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
                    string cmd = "UPDATE Гостиницы SET Адрес = @Адрес WHERE id_гостиница = @id_гостиница";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Адрес", textBox3.Text);
                    command.Parameters.AddWithValue("id_гостиница", id_hotelTextBox.Text);

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
                    string cmd = "UPDATE Гостиницы SET Стоимость_номера = @Стоимость_номера WHERE id_гостиница = @id_гостиница";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Стоимость_номера", textBox5.Text);
                    command.Parameters.AddWithValue("id_гостиница", id_hotelTextBox.Text);

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
