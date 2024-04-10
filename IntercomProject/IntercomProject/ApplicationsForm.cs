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
            string query = "SELECT CONCAT(улица, ' д.', `номер дома`, ', п.', `номер подъезда`, ', кв.', `номер квартиры`) AS Адрес, " +
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
    }
}
