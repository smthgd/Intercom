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
    public partial class ApplicationsForm : Form
    {
        public ApplicationsForm()
        {
            InitializeComponent();

            this.Width = Application.OpenForms.OfType<MainForm>().FirstOrDefault().Width;
            this.Height = Application.OpenForms.OfType<MainForm>().FirstOrDefault().Height;
        }
    }
}
