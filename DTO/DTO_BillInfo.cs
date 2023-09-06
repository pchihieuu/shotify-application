namespace DTO
{
    public class DTO_BillInfo
    {
        private int productId;
        private int quantity;
        private double unitPrice;

        public DTO_BillInfo()
        {
        }

        public DTO_BillInfo(int productId, int quantity, double unitPrice)
        {
            this.ProductId = productId;
            this.Quantity = quantity;
            this.UnitPrice = unitPrice;
        }

        public int ProductId { get => productId; set => productId = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double UnitPrice { get => unitPrice; set => unitPrice = value; }
    }
}
