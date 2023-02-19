using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kombo1.DTO
{
   public class BillInfo
    {
        public BillInfo(int id, int billID, string foodID, int count)
        {
            this.ID = id;
            this.BillID = billID;
            this.FoodID = foodID;
            this.Count = count;
        }

        public BillInfo(DataRow row)
        {
            this.ID = (int)row["id"];
            this.BillID = (int)row["IdBill"];
            this.FoodID = row["IdFood"].ToString();
            this.Count = (int)row["count"];
        }
        private int count;
        private string foodID;
        private int billID;
        private int iD;

        public int ID { get => iD; set => iD = value; }
        public int BillID { get => billID; set => billID = value; }
        public string FoodID { get => foodID; set => foodID = value; }
        public int Count { get => count; set => count = value; }
            
    }

    
}
