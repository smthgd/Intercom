using System;
using System.Windows.Forms;

namespace IntercomProject
{
    public partial class EditAddressesForm : Form
    {
        public EditAddressesForm()
        {
            InitializeComponent();
        }

        public string AddressDistrict
        {
            get { return txtAddressDistrict.Text; }
            set { txtAddressDistrict.Text = value; }
        }

        public string AddressStreet
        {
            get { return txtAddressStreet.Text; }
            set { txtAddressStreet.Text = value; }
        }

        public string AddressHouseNumber
        {
            get { return txtAddressHouseNumber.Text; }
            set { txtAddressHouseNumber.Text = value; }
        }

        public string AddressEntranceNumber
        {
            get { return txtAddressEntranceNumber.Text; }
            set { txtAddressEntranceNumber.Text = value; }
        }

        public string AddressApartmentNumber
        {
            get { return txtAddressApartmentNumber.Text; }
            set { txtAddressApartmentNumber.Text = value; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(txtAddressDistrict.Text))
            {
                errorProvider1.SetError(txtAddressDistrict, "Значение поля не может быть пустым");
            }
            else if (string.IsNullOrEmpty(txtAddressStreet.Text))
            {
                errorProvider1.SetError(txtAddressStreet, "Значение поля не может быть пустым");
            }
            else if (string.IsNullOrEmpty(txtAddressHouseNumber.Text))
            {
                errorProvider1.SetError(txtAddressHouseNumber, "Значение поля не может быть пустым");
            }
            else if (string.IsNullOrEmpty(txtAddressEntranceNumber.Text))
            {
                errorProvider1.SetError(txtAddressEntranceNumber, "Значение поля не может быть пустым");
            }
            else if (string.IsNullOrEmpty(txtAddressApartmentNumber.Text))
            {
                errorProvider1.SetError(txtAddressApartmentNumber, "Значение поля не может быть пустым");
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
