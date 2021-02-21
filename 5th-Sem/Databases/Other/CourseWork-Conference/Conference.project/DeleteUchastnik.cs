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
    public partial class DeleteUchastnik : Form
    {
        SqlConnection sqlConnection;
        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
                    @"C:\Users\arthu\source\repos\Conference\Conference.mdf;Integrated Security=True";
        public DeleteUchastnik()
        {
            InitializeComponent();
        }

        //кнопка удаления участника
        private async void button1_Click(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                if (checkBox1.Checked)
                {
                    string cmd = "DELETE FROM Доклады WHERE id_участник=@id_участник";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("id_участник", textBox1.Text);

                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                string cmd2 = "DELETE FROM Участники WHERE id_участник=@id_участник";
                SqlCommand command2 = new SqlCommand(cmd2, sqlConnection);
                command2.Parameters.AddWithValue("id_участник", textBox1.Text);
                try
                {
                    await command2.ExecuteNonQueryAsync();
                    MessageBox.Show("Удалено!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка!\n\nПрежде чем удалить данные участника удалите данные его " +
                        "доклада во вкладке 'Доклады' или поставьте галочку 'Также удалить " +
                        "все данные о докладах данного участника'", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ошибка!\n\nПоле 'id_участника' должен быть заполнен.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            sqlConnection.Close();
        }
    }
}
