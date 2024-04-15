﻿using MySql.Data.MySqlClient;
using System;
using System.Collections;
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

            string idQuery = "SELECT Районы.idРайон, Адреса.idАдрес, Подъезды.idПодъезды, Квартиры.idКвартиры FROM mydb.Адреса JOIN mydb.Районы ON Адреса.РайонID = Районы.idРайон JOIN mydb.Подъезды ON Адреса.idАдрес = Подъезды.АдресаID JOIN mydb.Квартиры ON Подъезды.idПодъезды = Квартиры.ПодъездID;";
            string updateQuery = "UPDATE mydb.Адреса SET Улица = @StreetName, `Номер дома` = @HouseNumber WHERE idАдрес = @AddressId; " +
                           "UPDATE mydb.Районы SET `Название района` = @District WHERE idРайон = @DistrictId; " +
                           "UPDATE mydb.Подъезды SET `Номер подъезда` = @EntranceNumber WHERE idПодъезды = @EntranceId; " +
                           "UPDATE mydb.Квартиры SET `Номер квартиры` = @ApartmentNumber WHERE idКвартиры = @ApartmentId;";

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
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(idQuery, connection);

                    int distridId;
                    int addressId;
                    int entranceId;
                    int apartmentId;

                    using (MySqlDataReader dataReader = command.ExecuteReader())
                    {
                        dataReader.Read();

                        distridId = Convert.ToInt32(dataReader["idРайон"]);
                        addressId = Convert.ToInt32(dataReader["idАдрес"]);
                        entranceId = Convert.ToInt32(dataReader["idПодъезды"]);
                        apartmentId = Convert.ToInt32(dataReader["idКвартиры"]);
                    }

                    command = new MySqlCommand(updateQuery, connection);

                    command.Parameters.AddWithValue("@AddressId", addressId);
                    command.Parameters.AddWithValue("@DistrictId", distridId);
                    command.Parameters.AddWithValue("@EntranceId", entranceId);
                    command.Parameters.AddWithValue("@ApartmentId", apartmentId);
                    command.Parameters.AddWithValue("@StreetName", form.AddressStreet);
                    command.Parameters.AddWithValue("@HouseNumber", form.AddressHouseNumber);
                    command.Parameters.AddWithValue("@District", form.AddressDistrict);
                    command.Parameters.AddWithValue("@EntranceNumber", form.AddressEntranceNumber);
                    command.Parameters.AddWithValue("@ApartmentNumber", form.AddressApartmentNumber);

                    command.ExecuteNonQuery();

                    LoadData();
                }
            }
        }
    }
}
