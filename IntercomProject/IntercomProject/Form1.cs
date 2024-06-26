using System;
using System.Drawing;
using System.Linq;
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
                applicationsForm.Dock = DockStyle.Fill;
                applicationsForm.Show();
            }
            else
            {
                foreach (Form mdiChildForm in this.MdiChildren)
                {
                    mdiChildForm.Close();
                }

                applicationsForm.MdiParent = this;
                applicationsForm.Dock = DockStyle.Fill;
                applicationsForm.Show();
            }
        }

        private void addressesButton_Click(object sender, EventArgs e)
        {
            AddressesForm addressesForm = new AddressesForm();

            if (Application.OpenForms.OfType<AddressesForm>().Count() == 0 && Application.OpenForms.OfType<ApplicationsForm>().Count() == 0)
            {
                addressesForm.MdiParent = this;
                addressesForm.Dock = DockStyle.Fill;
                addressesForm.Show();
            }
            else
            {
                foreach (Form mdiChildForm in this.MdiChildren)
                {
                    mdiChildForm.Close();
                }

                addressesForm.MdiParent = this;
                addressesForm.Dock = DockStyle.Fill;
                addressesForm.Show();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void employeesButton_Click(object sender, EventArgs e)
        {
            EmployeesApplicationsForm addressesForm = new EmployeesApplicationsForm();

            if (Application.OpenForms.OfType<EmployeesApplicationsForm>().Count() == 0 && Application.OpenForms.OfType<EmployeesApplicationsForm>().Count() == 0)
            {
                addressesForm.MdiParent = this;
                addressesForm.Dock = DockStyle.Fill;
                addressesForm.Show();
            }
            else
            {
                foreach (Form mdiChildForm in this.MdiChildren)
                {
                    mdiChildForm.Close();
                }

                addressesForm.MdiParent = this;
                addressesForm.Dock = DockStyle.Fill;
                addressesForm.Show();
            }
        }

        private void intercomeButton_Click(object sender, EventArgs e)
        {
            IntercomeApplicationsForm addressesForm = new IntercomeApplicationsForm();

            if (Application.OpenForms.OfType<IntercomeApplicationsForm>().Count() == 0 && Application.OpenForms.OfType<IntercomeApplicationsForm>().Count() == 0)
            {
                addressesForm.MdiParent = this;
                addressesForm.Dock = DockStyle.Fill;
                addressesForm.Show();
            }
            else
            {
                foreach (Form mdiChildForm in this.MdiChildren)
                {
                    mdiChildForm.Close();
                }

                addressesForm.MdiParent = this;
                addressesForm.Dock = DockStyle.Fill;
                addressesForm.Show();
            }
        }
    }
}
