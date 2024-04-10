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
        }

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

        public string ApplicationEmployeeName
        {
            get { return txtApplicationEmployeeName.Text; }
            set { txtApplicationEmployeeName.Text = value; }
        }

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
            else if (string.IsNullOrEmpty(txtApplicationEmployeeName.Text))
            {
                errorProvider1.SetError(txtApplicationEmployeeName, "Значение поля не может быть пустым");
            }
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
    }
}
