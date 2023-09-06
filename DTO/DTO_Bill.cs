namespace DTO
{
    public class DTO_Bill
    {
        private int employeeId;
        private int customerId;
        private double totalPrice;

        public DTO_Bill()
        {
        }

        public DTO_Bill(int employeeId, int customerId, double totalPrice)
        {
            this.EmployeeId = employeeId;
            this.CustomerId = customerId;
            this.TotalPrice = totalPrice;
        }

        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public int CustomerId { get => customerId; set => customerId = value; }
        public double TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}
