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
    public partial class MoreAdressApplicationsForm : Form
    {
        public string ApplicationClientSurnameAdress
        {
            get { return txtApplicationClientSurnameAdress.Text; }
            set { txtApplicationClientSurnameAdress.Text = value; }
        }

        public string ApplicationClientNameAdress
        {
            get { return txtApplicationClientNameAdress.Text; }
            set { txtApplicationClientNameAdress.Text = value; }
        }

        public string ApplicationClientSecondNameAdress
        {
            get { return txtApplicationClientSecondNameAdress.Text; }
            set { txtApplicationClientSecondNameAdress.Text = value; }
        }
        public string ApplicationTelephoneNumberAdress
        {
            get { return txtApplicationTelephoneNumberAdress.Text; }
            set { txtApplicationTelephoneNumberAdress.Text = value; }
        }
        public string ApplicationEmailAdress
        {
            get { return txtApplicationEmailAdress.Text; }
            set { txtApplicationEmailAdress.Text = value; }
        }
        public string ApplicationContractNumber
        {
            get { return txtApplicationContractNumber.Text; }
            set { txtApplicationContractNumber.Text = value; }
        }

        public string ApplicationClientProtectionAdress
        {
            get { return txtApplicationClientProtectionAdress.Text; }
            set { txtApplicationClientProtectionAdress.Text = value; }
        }

        public string ApplicationClientCameraAdress
        {
            get { return txtApplicationClientCameraAdress.Text; }
            set { txtApplicationClientCameraAdress.Text = value; }
        }

        public string ApplicationTypeAdress
        {
            get { return txtApplicationTypeAdress.Text; }
            set { txtApplicationTypeAdress.Text = value; }
        }

        public MoreAdressApplicationsForm()
        {
            InitializeComponent();
        }
    }
}
