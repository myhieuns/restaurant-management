using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kombo1.DAO
{
    class CongThucInfoDAO
    {
        private static CongThucInfoDAO instance;

        public static CongThucInfoDAO Instance
        {
            get { if (instance == null) instance = new CongThucInfoDAO(); return CongThucInfoDAO.instance; }
            private set { CongThucInfoDAO.instance = value; }
        }
        private CongThucInfoDAO() { }
        

        public DataTable GetListCongThuc(int id)
        {
            return DataProvider.Instance.ExecuteQuery(@"select f.foodname, o.ObjectName, cti.HamLuong, u.UnitName, cti.Id
                                                        from food as f, CongThucInfo as cti, Object as o, Units as u
                                                        where f.id = cti.IDFood and o.id = cti.IDObject and o.IdUnit = u.id and f.id = " +id);
        }

       public bool InsertCongThuc(int idfood, int idobject, decimal hamluong)
        {
            string query = string.Format("INSERT dbo.CongThucInfo ( IdFood, IdObject, HamLuong )VALUES  ( N'{0}', N'{1}', N'{2}')", idfood, idobject, hamluong);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteCongThuc(int id)
        {
            string query = string.Format("Delete CongThucInfo where id = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
