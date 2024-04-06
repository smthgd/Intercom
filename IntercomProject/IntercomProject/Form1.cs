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
            if (Application.OpenForms.OfType<ApplicationsForm>().Count() == 0)
            {
                ApplicationsForm applicationsForm = new ApplicationsForm();
                applicationsForm.MdiParent = this;

                applicationsForm.Show();
                //MessageBox.Show(Application.OpenForms.OfType<ApplicationsForm>().Count().ToString());
            }
        }
    }
}
