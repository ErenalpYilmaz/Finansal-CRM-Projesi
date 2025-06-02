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
    public partial class allBanksOperations : Form
    {
        public allBanksOperations()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities2 db = new FinancialCrmDbEntities2();
        private void allBanksOperations_Load(object sender, EventArgs e)
        {
            var value = db.Banks.Select(x=> new
            {
                x.BankId,
                x.BankAccountNumber,
                x.BankTitle,
                x.BankBalance
            }).ToList();
            dataGridView1.DataSource = value;
        }
    }
}
