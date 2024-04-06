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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.FromArgb(39, 37, 55);
        }

        private void applicationsButton_Click(object sender, EventArgs e)
        {
            ApplicationsForm applicationsForm = new ApplicationsForm();

            if (Application.OpenForms.OfType<ApplicationsForm>().Count() == 0 && Application.OpenForms.OfType<AddressesForm>().Count() == 0)
            {
                applicationsForm.MdiParent = this;
                applicationsForm.Show();
            }
            else
            {
                foreach (Form mdiChildForm in this.MdiChildren)
                {
                    mdiChildForm.Close();
                }

                applicationsForm.MdiParent = this;
                applicationsForm.Show();
            }
        }

        private void addressesButton_Click(object sender, EventArgs e)
        {
            AddressesForm addressesForm = new AddressesForm();

            if (Application.OpenForms.OfType<AddressesForm>().Count() == 0 && Application.OpenForms.OfType<ApplicationsForm>().Count() == 0)
            {
                addressesForm.MdiParent = this;
                addressesForm.Show();
            }
            else
            {
                foreach (Form mdiChildForm in this.MdiChildren)
                {
                    mdiChildForm.Close();
                }

                addressesForm.MdiParent = this;
                addressesForm.Show();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
