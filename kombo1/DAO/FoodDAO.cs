using kombo1.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kombo1.DAO
{
   public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return FoodDAO.instance; }
            private set { FoodDAO.instance = value; }
        }

        public static int FoodWidth = 130;
        public static int FoodHeight = 120;

        private FoodDAO() { }

        public List<Food> LoadFoodList()
        {
            List<Food> foodList = new List<Food>();
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from food");
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                foodList.Add(food);
            }

            return foodList;
        }
        public List<Food> GetFoodByCategoryID(int id)
        {
            List<Food> list = new List<Food>();

            string query = "select * from Food where idCategory = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }

            return list;
        }
        public List<Food> GetListFood()
        {
            List<Food> list = new List<Food>();

            string query = "select * from Food";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }

            return list;
        }

       public bool InsertFood (string foodname, int idCategory ,float price)
        {
            string query = string.Format("Insert into dbo.Food (foodname, idCategory, price )  values (N'{0}', {1}, {2}) ", foodname, idCategory, price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateFood(int id, string foodname, int idCategory, float price)
        {
            string query = string.Format("Update dbo.Food set foodname = N'{0}' , idCategory = {1} , price = {2} where id = {3} ", foodname, idCategory, price, id );
           
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteFood(int id)
        {
            BillInfoDAO.Instance.DeleteBillInfoByFoodID(id);
            string query = string.Format("Delete Food where id = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public void DeleteFoodByCategoryID(int id)
        {
            DataProvider.Instance.ExecuteQuery("DELETE dbo.Food WHERE idCategory = " + id);
        }

        public List<Food> SearchFoodByName(string foodname)
        {
            List<Food> list = new List<Food>();

            string query = string.Format("SELECT * FROM dbo.Food WHERE dbo.fuConvertToUnsign1(foodname) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", foodname);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }
            return list;
        }
    }
}
