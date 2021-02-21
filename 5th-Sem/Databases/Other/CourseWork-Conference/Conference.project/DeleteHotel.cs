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
    public partial class DeleteHotel : Form
    {
        SqlConnection sqlConnection;
        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
                    @"C:\Users\arthu\source\repos\Conference\Conference.mdf;Integrated Security=True";
        public DeleteHotel()
        {
            InitializeComponent();
        }

        //кнопка удаления гостиницы
        private async void delbutton_Click(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                if (updChkBox.Checked)
                {
                    string searchId = "UPDATE Участники SET id_гостиница = null " +
                                       "WHERE  id_гостиница= @id_гостиница";
                    SqlCommand commandID = new SqlCommand(searchId, sqlConnection);
                    commandID.Parameters.AddWithValue("id_гостиница", textBox1.Text);
                    try
                    {
                        await commandID.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (forceDelChkBox.Checked)
                {
                    string cmd = "DELETE FROM Участники WHERE id_гостиница=@id_гостиница";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("id_гостиница", textBox1.Text);
                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                string cmd3 = "DELETE FROM Гостиницы WHERE id_гостиница=@id_гостиница";
                SqlCommand command3 = new SqlCommand(cmd3, sqlConnection);
                command3.Parameters.AddWithValue("id_гостиница", textBox1.Text);
                try
                {
                    await command3.ExecuteNonQueryAsync();
                    MessageBox.Show("Удалено!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ошибка!\n\nПоле 'id_гостиница' должен быть заполнен.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            sqlConnection.Close();
        }
    }
}
