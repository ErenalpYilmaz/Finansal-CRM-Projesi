using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialCrm.Models;
namespace FinancialCrm
{
    public partial class FrmSettings : Form
    {
        FinancialCrmDbEntities2 db = new FinancialCrmDbEntities2 ();
        public FrmSettings()
        {
            InitializeComponent();
        }

        private void btnUserList_Click(object sender, EventArgs e)
        {
            var values = db.Users.ToList();
            dataGridUser.DataSource = values;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmExpenses frm = new FrmExpenses();
            frm.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmSettings frm = new FrmSettings();
            frm.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            
            string userName = txtUserName.Text;
            string password = txtUserPassword.Text;

            Users users = new Users();
            users.Username = userName;
            users.Password = password;
            db.Users.Add (users);
            db.SaveChanges();

            MessageBox.Show("Kullanıcı Eklendi", "Yeni Kullanıcı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values = db.Users.ToList();
            dataGridUser.DataSource = values;
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtUserId.Text);

            var value = db.Users.Find(id);
            db.Users.Remove(value);
            db.SaveChanges();

            MessageBox.Show("Kullanıcı Silindi", "Kullanıcı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values = db.Users.ToList();
            dataGridUser.DataSource = values;
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtUserId.Text);
            string userName = txtUserName.Text;
            string password = txtUserPassword.Text;

            var users = db.Users.Find(id);
            users.Username = userName;
            users.Password = password;
            
            db.SaveChanges();

            MessageBox.Show("Kullanıcı Güncellendi", "Güncelleme İşlemleri", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values = db.Users.ToList();
            dataGridUser.DataSource = values;
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {

        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Close();
        }
    }
}
