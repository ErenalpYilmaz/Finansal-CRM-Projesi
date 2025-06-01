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
    public partial class FrmBilling : Form
    {
        FinancialCrmDbEntities2 db = new FinancialCrmDbEntities2 ();
        public FrmBilling()
        {
            InitializeComponent();
        }

        private void FrmBilling_Load(object sender, EventArgs e)
        {
            var values = db.Bills.ToList();
            dataGridBill.DataSource = values;
        }

        private void btnBillingList_Click(object sender, EventArgs e)
        {
            var values = db.Bills.ToList();
            dataGridBill.DataSource = values;
        }

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            string title = txtBillTitle.Text;
            decimal amount = decimal.Parse(txtBillAmount.Text);
            string period = txtBillPeriod.Text;

            Bills bills = new Bills();
            bills.BillTitle = title;
            bills.BillAmount = amount;
            bills.BillPeriod = period;
            db.Bills.Add(bills);
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı Bir Şekilde Sisteme Eklendi","Ödeme & Faturalar",MessageBoxButtons.OK,MessageBoxIcon.Information);

            var values = db.Bills.ToList();
            dataGridBill.DataSource = values;
        }

        private void btnDeleteBill_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtBillId.Text);
            var removeValue = db.Bills.Find(id);
            db.Bills.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı Bir Şekilde Sistemden Silindi", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values = db.Bills.ToList();
            dataGridBill.DataSource = values;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var quit = MessageBox.Show("Çıkmak İstediğinizden Emin Misiniz ?","Ödeme & Faturalar",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (quit == DialogResult.OK) { Application.Exit(); }
        }

        private void btnUpdateBill_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtBillId.Text);
            string title = txtBillTitle.Text;
            decimal amount = decimal.Parse(txtBillAmount.Text);
            string period = txtBillPeriod.Text;

            var values = db.Bills.Find(id);

            values.BillTitle = title;
            values.BillAmount = amount;
            values.BillPeriod = period;
            
            db.SaveChanges();

            MessageBox.Show("Ödeme Başarılı Bir Şekilde Sistemde Güncellendi", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values2 = db.Bills.ToList();
            dataGridBill.DataSource = values2;
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmDashboard frm = new frmDashboard();
            frm.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Close();
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

        private void button5_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Close();
        }
    }
}
