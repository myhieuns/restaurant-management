using kombo1.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kombo1.DAO
{
    
    public  class UnitsDAO
    {
        private static UnitsDAO instance;

        public static UnitsDAO Instance
        {
            get { if (instance == null) instance = new UnitsDAO(); return UnitsDAO.instance; }
            private set { UnitsDAO.instance = value; }
        }
        private UnitsDAO() { }
        public List<Units> GetUnitsByID(int id)
        {
            List<Units> list = new List<Units>();

            string query = "select * from Units where id = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Units units = new Units(item);
                list.Add(units);
            }
            return list;
        }

        public void InsertInputInfo(int idInput, int idObject, int count)
        {
            DataProvider.Instance.ExecuteNonQuery(" exec USP_InsertInputInfo @idInput , @idObject , @count", new object[] { idInput, idObject, count });
        }
    }

}
