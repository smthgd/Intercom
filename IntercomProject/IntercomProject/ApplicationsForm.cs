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
            string query = "SELECT Заявки.idЗаявки, CONCAT(Адреса.улица, ' д.', Адреса.`номер дома`, ', п.', Подъезды.`номер подъезда`, " +
                           "', кв.', Квартиры.`номер квартиры`) AS Адрес, Заявки.`Текст заявки`, Заявки.`Дата обслуживания`, " +
                           "CONCAT(Сотрудники.Фамилия, ' ', LEFT(Сотрудники.Имя, 1), '.', LEFT(Сотрудники.Отчество, 1), '.') " +
                           "AS Исполнитель, Заявки.Приоритет, Заявки.`Дата выполнения` FROM mydb.Заявки " +
                           "JOIN mydb.Сотрудники ON Заявки.СотрудникиID = Сотрудники.idСотрудники " +
                           "JOIN mydb.Адреса ON Заявки.АдресID = Адреса.idАдрес " +
                           "JOIN mydb.Подъезды ON Заявки.ПодъездID = Подъезды.idПодъезды " +
                           "JOIN mydb.Квартиры ON Заявки.КвартираID = Квартиры.idКвартиры";

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
            string additionalQuery1 = "SELECT idСотрудники FROM mydb.сотрудники WHERE Фамилия = @EmployeeSurname AND LEFT(Имя, 1) = @EmployeeName " +
                                     "AND LEFT(отчество, 1) = @EmployeeSecondName";
            string additionalQuery2 = "SELECT idПользователи FROM mydb.пользователи WHERE Фамилия = @UserSurname AND LEFT(Имя, 1) = @UserName " +
                                     "AND LEFT(Отчество, 1) = @UserSecondName";
            string addressQuery = "SELECT Заявки.РайонID, Адреса.idАдрес, mydb.Подъезды.idПодъезды, mydb.Квартиры.idКвартиры " +
                                  "FROM mydb.Заявки JOIN mydb.Адреса ON Заявки.РайонID = Адреса.РайонID " +
                                  "JOIN mydb.Подъезды ON Адреса.idАдрес = Подъезды.АдресаID " +
                                  "JOIN mydb.Квартиры ON Подъезды.idПодъезды = Квартиры.ПодъездID " +
                                  "WHERE Адреса.Улица = @StreetName AND Адреса.`Номер дома` = @HouseNumber AND " +
                                  "Подъезды.`Номер подъезда` = @EntranceNumber AND Квартиры.`Номер квартиры` = @ApartmentNumber;";

            string[] address = dataGridView1.CurrentRow.Cells[1].Value.ToString().Split('.');
            address[0] = address[0].Substring(0, address[0].Length - 2);
            address[1] = address[1].Substring(0, address[1].Length - 3);
            address[2] = address[2].Substring(0, address[2].Length - 4);


            string editApplicationAddress = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string editApplicationText = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string editApplicationServiceDate = dataGridView1.CurrentRow.Cells[3].Value.ToString().Split()[0];
            string editApplicationEmployeeName = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            string editApplicationPriority = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            string editApplicationComplitionDate = dataGridView1.CurrentRow.Cells[6].Value.ToString().Split()[0];

            form.ApplicationAddress = editApplicationAddress;
            form.ApplicationText = editApplicationText;
            form.ApplicationServiceDate = editApplicationServiceDate;
            form.ApplicationEmployeeName = editApplicationEmployeeName;
            form.ApplicationPriority = editApplicationPriority;
            form.ApplicationComplitionDate = editApplicationComplitionDate;

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue($"{dataGridView1.CurrentRow.Cells[0].Value}", dataGridView1.CurrentRow.Cells[0].Value.ToString());

                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    dataReader.Read();

                    form.ApplicationDate = dataReader["Дата приема"].ToString().Split()[0];
                    form.ApplicationUser = dataReader["Пользователь"].ToString();
                    form.ApplicationNotes = dataReader["Примечания"].ToString();
                }

                if (form.ShowDialog() == DialogResult.OK)
                {
                    MySqlCommand additionalEmployeeCommand = new MySqlCommand(additionalQuery1, connection);
                    MySqlCommand additionalUserCommand = new MySqlCommand(additionalQuery2, connection);
                    MySqlCommand additionalAddressCommand = new MySqlCommand(addressQuery, connection);

                    string employeeSurname = form.ApplicationEmployeeName.Split()[0];
                    string employeeName = form.ApplicationEmployeeName.Split(' ', '.')[1];
                    string employeeSecondName = form.ApplicationEmployeeName.Split(' ', '.')[2];
                    string userSurname = form.ApplicationUser.Split()[0];
                    string userName = form.ApplicationUser.Split(' ', '.')[1];
                    string userSecondName = form.ApplicationUser.Split(' ', '.')[2];
                    string StreetName = form.ApplicationAddress.Split()[0];
                    string HouseNumber = form.ApplicationAddress.Split(',', '.')[1];
                    string EntranceNumber = form.ApplicationAddress.Split(',', '.')[3];
                    string ApartmentNumber = form.ApplicationAddress.Split(',', '.')[5];

                    additionalEmployeeCommand.Parameters.AddWithValue("@EmployeeSurname", employeeSurname);
                    additionalEmployeeCommand.Parameters.AddWithValue("@EmployeeName", employeeName);
                    additionalEmployeeCommand.Parameters.AddWithValue("@EmployeeSecondName", employeeSecondName);
                    additionalUserCommand.Parameters.AddWithValue("@UserSurname", userSurname);
                    additionalUserCommand.Parameters.AddWithValue("@UserName", userName);
                    additionalUserCommand.Parameters.AddWithValue("@UserSecondName", userSecondName);
                    additionalAddressCommand.Parameters.AddWithValue("@StreetName", StreetName);
                    additionalAddressCommand.Parameters.AddWithValue("@HouseNumber", HouseNumber);
                    additionalAddressCommand.Parameters.AddWithValue("@EntranceNumber", EntranceNumber);
                    additionalAddressCommand.Parameters.AddWithValue("@ApartmentNumber", ApartmentNumber);

                    int employeeId = Convert.ToInt32(additionalEmployeeCommand.ExecuteScalar());
                    int userId = Convert.ToInt32(additionalUserCommand.ExecuteScalar());
                    int districtId;
                    int addressId;
                    int entranceId;
                    int apartmebtId;

                    using (MySqlDataReader dataReader = additionalAddressCommand.ExecuteReader())
                    {
                        dataReader.Read();

                        districtId = Convert.ToInt32(dataReader["РайонID"]);
                        addressId = Convert.ToInt32(dataReader["idАдрес"]);
                        entranceId = Convert.ToInt32(dataReader["idПодъезды"]);
                        apartmebtId = Convert.ToInt32(dataReader["idКвартиры"]);
                    }

                    string updateCommand = "UPDATE mydb.Заявки SET Заявки.`Текст заявки` = @ApplicationText, " +
                                           "Заявки.Приоритет = @ApplicationPriority, " +
                                           "Заявки.`Дата приема` = @ApplicationDate, " +
                                           "Заявки.`Дата обслуживания` = @ApplicationServiceDate, " +
                                           "Заявки.`Дата выполнения` = @ApplicationComplitionDate, " +
                                           "Заявки.СотрудникиID = @ApplicationEmployeeId, " +
                                           "Заявки.ПользователиID = @ApplicationUserId, " +
                                           "Заявки.РайонID = @ApplicationDistrictId, " +
                                           "Заявки.АдресID = @ApplicationAddressId, " +
                                           "Заявки.ПодъездID = @ApplicationEntranceId, " +
                                           "Заявки.КвартираID = @ApplicationApartmentId, " +
                                           $"Заявки.Примечания = @ApplicationNotes WHERE Заявки.idЗаявки = {dataGridView1.CurrentRow.Cells[0].Value};";

                    command = new MySqlCommand(updateCommand, connection);

                    string[] applicationDate = form.ApplicationDate.Split('.');
                    string[] applicationServiceDate = form.ApplicationServiceDate.Split('.');
                    string[] applicationComplitionDate = form.ApplicationComplitionDate.Split('.');

                    string newApplicationDate = applicationDate[2] + "-" + applicationDate[1] + "-" + applicationDate[0];
                    string newApplicationServiceDate = applicationServiceDate[2] + "-" + applicationServiceDate[1] + "-" + applicationServiceDate[0];
                    string newApplicationComplitionDate = applicationComplitionDate[2] + "-" + applicationComplitionDate[1] + "-" + applicationComplitionDate[0];

                    command.Parameters.AddWithValue("@ApplicationText", form.ApplicationText);
                    command.Parameters.AddWithValue("@ApplicationPriority", form.ApplicationPriority);
                    command.Parameters.AddWithValue("@ApplicationDate", newApplicationDate);
                    command.Parameters.AddWithValue("@ApplicationServiceDate", newApplicationServiceDate);
                    command.Parameters.AddWithValue("@ApplicationComplitionDate", newApplicationComplitionDate);
                    command.Parameters.AddWithValue("@ApplicationEmployeeId", employeeId);
                    command.Parameters.AddWithValue("@ApplicationUserId", userId);
                    command.Parameters.AddWithValue("@ApplicationDistrictId", districtId);
                    command.Parameters.AddWithValue("@ApplicationAddressId", addressId);
                    command.Parameters.AddWithValue("@ApplicationEntranceId", entranceId);
                    command.Parameters.AddWithValue("@ApplicationApartmentId", apartmebtId);
                    command.Parameters.AddWithValue("@ApplicationNotes", form.ApplicationNotes);

                    command.ExecuteNonQuery();

                    LoadData();
                }
            }
        }

        private void DeletingButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            if (clickedButton.Name == "DeletingButton")
            {
                if (dataGridView1.CurrentRow != null)
                {
                    DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить выбранную запись?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        int idToDelete = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

                        string query = "DELETE FROM mydb.Заявки WHERE idЗаявки = @ID";

                        using (MySqlConnection connection = new MySqlConnection(connectionString))
                        {
                            connection.Open();
                            using (MySqlCommand command = new MySqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@ID", idToDelete);
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                    LoadData();
                }
            }
        }
    }
}
