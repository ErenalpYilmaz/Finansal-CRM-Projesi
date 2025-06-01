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
    public partial class FrmExpenses : Form
    {
        FinancialCrmDbEntities2 db = new FinancialCrmDbEntities2 ();
        public FrmExpenses()
        {
            InitializeComponent();
        }

        private void FrmInvoices_Load(object sender, EventArgs e)
        {
            var value = db.Spendings.Select(x=> new
            {
                x.SpendingId,
                x.SpendingTitle,
                x.SpendingAmount,
                x.SpendingDate,
                CategoryName = x.Categories.CategoryName
            }).ToList();
            dataGridView1.DataSource = value;
        }

        private void btnBanks_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Close();
        }

        private void btnInvoices_Click(object sender, EventArgs e)
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

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            frmDashboard frm = new frmDashboard();
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
