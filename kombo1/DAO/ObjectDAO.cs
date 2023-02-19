using kombo1.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kombo1.DAO
{
   public class ObjectDAO
    {
        private static ObjectDAO instance;

        public static ObjectDAO Instance
        {
            get { if (instance == null) instance = new ObjectDAO(); return ObjectDAO.instance; }
            private set { ObjectDAO.instance = value; }
        }
        private ObjectDAO() { }

        public List<Object1> GetListObject()
        {
            List<Object1> list = new List<Object1>();

            string query = "select * from Object";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Object1 object1 = new Object1(item);
                list.Add(object1);
            }

            return list;
        }

        public List<Object1> GetUnitByObject(int id)
        {
            List<Object1> list = new List<Object1>();

            string query = "select * from Object where idUnit = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Object1 object1 = new Object1(item);
                list.Add(object1);
            }
            return list;
        }

       


        public DataTable GetListObject1()
        {
            return DataProvider.Instance.ExecuteQuery(@"select  distinct o.id, o.ObjectName, o.TyLeSoChe, u.UnitName
                                                        from object as o, units as u
                                                        where o.IdUnit = u.id");
        }

        public DataTable SearchObjectByName(string Objectname)
        {
           

            string query = string.Format(@"SELECT o.id, o.ObjectName, o.TyLeSoChe, u.UnitName
                                            FROM  object as o, units as u
WHERE o.IdUnit = u.id and dbo.fuConvertToUnsign1([ObjectName]) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", Objectname);

         
            return DataProvider.Instance.ExecuteQuery(query);
        }

    }
}
