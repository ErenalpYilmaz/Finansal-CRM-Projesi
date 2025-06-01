using FinancialCrm.Models;
using System;
using System.Linq;
using System.Windows.Forms;
namespace FinancialCrm
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities2 db = new FinancialCrmDbEntities2();
        int count = 0;
        private void frmDashboard_Load(object sender, EventArgs e)
        {
            var totalBalance = db.Banks.Sum(x=>x.BankBalance);
            lblTotalBalance.Text = totalBalance.ToString() + " ₺";

            // Son gelen havale tutarı.
            var lastTransfer = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(1).Select(y => y.Amount).FirstOrDefault();
            lblLastTransfer.Text = lastTransfer.ToString();

            #region Chart1 Kodlari

            var bankData = db.Banks.Select(x => new
            {
                x.BankTitle,
                x.BankBalance
            }).ToList();
            chart1.Series.Clear();
            var series = chart1.Series.Add("Series1");
            foreach (var item in bankData)
            {
                series.Points.AddXY(item.BankTitle,item.BankBalance);
            }

            #endregion

            #region Chart2 Kodlari
            var billData = db.Bills.Select(x => new
            {
                x.BillTitle,
                x.BillAmount
            }).ToList();
            chart2.Series.Clear();
            var series2 = chart2.Series.Add("Faturalar");
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            foreach (var item in billData)
            {
                series2.Points.AddXY(item.BillTitle,item.BillAmount);
            }
            #endregion
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var quit = MessageBox.Show("Çıkmak İstediğinizden Emin Misiniz ?", "Ödeme & Faturalar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (quit == DialogResult.OK) { Application.Exit(); }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            if (count % 4 == 1)
            {
                var billElectricity = db.Bills.Where(x=>x.BillTitle == "Elektrik Faturası").Select(y=>y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Elektrik Faturası";
                lblBillAmount.Text = billElectricity.ToString() + " ₺";
            }
            if (count % 4 == 2)
            {
                var billNaturalGas = db.Bills.Where(x => x.BillTitle == "Doğalgaz Faturası").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Doğalgaz Faturası";
                lblBillAmount.Text = billNaturalGas.ToString() + " ₺";
            }
            if (count % 4 == 3)
            {
                var billNetwork = db.Bills.Where(x => x.BillTitle == "İnternet Faturası").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "İnternet Faturası";
                lblBillAmount.Text = billNetwork.ToString() + " ₺";
            }
            if (count % 4 == 0)
            {
                var billWater = db.Bills.Where(x => x.BillTitle == "Su Faturası").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Su Faturası";
                lblBillAmount.Text = billWater.ToString() + " ₺";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmDashboard frm = new frmDashboard();
            frm.Show();
            this.Close();
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Close();
        }

        private void buttonInvoices_Click(object sender, EventArgs e)
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

        private void btnCategories_Click(object sender, EventArgs e)
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
