using BUS;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmMain : Form
    {
        BUS_Employee busEmployee = new BUS_Employee();
        frmEmployee fEmployee = new frmEmployee();
        frmProduct fProduct = new frmProduct();
        frmCustomer fCustomer = new frmCustomer();
        frmStatistic fStatistic = new frmStatistic();
        frmAccount fAccount;
        frmBill fBill;

        public frmMain(string email)
        {
            InitializeComponent();
            if (!busEmployee.GetEmployeeRole(email))
            {
                btnEmployee.Visible = false;
                btnStatistic.Visible = false;
                btnProduct.Checked = true;
                fProduct.TopLevel = false;
                fProduct.Dock = DockStyle.Fill;
                pnlBody.Controls.Add(fProduct);
                fProduct.Show();
            }
            else
            {
                btnStatistic.Checked = true;
                fStatistic.TopLevel = false;
                fStatistic.Dock = DockStyle.Fill;
                pnlBody.Controls.Add(fStatistic);
                fStatistic.Show();
            }
            fAccount = new frmAccount(email);
            fBill = new frmBill(email);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            fEmployee.TopLevel = false;
            fEmployee.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(fEmployee);
            fEmployee.Show();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            fProduct.TopLevel = false;
            pnlBody.Controls.Add(fProduct);
            fProduct.Dock = DockStyle.Fill;
            fProduct.Show();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            fCustomer.TopLevel = false;
            pnlBody.Controls.Add(fCustomer);
            fCustomer.Dock = DockStyle.Fill;
            fCustomer.Show();
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            fBill.TopLevel = false;
            pnlBody.Controls.Add(fBill);
            fBill.Dock = DockStyle.Fill;
            fBill.Show();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            fAccount.TopLevel = false;
            pnlBody.Controls.Add(fAccount);
            fAccount.Dock = DockStyle.Fill;
            fAccount.Show();
        }

        private void btnStatistic_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            fStatistic.TopLevel = false;
            pnlBody.Controls.Add(fStatistic);
            fStatistic.Dock = DockStyle.Fill;
            fStatistic.Show();
        }
    }
}
