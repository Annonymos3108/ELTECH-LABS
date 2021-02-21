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

namespace Avtopark
{
    public partial class VoditeliNeVodyat : Form
    {
        public VoditeliNeVodyat()
        {
            InitializeComponent();
            LoadData();

        }

        private async void LoadData()
        {
            string connectString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
                @"C:\winformsDB\Avtopark\Database1.mdf;Integrated Security=True";

            SqlConnection myConnection = new SqlConnection(connectString);

            myConnection.Open();

            string query = "SELECT* " +
                        "FROM [Водители] " +
                        "WHERE Водители.Паспорт NOT IN (SELECT Паспорт " +
                                                    "FROM Водят)";

            SqlCommand command = new SqlCommand(query, myConnection);

            try
            {
                SqlDataReader reader = await command.ExecuteReaderAsync();

                List<string[]> data = new List<string[]>();

                while (reader.Read())
                {
                    data.Add(new string[5]);

                    data[data.Count - 1][0] = reader[0].ToString();
                    data[data.Count - 1][1] = reader[1].ToString();
                    data[data.Count - 1][2] = reader[2].ToString();
                    data[data.Count - 1][3] = reader[3].ToString();
                    data[data.Count - 1][4] = reader[4].ToString();
                }

                reader.Close();

                myConnection.Close();

                foreach (string[] s in data)
                    dataGridView1.Rows.Add(s);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oшибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
