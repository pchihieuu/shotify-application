using BUS;
using DTO;
using System;
using System.Data;
using System.Net.Mail;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmEmployee : Form
    {
        BUS_Employee busEmployee = new BUS_Employee();
        private int id;
        private string name;
        private bool role;
        private bool status;

        public frmEmployee()
        {
            InitializeComponent();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            gvEmployee.DataSource = busEmployee.ListOfEmployees();
            LoadGridView();
            SetValue(true, false);
            txtName.Focus();
        }

        private void LoadGridView()
        {
            gvEmployee.Columns[0].HeaderText = "Mã nhân viên";
            gvEmployee.Columns[1].HeaderText = "Họ tên";
            gvEmployee.Columns[2].HeaderText = "Địa chỉ";
            gvEmployee.Columns[3].HeaderText = "Số điện thoại";
            gvEmployee.Columns[4].HeaderText = "Email";
            gvEmployee.Columns[5].HeaderText = "Vai trò";
            gvEmployee.Columns[6].HeaderText = "Tình trạng";
            foreach (DataGridViewColumn item in gvEmployee.Columns)
            {
                item.DividerWidth = 1;
            }
            gvEmployee.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvEmployee.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void SetValue(bool param, bool isLoad)
        {
            txtEmail.ReadOnly = false;
            txtEmail.Text = null;
            txtAddress.Text = null;
            txtPhoneNumber.Text = null;
            btnInsert.Enabled = param;
            txtName.Text = null;
            radActive.Enabled = param;
            radNonActive.Enabled = param;
            radEmployee.Enabled = param;
            radAdmin.Enabled = param;
            txtName.Focus();
            if (isLoad)
            {
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnUpdate.Enabled = !param;
                btnDelete.Enabled = !param;
            }
            radEmployee.Checked = true;
            radActive.Checked = true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                MailAddress mail = new MailAddress(email);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void MsgBox(string message, bool isError = false)
        {
            if (isError)
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtAddress.Text != "" && txtEmail.Text != "" && txtName.Text != ""
                && txtPhoneNumber.Text != "")
            {
                if (IsValidEmail(txtEmail.Text))
                {
                    role = radAdmin.Checked;
                    status = radActive.Checked;
                    string password = busEmployee.GetRandomPassword();
                    DTO_Employee dtoEmployee = new DTO_Employee(txtName.Text, txtAddress.Text, txtPhoneNumber.Text, txtEmail.Text, role, status, password);
                    if (busEmployee.InsertEmployee(dtoEmployee))
                    {
                        SetValue(false, true);
                        gvEmployee.DataSource = busEmployee.ListOfEmployees();
                        LoadGridView();
                        SendMail sendMail = new SendMail(dtoEmployee.Email, password);
                        sendMail.ShowDialog();
                        MsgBox(sendMail.Result);
                    }
                    else
                        MsgBox("Không thêm nhân viên được!", true);
                }
                else MsgBox("Email không đúng định dạng!", true);
            }
            else MsgBox("Thiếu trường thông tin!", true);
        }

        private void gvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            radNonActive.Enabled = true;
            radActive.Enabled = true;
            radEmployee.Enabled = true;
            radAdmin.Enabled = true;
            txtEmail.ReadOnly = true;
            txtName.Text = gvEmployee.CurrentRow.Cells[1].Value.ToString();
            txtAddress.Text = gvEmployee.CurrentRow.Cells[2].Value.ToString();
            txtPhoneNumber.Text = gvEmployee.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = gvEmployee.CurrentRow.Cells[4].Value.ToString();
            role = bool.Parse(gvEmployee.CurrentRow.Cells[5].Value.ToString());
            status = bool.Parse(gvEmployee.CurrentRow.Cells[6].Value.ToString());
            if (role)
                radAdmin.Checked = true;
            else
                radEmployee.Checked = true;
            if (status)
                radActive.Checked = true;
            else
                radNonActive.Checked = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtAddress.Text != "" && txtEmail.Text != "" && txtName.Text != ""
               && txtPhoneNumber.Text != "")
            {
                role = radAdmin.Checked;
                status = radActive.Checked;
                DTO_Employee dtoEmployee = new DTO_Employee(txtName.Text, txtAddress.Text, txtPhoneNumber.Text, txtEmail.Text, role, status);
                if (busEmployee.UpdateEmployee(dtoEmployee))
                {
                    SetValue(true, false);
                    gvEmployee.DataSource = busEmployee.ListOfEmployees();
                    LoadGridView();
                }
                else
                    MsgBox("Sửa nhân viên không thành công!", true);
            }
            else MsgBox("Thiếu trường thông tin!", true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            id = int.Parse(gvEmployee.CurrentRow.Cells[0].Value.ToString());
            if (busEmployee.DeleteEmployee(id))
            {
                SetValue(true, false);
                gvEmployee.DataSource = busEmployee.ListOfEmployees();
                LoadGridView();
            }
            else
                MsgBox("Xóa nhân viên không thành công", true);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            name = txtSearch.Text.Trim();
            if (name == "")
            {
                frmEmployee_Load(sender, e);
                txtSearch.Focus();
            }
            else
            {
                DataTable data = busEmployee.SearchEmployee(name);
                gvEmployee.DataSource = data;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SetValue(true, false);
        }

        private void frmEmployee_Shown(object sender, EventArgs e)
        {
            txtName.Focus();
        }
    }
}
