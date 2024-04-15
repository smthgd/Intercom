using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntercomProject
{
    public partial class AddressesForm : Form
    {
        private static string connectionString = "server=127.0.0.1;port=3306;username=root;password=Chaplin-06-05-04-goldsteam-0;database=mydb";

        public AddressesForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            string query = "SELECT Районы.`Название района`, Адреса.Улица, Адреса.`Номер дома`, Подъезды.`Номер подъезда`, Квартиры.`Номер квартиры` FROM mydb.Адреса JOIN mydb.Районы ON Адреса.РайонID = Районы.idРайон JOIN mydb.Подъезды ON Адреса.idАдрес = Подъезды.АдресаID JOIN mydb.Квартиры ON Подъезды.idПодъезды = Квартиры.ПодъездID;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                dataGridView2.DataSource = dataTable;
                Controls.Add(dataGridView2);
            }
        }

        private void AddingButtonAdress_Click(object sender, EventArgs e)
        {

        }

        private void EdditingButtonAdress_Click(object sender, EventArgs e)
        {
            var form = new EditAddressesForm();

            string query = "";

            string editAddressDistrict = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            string editAddressStreet = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            string editAddressHouseNumber = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            string editAddressEntranceNumber = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            string editAddressApartmentNumber = dataGridView2.CurrentRow.Cells[4].Value.ToString();

            form.AddressDistrict = editAddressDistrict;
            form.AddressStreet = editAddressStreet;
            form.AddressHouseNumber = editAddressHouseNumber;
            form.AddressEntranceNumber = editAddressEntranceNumber;
            form.AddressApartmentNumber = editAddressApartmentNumber;

            if (form.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("OK");
            }
        }
    }
}
