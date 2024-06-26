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
    public partial class MoreApplicationsForm : Form
    {
        public string ApplicationClientSurname
        {
            get { return txtApplicationClientSurname.Text; }
            set { txtApplicationClientSurname.Text = value; }
        }

        public string ApplicationClientName
        {
            get { return txtApplicationClientName.Text; }
            set { txtApplicationClientName.Text = value; }
        }

        public string ApplicationClientSecondName
        {
            get { return txtApplicationClientSecondName.Text; }
            set { txtApplicationClientSecondName.Text = value; }
        }

        public string ApplicationIntercomType
        {
            get { return txtApplicationIntercomType.Text; }
            set { txtApplicationIntercomType.Text = value; }
        }

        public string ApplicationTelephoneNumber
        {
            get { return txtApplicationTelephoneNumber.Text; }
            set { txtApplicationTelephoneNumber.Text = value; }
        }

        public string ApplicationEmail
        {
            get { return txtApplicationEmail.Text; }
            set { txtApplicationEmail.Text = value; }
        }
        public MoreApplicationsForm()
        {
            InitializeComponent();
        }
    }
}
