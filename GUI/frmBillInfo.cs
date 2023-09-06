using BUS;
using DTO;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmBillInfo : Form
    {
        BUS_Customer busCustomer = new BUS_Customer();
        BUS_Product busProduct = new BUS_Product();
        BUS_Employee busEmployee = new BUS_Employee();
        BUS_BillInfo busBillInfo = new BUS_BillInfo();
        BUS_Bill busBill = new BUS_Bill();
        DTO_BillInfo dtoBillInfo;
        DTO_Bill dtoBill;
        private string[] listCustomerIdName, listProductNameQuantity;
        private DateTime dateTime = new DateTime();
        private string productName, email, str;
        private char separator = '|';
        private string[] strlist;

        public frmBillInfo(string email)
        {
            InitializeComponent();
            this.email = email;
        }

        private void LoadData()
        {
            listCustomerIdName = busCustomer.ListCustomerIdName();
            cboCustomerIdName.Items.Clear();
            foreach (string item in listCustomerIdName)
            {
                cboCustomerIdName.Items.Add(item);
            }

            dateTime = DateTime.Now;
            txtDateTime.Text = dateTime.ToString("dd/MM/yyyy") + " " + dateTime.ToString("HH:mm");

            listProductNameQuantity = busProduct.ListProductNameQuantity();
            cboProductNameQuantity.Items.Clear();
            foreach (string item in listProductNameQuantity)
            {
                cboProductNameQuantity.Items.Add(item);
            }

            txtEmployeeIdName.Text = busEmployee.GetEmployeeIdName(email);
        }

        private void MsgBox(string message, bool isError = false)
        {
            if (isError)
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadGridView()
        {
            gvBillInfo.Columns[0].HeaderText = "Mã SP";
            gvBillInfo.Columns[1].HeaderText = "Tên SP";
            gvBillInfo.Columns[2].HeaderText = "Số lượng";
            gvBillInfo.Columns[3].HeaderText = "Thành tiền";
            foreach (DataGridViewColumn item in gvBillInfo.Columns)
            {
                item.DividerWidth = 1;
            }
            gvBillInfo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvBillInfo.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvBillInfo.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            str = cboProductNameQuantity.SelectedItem.ToString();
            strlist = str.Split(separator);
            productName = strlist[0].Trim();

            if (txtQuantity.Text != "" && cboCustomerIdName.SelectedIndex != -1 &&
                cboProductNameQuantity.SelectedIndex != -1)
            {
                dtoBillInfo = new DTO_BillInfo
                (
                    busProduct.GetProductId(productName),
                    int.Parse(txtQuantity.Text),
                    double.Parse(txtUnitPrice.Text)
                );
                if (busBillInfo.InsertBillInfo(dtoBillInfo, int.Parse(txtQuantity.Text)))
                {
                    gvBillInfo.DataSource = busBillInfo.ListBillInfo();
                    LoadGridView();
                    txtTotalPrice.Text = busBillInfo.GetTotalPrice().ToString();
                }
                else
                    MsgBox("Thêm không thành công", true);
            }
            else
                MsgBox("Vui lòng kiểm tra lại dữ liệu", true);
        }

        private void frmBillInfo_Load(object sender, EventArgs e)
        {
            txtQuantity.Text = null;
            txtUnitPrice.Text = null;
            txtTotalPrice.Text = null;
            LoadData();
            gvBillInfo.DataSource = busBillInfo.ListBillInfo();
            LoadGridView();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = busProduct.GetProductId(productName);
            str = cboProductNameQuantity.SelectedItem.ToString();
            strlist = str.Split(separator);
            if (busBillInfo.UpdateProductInBillInfo(id, int.Parse(txtQuantity.Text)))
            {
                gvBillInfo.DataSource = busBillInfo.ListBillInfo();
                LoadGridView();
                txtTotalPrice.Text = busBillInfo.GetTotalPrice().ToString();
                MsgBox("Sửa sản phẩm thành công!");
            }
            else
            {
                MsgBox("Sửa sản phẩm không được", true);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = busProduct.GetProductId(productName);
            if (MessageBox.Show("Bạn có chắc muốn xóa", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (busBillInfo.DeleteProductInBillInfo(id))
                {
                    MsgBox("Xóa thành công");
                    LoadData();
                    gvBillInfo.DataSource = busBillInfo.ListBillInfo();
                    LoadGridView();
                }
                else
                    MsgBox("Không xóa được", true);
            }
        }

        private void gvBillInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (gvBillInfo.Rows.Count > 0)
            //{
            //    cbo = gvProduct.CurrentRow.Cells[0].Value.ToString();
            //    txtName.Text = gvProduct.CurrentRow.Cells[1].Value.ToString();
            //    txtQuantity.Text = gvProduct.CurrentRow.Cells[2].Value.ToString();
            //    txtImportUnitPrice.Text = gvProduct.CurrentRow.Cells[3].Value.ToString();
            //    txtUnitPrice.Text = gvProduct.CurrentRow.Cells[4].Value.ToString();

            //    MemoryStream memoryStream = new MemoryStream((byte[])gvProduct.CurrentRow.Cells[5].Value);
            //    pcbProduct.Image = Image.FromStream(memoryStream);
            //    txtNote.Text = gvProduct.CurrentRow.Cells[6].Value.ToString();
            //}
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            str = txtEmployeeIdName.Text;
            strlist = str.Split(separator);
            string employeeId = strlist[0].Trim();

            str = cboCustomerIdName.SelectedItem.ToString();
            strlist = str.Split(separator);
            string customerId = strlist[0].Trim();

            dtoBill = new DTO_Bill
            (
                int.Parse(employeeId), 
                int.Parse(customerId), 
                double.Parse(txtTotalPrice.Text)
            );
            if (busBill.InsertBill(dtoBill))
            {
                this.Close();
            }
            else
                MsgBox("Thanh toán không thành công", true);
        }

        private void cboProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = cboProductNameQuantity.SelectedItem.ToString();
            char separator = '|';
            String[] strlist = str.Split(separator);
            productName = strlist[0].Trim();
            txtUnitPrice.Text = busProduct.GetUnitPrice(productName).ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtQuantity.Text = null;
            txtUnitPrice.Text = null;
            txtTotalPrice.Text = null;
            LoadData();
        }
    }
}
