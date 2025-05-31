using FinancialCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialCrm.Models;
namespace FinancialCrm
{
    public partial class FrmLogin : Form
    {
        FinancialCrmDbEntities2 db = new FinancialCrmDbEntities2 ();
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Çıkış Yapmak İstediğinizden Emin Misiniz ?","Çıkış Yap",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
            if (result == DialogResult.OK) { Application.Exit(); }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var userName = txtUsername.Text;
            var userPasswword = txtUserPassword.Text;

            var user = db.Users.ToList();
            bool login = false;
            foreach (var item in user)
            {
                if (item.Username == userName & item.Password == userPasswword)
                {
                    login = true; 
                    break;
                }
            }
            if (login) 
            {
                FrmBanks frm = new FrmBanks();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Giriş Bilginiriniz Hatalıdır !","Hatalı Giriş",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
    }
}
