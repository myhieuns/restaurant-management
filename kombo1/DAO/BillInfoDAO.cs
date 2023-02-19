using kombo1.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kombo1.DAO
{
   public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance
        {
            get { if (instance == null) instance = new BillInfoDAO();
                return BillInfoDAO.instance;
                 }
            private set { BillInfoDAO.instance = value; }
        }

        private BillInfoDAO() { }

        public List<BillInfo> GetListBillInfo(int id)
        {
            List < BillInfo > ListBillInfo = new List<BillInfo>();

            DataTable data = DataProvider.Instance.ExecuteQuery("select * from dbo.BillInfo where idBill = " + id);
            foreach(DataRow item in data.Rows)
            {
                BillInfo info = new BillInfo(item);
                ListBillInfo.Add(info);
            }
            return ListBillInfo;
        }
        public void InsertBillInfo(int idBill, int idFood, int count)
        {
            DataProvider.Instance.ExecuteNonQuery(" exec USP_InsertBillInfo @idBill , @idFood , @count", new object[] { idBill, idFood, count  });
        }
      
        public void DeleteBillInfoByFoodID(int id)
        {
            DataProvider.Instance.ExecuteQuery("DELETE dbo.BillInfo WHERE idFood = " + id);
        }
    }
}
