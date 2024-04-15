using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntercomProject
{
    public partial class EditApplicationsForm : Form
    {
        public EditApplicationsForm()
        {
            InitializeComponent();
            FillComboBox();
        }

        private static string connectionString = "server=127.0.0.1;port=3306;username=root;password=Chaplin-06-05-04-goldsteam-0;database=mydb";

        public string ApplicationDate
        {
            get { return txtApplicationDate.Text; }
            set { txtApplicationDate.Text = value; }
        }

        public string ApplicationText
        {
            get { return txtApplicationText.Text; }
            set { txtApplicationText.Text = value; }
        }

        public string ApplicationServiceDate
        {
            get { return txtApplicationServiceDate.Text; }
            set { txtApplicationServiceDate.Text = value; }
        }

        public string ApplicationPriority
        {
            get { return txtApplicationPriority.Text; }
            set { txtApplicationPriority.Text = value; }
        }

        public string ApplicationUser
        {
            get { return comboBoxApplicationUser.Text; }
            set { comboBoxApplicationUser.Text = value; }
        }

        public string ApplicationEmployeeName
        {
            get { return comboBoxApplicationEmployeeName.Text; }
            set { comboBoxApplicationEmployeeName.Text = value; }
        }

        public string ApplicationAddress
        {
            get { return comboBoxApplicationAddress.Text; }
            set { comboBoxApplicationAddress.Text = value; }
        }

        public string ApplicationNotes
        {
            get { return txtApplicationNotes.Text; }
            set { txtApplicationNotes.Text = value; }
        }

        public string ApplicationComplitionDate
        {
            get { return txtApplicationComplitionDate.Text; }
            set { txtApplicationComplitionDate.Text = value; }
        }

        public string ApplicationDistrict
        {
            get { return txtApplicationDistrict.Text; }
            set { txtApplicationDistrict.Text = value; }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            string pattern = @"^\d{2}\.\d{2}\.\d{4}$";

            if (string.IsNullOrEmpty(comboBoxApplicationUser.Text))
            {
                errorProvider1.SetError(comboBoxApplicationUser, "Значение поля не может быть пустым");
            }
            else if (string.IsNullOrEmpty(txtApplicationDate.Text))
            {
                errorProvider1.SetError(txtApplicationDate, "Значение поля не может быть пустым");
            }
            else if (string.IsNullOrEmpty(txtApplicationPriority.Text))
            {
                errorProvider1.SetError(txtApplicationPriority, "Значение поля не может быть пустым");
            }
            else if (string.IsNullOrEmpty(comboBoxApplicationEmployeeName.Text))
            {
                errorProvider1.SetError(comboBoxApplicationEmployeeName, "Значение поля не может быть пустым");
            }
            else if (string.IsNullOrEmpty(comboBoxApplicationAddress.Text))
            {
                errorProvider1.SetError(comboBoxApplicationAddress, "Значение поля не может быть пустым");
            }
            else if (!Regex.IsMatch(txtApplicationDate.Text, pattern))
            {
                errorProvider1.SetError(txtApplicationDate, "Значние поля не соответсвует маске");
            }
            else if (!Regex.IsMatch(txtApplicationComplitionDate.Text, pattern))
            {
                errorProvider1.SetError(txtApplicationComplitionDate, "Значние поля не соответсвует маске");
            }
            else if (!Regex.IsMatch(txtApplicationServiceDate.Text, pattern))
            {
                errorProvider1.SetError(txtApplicationServiceDate, "Значние поля не соответсвует маске");
            }
            else if (!comboBoxApplicationAddress.Items.Contains(comboBoxApplicationAddress.Text))
            {
                errorProvider1.SetError(comboBoxApplicationAddress, "Недопустимое значение");
            }
            else if (!comboBoxApplicationEmployeeName.Items.Contains(comboBoxApplicationEmployeeName.Text))
            {
                errorProvider1.SetError(comboBoxApplicationEmployeeName, "Недопустимое значение");
            }
            else if (!comboBoxApplicationUser.Items.Contains(comboBoxApplicationUser.Text))
            {
                errorProvider1.SetError(comboBoxApplicationUser, "Недопустимое значение");
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void FillComboBox()
        {

            string query1 = "SELECT CONCAT(Фамилия, ' ', LEFT(Имя, 1), '.', LEFT(Отчество, 1), '.') AS Исполнитель FROM Сотрудники";
            string query2 = "SELECT CONCAT(улица, ' д.', `номер дома`, ', п.', `номер подъезда`, ', кв.', `номер квартиры`) AS адрес " +
                "FROM mydb.Адреса LEFT JOIN mydb.подъезды ON адреса.idАдрес = подъезды.адресаID " +
                "LEFT JOIN mydb.квартиры ON подъезды.idПодъезды = квартиры.подъездID;";
            string query3 = "SELECT CONCAT(Фамилия, ' ', LEFT(Имя, 1), '.', LEFT(Отчество, 1), '.') AS Пользователь FROM mydb.Пользователи";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query1, connection))
                {
                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxApplicationEmployeeName.Items.Add(reader["Исполнитель"].ToString());
                        }
                    }
                }

                using (MySqlCommand command = new MySqlCommand(query2, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["адрес"].ToString() != "")
                            {
                                comboBoxApplicationAddress.Items.Add(reader["адрес"].ToString());
                            }
                        }
                    }
                }

                using (MySqlCommand command = new MySqlCommand(query3, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxApplicationUser.Items.Add(reader["Пользователь"].ToString());
                        }
                    }
                }
            }
        }
    }
}
