using BUS;
using DTO;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmAccount : Form
    {
        BUS_Employee busEmployee = new BUS_Employee();
        DTO_Employee dtoEmployee;
        private string email, str;
        private char separator = '|';
        private string[] strlist;

        public frmAccount(string email)
        {
            InitializeComponent();
            this.email = email;
        }

        private void LoadData()
        {
            str = busEmployee.GetEmployeeIdName(email);
            strlist = str.Split(separator);
            txtName.Text = strlist[1].Trim();

            str = busEmployee.GetEmployeeAddressPhoneNumber(email);
            strlist = str.Split(separator);
            txtAddress.Text = strlist[0].Trim();
            txtPhoneNumber.Text = strlist[1].Trim();

            txtEmail.Text = email;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (txtOldPassword.Text != "")
            {
                if (txtNewPassword.Text == txtRepeatPassword.Text)
                {
                    busEmployee = new BUS_Employee();
                    if (busEmployee.ChangePassword(txtEmail.Text, txtOldPassword.Text, txtNewPassword.Text))
                    {
                        MessageBox.Show("Đổi mật khẩu thành công, vui lòng đăng nhập lại.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Properties.Settings.Default.password = "";
                        Properties.Settings.Default.Save();
                        Application.Restart();
                    }
                    else MessageBox.Show("Mật khẩu cũ không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("Mật khẩu mới không trùng nhau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Vui lòng nhập mật khẩu cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            dtoEmployee = new DTO_Employee(txtAddress.Text, txtPhoneNumber.Text, txtEmail.Text);
            if (busEmployee.UpdateEmployeeAddressPhoneNumber(dtoEmployee))
            {
                MessageBox.Show("Sửa thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
            else
            {
                MessageBox.Show("Không sửa được thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmAccount_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
