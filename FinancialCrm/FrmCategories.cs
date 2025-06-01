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
    public partial class FrmCategories : Form
    {
        FinancialCrmDbEntities2 db = new FinancialCrmDbEntities2();
        public FrmCategories()
        {
            InitializeComponent();
        }

        private void FrmCategories_Load(object sender, EventArgs e)
        {
            var value = db.Categories.Select(x => new
            {
                x.CategoryId,
                x.CategoryName
            }).ToList();
            dataGridCategory.DataSource = value;
        }

        private void btnCategoryList_Click(object sender, EventArgs e)
        {
            var value = db.Categories.Select(x => new
            {
                x.CategoryId,
                x.CategoryName
            }).ToList();
            dataGridCategory.DataSource = value;
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text);
            var value = db.Categories.Find(id);
            db.Categories.Remove(value);
            db.SaveChanges();

            var value2 = db.Categories.Select(x => new
            {
                x.CategoryId,
                x.CategoryName
            }).ToList();
            dataGridCategory.DataSource = value2;
        }

        private void btnCreateCategory_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text);
            var value = db.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
            value.CategoryName = txtCategoryName.Text;
            db.Categories.Add(value);
            db.SaveChanges();

            var value2 = db.Categories.Select(x => new
            {
                x.CategoryId,
                x.CategoryName
            }).ToList();
            dataGridCategory.DataSource = value2;
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmExpenses frm = new FrmExpenses();
            frm.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmDashboard frm = new frmDashboard();
            frm.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmSettings frm = new FrmSettings();
            frm.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            frm.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Close();
        }
    }
}
