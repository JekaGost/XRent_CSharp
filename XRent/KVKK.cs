using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XRent
{
    public partial class KVKK: Form
    {
        public KVKK()
        {
            InitializeComponent();
        }

        private void KVKK_Load(object sender, EventArgs e)
        {
            txtRulesDisplay.Text = Properties.Resources.KVKK_Text_TR;
        }

        private void txtRulesDisplay_TextChanged(object sender, EventArgs e)
        {

        }

        private void geri_btn_Click(object sender, EventArgs e)
        {
            Main_Form mainForm = new Main_Form();
            this.Close();
        }
    }
}
