using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evolve_Prank_Callers
{
    public partial class passwordDialog : Form
    {
        public passwordDialog()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "ad01min")
            {
                this.DialogResult = DialogResult.OK;
                lblError.Visible = false;
            }
            else
            {
                txtPassword.Clear();
                lblError.Visible = true;
                txtPassword.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
