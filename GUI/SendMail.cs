using BUS;
using System;
using System.Threading;
using System.Windows.Forms;

namespace GUI
{
    public partial class SendMail : Form
    {
        private string result;
        private string email; // email cần gửi tin
        private string password; // mật khẩu đăng nhập phần mềm
        private bool isUpdate;

        public SendMail(string email, string pass, bool isUpdate = false)
        {
            InitializeComponent();
            this.email = email;
            this.password = pass;
            this.isUpdate = isUpdate;
        }
        
        public string Result { get => result; set => result = value; }

        private void SendMail_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(Send);
            thread.IsBackground = true;
            thread.Start();
        }

        private void Send()
        {
            // Thay email và password của tài khoản gmail dùng để gửi
            // Cho phép login ứng dụng kém an toàn (nếu tìm không thấy thì dùng mail edu)
            string loginEmail = "2024801030101@student.tdmu.edu.vn";
            string loginPassword = "Trung@tftmobile";
            // Tạo đối tượng để gửi mail truyền email, pass để login
            BUS_Mail mail = new BUS_Mail(loginEmail, loginPassword);
            // Nếu là cập nhật mật khẩu thì true, còn nếu là mật khẩu thì false
            Result = mail.SendMail(email, password, isUpdate);
            pcbLoader.Invoke(new Action(() => Close()));
        }
    }
}
