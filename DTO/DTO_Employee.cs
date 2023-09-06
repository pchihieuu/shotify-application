namespace DTO
{
    public class DTO_Employee
    {
        private int id;
        private string name;
        private string address;
        private string phoneNumber;
        private string email;
        private bool role;
        private bool status;
        private string password;

        public DTO_Employee()
        {
        }

        public DTO_Employee(string name, string address, string phoneNumber, string email, bool role, bool status, string password)
        {
            this.name = name;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.role = role;
            this.status = status;
            this.password = password;
        }

        public DTO_Employee(string name, string address, string phoneNumber, string email, bool role, bool status)
        {
            this.name = name;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.role = role;
            this.status = status;
        }

        public DTO_Employee(string address, string phoneNumber, string email)
        {
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }
        public bool Role { get => role; set => role = value; }
        public bool Status { get => status; set => status = value; }
        public string Password { get => password; set => password = value; }
    }
}
