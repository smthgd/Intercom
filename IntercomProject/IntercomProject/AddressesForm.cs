using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        private static string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

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
            var form = new EditAddressesForm();

            string insertQuery = "INSERT INTO mydb.Квартиры (`Номер квартиры`, `Дата первого начисления`, `Номер договора`, " +
                                 "`Обслуживание приостановлено`, ПодъездID, `Тип участияID`, ТрубкиID, МониторыID) " +
                                 "VALUES (@ApartmentNumber, @CurrentDate, @ContractNumber, 0, @EntranceNumber, 1, 1, 1);";
            string additionalQuery = "SELECT MAX(idКвартиры) FROM mydb.Квартиры";

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                if (form.ShowDialog() == DialogResult.OK)
                {
                    MySqlCommand command = new MySqlCommand(insertQuery, connection);
                    MySqlCommand additionalCommand = new MySqlCommand(additionalQuery, connection);


                    DateTime currentDate = DateTime.Now;
                    string formattedDate = currentDate.ToString("yyyy-MM-dd");
                    string apartmentNumber = form.AddressApartmentNumber;
                    string entranceNumber = form.AddressEntranceNumber;

                    command.Parameters.AddWithValue("@ApartmentNumber", apartmentNumber);
                    command.Parameters.AddWithValue("@CurrentDate", formattedDate);
                    command.Parameters.AddWithValue("@ContractNumber", Convert.ToInt32(additionalCommand.ExecuteScalar()) + 1);
                    command.Parameters.AddWithValue("@EntranceNumber", entranceNumber);
                    command.ExecuteNonQuery();

                    LoadData();
                }
            }
        }

        private void EdditingButtonAdress_Click(object sender, EventArgs e)
        {
            var form = new EditAddressesForm();

            string idQuery = "SELECT Районы.idРайон, Адреса.idАдрес, Подъезды.idПодъезды, Квартиры.idКвартиры FROM mydb.Адреса " +
                             "JOIN mydb.Районы ON Адреса.РайонID = Районы.idРайон JOIN mydb.Подъезды ON Адреса.idАдрес = Подъезды.АдресаID " +
                             "JOIN mydb.Квартиры ON Подъезды.idПодъезды = Квартиры.ПодъездID;";
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

        private void DeletingButtonAdress_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            if (clickedButton.Name == "DeletingButtonAdress")
            {
                if (dataGridView2.CurrentRow != null)
                {
                    DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить выбранную квартиру?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        int idApartmentToDelete = Convert.ToInt32(dataGridView2.CurrentRow.Cells[4].Value);

                        string queryDeleteApplications = "DELETE FROM mydb.Заявки WHERE КвартираID = @ID";
                        string queryDeleteApartment = "DELETE FROM mydb.Квартиры WHERE idквартиры = @ID";

                        using (MySqlConnection connection = new MySqlConnection(connectionString))
                        {
                            connection.Open();

                            using (MySqlCommand commandDeleteApplications = new MySqlCommand(queryDeleteApplications, connection))
                            {
                                commandDeleteApplications.Parameters.AddWithValue("@ID", idApartmentToDelete);
                                commandDeleteApplications.ExecuteNonQuery();
                            }

                            using (MySqlCommand commandDeleteApartment = new MySqlCommand(queryDeleteApartment, connection))
                            {
                                commandDeleteApartment.Parameters.AddWithValue("@ID", idApartmentToDelete);
                                commandDeleteApartment.ExecuteNonQuery();
                            }
                        }
                    }

                    LoadData();
                }
            }
        }

        private void MoreButtonAdress_Click(object sender, EventArgs e)
        {
            MoreAdressApplicationsForm moreadressForm = new MoreAdressApplicationsForm();
            moreadressForm.Show();

            string query = "SELECT Абоненты.Фамилия, Абоненты.Имя, Абоненты.Отчество, Абоненты.`Номер телефона`, Абоненты.`Электронная почта`," +
                "Квартиры.`Номер договора`, `Тип участия`.Тариф, Подъезды.Защита, Подъезды.Камера " +
                "FROM Квартиры " +
                "JOIN Абоненты ON idКвартиры = Абоненты.КвартираID " +
                "JOIN `Тип участия` ON Квартиры.`Тип участияID` = `idТип участия` " +
                "JOIN Подъезды ON Квартиры.ПодъездID = idПодъезды " +
                "WHERE idКвартиры = @ApplicationId;";

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@ApplicationId", dataGridView2.CurrentRow.Cells[4].Value.ToString());

                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    dataReader.Read();

                    string clientSurname = dataReader["Фамилия"].ToString();
                    string clientName = dataReader["Имя"].ToString();
                    string clientSecondName = dataReader["Отчество"].ToString();
                    string clientTelephoneNumber = dataReader["Номер телефона"].ToString();
                    string clientEmail = dataReader["Электронная почта"].ToString();
                    string contractNumber = dataReader["Номер договора"].ToString();
                    string tarifPlan = dataReader["Тариф"].ToString();
                    string protection = dataReader["Защита"].ToString();
                    string camera = dataReader["Камера"].ToString();

                    moreadressForm.ApplicationClientSurnameAdress = clientSurname;
                    moreadressForm.ApplicationClientNameAdress = clientName;
                    moreadressForm.ApplicationClientSecondNameAdress = clientSecondName;
                    moreadressForm.ApplicationTelephoneNumberAdress = clientTelephoneNumber;
                    moreadressForm.ApplicationEmailAdress = clientEmail;
                    moreadressForm.ApplicationContractNumber = contractNumber;
                    moreadressForm.ApplicationClientProtectionAdress = protection;
                    moreadressForm.ApplicationClientCameraAdress = camera;
                    moreadressForm.ApplicationTypeAdress = tarifPlan;
                }
            }
        }
    }
}
