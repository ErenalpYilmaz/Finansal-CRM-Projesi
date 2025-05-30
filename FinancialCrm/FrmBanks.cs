using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using FinancialCrm.Models;
namespace FinancialCrm
{
    public partial class FrmBanks : Form
    {
        public FrmBanks()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities2 db = new FinancialCrmDbEntities2();
        private void FrmBanks_Load(object sender, EventArgs e)
        {
            var ziraatBankBalance = db.Banks.Where(x => x.BankTitle == "Ziraat Bankası").Select(y=>y.BankBalance).FirstOrDefault();
            var vakifBankBalance = db.Banks.Where(x=> x.BankTitle == "VakıfBank").Select(y=>y.BankBalance).FirstOrDefault();
            var isBankBalance = db.Banks.Where(x => x.BankTitle == "İş Bankası").Select(y=>y.BankBalance).FirstOrDefault();

            lblIsBankBalance.Text = isBankBalance.ToString() + " ₺";
            lblVakifBankBalance.Text = vakifBankBalance.ToString()+ " ₺";
            lblZiraatBankBalance.Text = ziraatBankBalance.ToString() + " ₺";
        
        }
    }
}
