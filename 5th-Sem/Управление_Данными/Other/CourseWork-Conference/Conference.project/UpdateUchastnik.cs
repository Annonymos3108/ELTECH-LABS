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
    public partial class UpdateUchastnik : Form
    {
        SqlConnection sqlConnection;
        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
                    @"C:\Users\arthu\source\repos\Conference\Conference.mdf;Integrated Security=True";
        public UpdateUchastnik()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
            if (!string.IsNullOrEmpty(id_участникTextBox.Text) && (checkBox1.Checked || 
                checkBox2.Checked  || checkBox4.Checked  || checkBox9.Checked || checkBox10.Checked || 
                checkBox8.Checked  || checkBox5.Checked  || checkBox3.Checked || checkBox7.Checked  ||
                checkBox13.Checked || checkBox6.Checked  || checkBox11.Checked))
            {
                //id автор
                if (checkBox1.Checked)
                {
                    string cmd = "UPDATE Участники SET id_автор = @id_автор WHERE id_участник = @id_участник";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("id_автор", textBox1.Text);
                    command.Parameters.AddWithValue("id_участник", id_участникTextBox.Text);

                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //id конференции
                if (checkBox2.Checked)
                {
                    string cmd = "UPDATE Участники SET id_конференция = @id_конференция WHERE id_участник = @id_участник";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("id_конференция", textBox2.Text);
                    command.Parameters.AddWithValue("id_участник", id_участникTextBox.Text);

                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //id гостиница
                if (checkBox4.Checked)
                {
                    if (checkBox13.Checked)
                    {
                        string cmd = "UPDATE Участники SET id_гостиница = @id_гостиница, " +
                            "Потребность_в_гостинице = @Потребность WHERE id_участник = @id_участник";
                        SqlCommand command = new SqlCommand(cmd, sqlConnection);
                        command.Parameters.AddWithValue("id_гостиница", textBox4.Text);
                        command.Parameters.AddWithValue("Потребность", checkBox14.Checked);
                        command.Parameters.AddWithValue("id_участник", id_участникTextBox.Text);

                        try
                        {
                            await command.ExecuteNonQueryAsync();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        string cmd2 = "UPDATE Участники SET id_гостиница = @id_гостиница WHERE id_участник = @id_участник";
                        SqlCommand command2 = new SqlCommand(cmd2, sqlConnection);
                        command2.Parameters.AddWithValue("id_гостиница", textBox4.Text);
                        command2.Parameters.AddWithValue("id_участник", id_участникTextBox.Text);

                        try
                        {
                            await command2.ExecuteNonQueryAsync();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                //размер орвзноса
                if (checkBox10.Checked)
                {
                    string cmd = "UPDATE Участники SET Размер_оргвзноса = @Размер_оргвзноса WHERE id_участник = @id_участник";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Размер_оргвзноса", textBox3.Text);
                    command.Parameters.AddWithValue("id_участник", id_участникTextBox.Text);

                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //потрбность в гостинице
                if (checkBox13.Checked)
                {
                    string cmd = "UPDATE Участники SET Потребность_в_гостинице = @Потребность WHERE id_участник = @id_участник";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Потребность", checkBox14.Checked);
                    command.Parameters.AddWithValue("id_участник", id_участникTextBox.Text);

                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                // докладчик/участник
                if (checkBox9.Checked)
                {
                    string cmd = "UPDATE Участники SET Докладчик_участник = @ДокладчикУчастник WHERE id_участник = @id_участник";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("ДокладчикУчастник", checkBox12.Checked);
                    command.Parameters.AddWithValue("id_участник", id_участникTextBox.Text);

                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //дата поступления оргвзноса
                if (checkBox5.Checked)
                {
                    string cmd = "UPDATE Участники SET Дата_поступления_оргвзноса = @Датавзноса WHERE id_участник = @id_участник";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Датавзноса", дата_началоDateTimePicker.Value);
                    command.Parameters.AddWithValue("id_участник", id_участникTextBox.Text);

                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //дата поступления заявки
                if (checkBox3.Checked)
                {
                    string cmd = "UPDATE Участники SET Дата_поступления_заявки = @Датазаявки WHERE id_участник = @id_участник";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Датазаявки", dateTimePicker1.Value);
                    command.Parameters.AddWithValue("id_участник", id_участникTextBox.Text);

                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //дата приезда
                if (checkBox7.Checked)
                {
                    string cmd = "UPDATE Участники SET Дата_приезда = @ДатазПриезда WHERE id_участник = @id_участник";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("ДатазПриезда", dateTimePicker3.Value);
                    command.Parameters.AddWithValue("id_участник", id_участникTextBox.Text);

                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //дата отъезда
                if (checkBox8.Checked)
                {
                    string cmd = "UPDATE Участники SET Дата_отезда = @ДатаОтъезда WHERE id_участник = @id_участник";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("ДатаОтъезда", dateTimePicker4.Value);
                    command.Parameters.AddWithValue("id_участник", id_участникTextBox.Text);

                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //дата 1ого приглашения
                if (checkBox6.Checked)
                {
                    string cmd = "UPDATE Участники SET Дата_рассылки_1_ого_приглашения = @Дата1огоПриглаш WHERE id_участник = @id_участник";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Дата1огоПриглаш", dateTimePicker2.Value);
                    command.Parameters.AddWithValue("id_участник", id_участникTextBox.Text);

                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //дата 2ого приглашения
                if (checkBox11.Checked)
                {
                    string cmd = "UPDATE Участники SET Дата_рассылки_2_ого_приглашения = @Дата2огоПриглаш WHERE id_участник = @id_участник";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Дата2огоПриглаш", dateTimePicker6.Value);
                    command.Parameters.AddWithValue("id_участник", id_участникTextBox.Text);

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
