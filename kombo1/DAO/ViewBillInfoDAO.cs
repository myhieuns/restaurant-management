using kombo1.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kombo1.DAO
{
   public class ViewBillInfoDAO
    {
        private static ViewBillInfoDAO instance;

        public static ViewBillInfoDAO Instance
        {
            get
            {
                if (instance == null) instance = new ViewBillInfoDAO();
                return ViewBillInfoDAO.instance;
            }
            private set { ViewBillInfoDAO.instance = value; }
        }
        private ViewBillInfoDAO() { }

        public List<ViewBillInfo> ViewBillInfo(int id)
        {
            List<ViewBillInfo> ListViewBillInfo = new List<ViewBillInfo>();

            DataTable data = DataProvider.Instance.ExecuteQuery("select b.id, f.FoodName, bi.Count, f.Price from Bill as b, BillInfo as bi, Food as f where f.id = bi.IdFood and bi.IdBill = b.id and b.id = "+id);
       
            foreach (DataRow item in data.Rows)
            {
                ViewBillInfo info = new ViewBillInfo(item);
                ListViewBillInfo.Add(info);
            }
            return ListViewBillInfo;
        }
    }
}


