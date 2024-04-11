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

        //public string ApplicationEmployeeName
        //{
        //    get { return txtApplicationEmployeeName.Text; }
        //    set { txtApplicationEmployeeName.Text = value; }
        //}

        public string ApplicationStreet
        {
            get { return txtApplicationStreet.Text; }
            set { txtApplicationStreet.Text = value; }
        }

        public string ApplicationPriority
        {
            get { return txtApplicationPriority.Text; }
            set { txtApplicationPriority.Text = value; }
        }

        public string ApplicationHouseNumber
        {
            get { return txtApplicationHouseNumber.Text; }
            set { txtApplicationHouseNumber.Text = value; }
        }

        public string ApplicationEntranceNumber
        {
            get { return txtApplicationEntranceNumber.Text; }
            set { txtApplicationEntranceNumber.Text = value; }
        }

        public string ApplicationApartmentNumber
        {
            get { return txtApplicationApartmentNumber.Text; }
            set { txtApplicationApartmentNumber.Text = value; }
        }

        public string ApplicationUser
        {
            get { return txtApplicationUser.Text; }
            set { txtApplicationUser.Text = value; }
        }

        public string ApplicationNotes
        {
            get { return txtApplicationNotes.Text; }
            set { txtApplicationNotes.Text = value; }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(txtApplicationStreet.Text))
            {
                errorProvider1.SetError(txtApplicationStreet, "Значение поля не может быть пустым");
            }
            else if (string.IsNullOrEmpty(txtApplicationHouseNumber.Text))
            {
                errorProvider1.SetError(txtApplicationHouseNumber, "Значение поля не может быть пустым");
            }
            //else if (string.IsNullOrEmpty(txtApplicationEmployeeName.Text))
            //{
            //    errorProvider1.SetError(txtApplicationEmployeeName, "Значение поля не может быть пустым");
            //}
            else if (string.IsNullOrEmpty(txtApplicationUser.Text))
            {
                errorProvider1.SetError(txtApplicationUser, "Значение поля не может быть пустым");
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void FillComboBox()
        {

            string query = "SELECT CONCAT(Фамилия, ' ', LEFT(Имя, 1), '.', LEFT(Отчество, 1), '.') AS Исполнитель FROM Сотрудники";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
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
            }
        }
    }
}
