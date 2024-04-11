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
using MySql.Data.MySqlClient;

namespace IntercomProject
{
    public partial class ApplicationsForm : Form
    {
        private static string connectionString = "server=127.0.0.1;port=3306;username=root;password=Chaplin-06-05-04-goldsteam-0;database=mydb";

        public ApplicationsForm()
        {
            InitializeComponent();
            LoadData(); 
        }

        private void LoadData()
        {
            string query = "SELECT Заявки.idЗаявки, CONCAT(улица, ' д.', `номер дома`, ', п.', `номер подъезда`, ', кв.', `номер квартиры`) AS Адрес, " +
                           "заявки.`Текст заявки`, заявки.`Дата обслуживания`, CONCAT(сотрудники.Фамилия, ' ', LEFT(сотрудники.Имя, 1), '.', " +
                           "LEFT(сотрудники.Отчество, 1), '.') AS Исполнитель, заявки.Приоритет, заявки.`Дата выполнения` FROM mydb.адреса " +
                           "JOIN mydb.подъезды ON mydb.адреса.idАдрес = mydb.подъезды.АдресаID " +
                           "JOIN mydb.квартиры ON mydb.подъезды.idПодъезды = mydb.квартиры.ПодъездID " +
                           "JOIN mydb.заявки ON mydb.адреса.idАдрес = mydb.заявки.РайонID " +
                           "JOIN mydb.районы ON mydb.районы.idРайон = mydb.заявки.РайонID " +
                           "JOIN mydb.сотрудники ON mydb.заявки.idЗаявки = mydb.заявки.СотрудникиID;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
                Controls.Add(dataGridView1);
            }
        }

        private void EdditingButton_Click(object sender, EventArgs e)
        {
            var form = new EditApplicationsForm();

            string query = "SELECT `Дата приема`, Примечания, CONCAT(Пользователи.Фамилия, ' ', LEFT(Пользователи.Имя, 1), '.', " +
                           "LEFT(Пользователи.Отчество, 1), '.') AS Пользователь FROM mydb.Заявки " +
                           $"JOIN mydb.Пользователи ON mydb.Пользователи.idПользователи = mydb.Заявки.ПользователиID " +
                           $"WHERE idЗаявки = {dataGridView1.CurrentRow.Cells[0].Value};";

            string[] address = dataGridView1.CurrentRow.Cells[1].Value.ToString().Split('.');
            address[0] = address[0].Substring(0, address[0].Length - 2);
            address[1] = address[1].Substring(0, address[1].Length - 3);
            address[2] = address[2].Substring(0, address[2].Length - 4);

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue($"{dataGridView1.CurrentRow.Cells[0].Value}", dataGridView1.CurrentRow.Cells[0].Value.ToString());

                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    dataReader.Read();

                    form.ApplicationDate = dataReader["Дата приема"].ToString();
                    form.ApplicationUser = dataReader["Пользователь"].ToString();
                    form.ApplicationNotes = dataReader["Примечания"].ToString();
                }
            }

            string editApplicationStreet = address[0];
            string editApplicationHouseNumber = address[1];
            string editApplicationEntranceNumber = address[2];
            string editApplicationApartmentNumber = address[3];
            string editApplicationText = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string editApplicationServiceDate = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            string editApplicationEmployeeName = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            string editApplicationPriority = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            form.ApplicationStreet = editApplicationStreet;
            form.ApplicationHouseNumber = editApplicationHouseNumber;
            form.ApplicationEntranceNumber = editApplicationEntranceNumber;
            form.ApplicationApartmentNumber = editApplicationApartmentNumber;
            form.ApplicationText = editApplicationText;
            form.ApplicationServiceDate = editApplicationServiceDate;
            form.ApplicationEmployeeName = editApplicationEmployeeName;
            form.ApplicationPriority = editApplicationPriority;

            if (form.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("OK");
            }
        }
    }
}
