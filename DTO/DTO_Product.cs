namespace DTO
{
    public class DTO_Product
    {
        private int id;
        private string name;
        private int quantity;
        private double importUnitPrice;
        private double unitPrice;
        private byte[] image;
        private string note;

        public DTO_Product()
        {
        }

        public DTO_Product(string name, int quantity, double importUnitPrice, double unitPrice, byte[] image, string note)
        {
            this.name = name;
            this.quantity = quantity;
            this.importUnitPrice = importUnitPrice;
            this.unitPrice = unitPrice;
            this.image = image;
            this.note = note;
        }

        public DTO_Product(int id, string name, int quantity, double importUnitPrice, double unitPrice, byte[] image, string note)
        {
            this.id = id;
            this.name = name;
            this.quantity = quantity;
            this.importUnitPrice = importUnitPrice;
            this.unitPrice = unitPrice;
            this.image = image;
            this.note = note;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double ImportUnitPrice { get => importUnitPrice; set => importUnitPrice = value; }
        public double UnitPrice { get => unitPrice; set => unitPrice = value; }
        public byte[] Image { get => image; set => image = value; }
        public string Note { get => note; set => note = value; }
    }
}
