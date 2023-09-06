using DAL;
using DTO;
using System.Data;

namespace BUS
{
    public class BUS_BillInfo
    {
        DAL_BillInfo dalBillInfo = new DAL_BillInfo();

        public DataTable ListBillInfo()
        {
            return dalBillInfo.ListBillInfo();
        }

        public bool InsertBillInfo(DTO_BillInfo billInfo, int quantity)
        {
            return dalBillInfo.InsertBillInfo(billInfo, quantity);
        }

        public double GetTotalPrice()
        {
            return dalBillInfo.GetTotalPrice();
        }

        public bool DeleteProductInBillInfo(int id)
        {
            return dalBillInfo.DeleteProductInBillInfo(id);
        }

        public bool UpdateProductInBillInfo(int id, int quantity)
        {
            return dalBillInfo.UpdateProductInBillInfo(id, quantity);
        }
    }
}
