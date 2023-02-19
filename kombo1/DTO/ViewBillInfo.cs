using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kombo1.DTO
{
   public class ViewBillInfo
    {
        public ViewBillInfo(int id, int count, string foodName,  double price)
        {
            this.Id = id;
            this.FoodName = foodName;
            this.Count = count;
           this.Price = price;
        }
        private int id;
        private string foodName;
        private int count;
       private double price;

       public int Id { get => id; set => id = value; }
        public string FoodName { get => foodName; set => foodName = value; }
        public int Count { get => count; set => count = value; }
       
        public double Price { get => price; set => price = value; }
       

        public ViewBillInfo(DataRow row)
        {
            this.Id = (int)row["ID"];
            this.FoodName = row["FoodName"].ToString();
            this.Count = (int)row["Count"];
            this.Price = (double)row["Price"];
        }
    }
}
