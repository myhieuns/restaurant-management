using kombo1.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kombo1.DAO
{
   public class StaffDAO
    {
        private static StaffDAO instance;

        public static StaffDAO Instance
        {
            get { if (instance == null) instance = new StaffDAO(); return StaffDAO.instance; }
            private set { StaffDAO.instance = value; }
        }

        private StaffDAO() { }

        public List<Staff> GetListStaff()
        {
            List<Staff> list = new List<Staff>();

            string query = "select * from Staff";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Staff staff = new Staff(item);
                list.Add(staff);
            }

            return list;
        }

        public Staff GetStaffByUserName(string username)
        {
            Staff staff = null;

            string query = "select * from Staff where username = " + username;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                staff = new Staff(item);
                return staff;
            }

            return staff;
        }

        public bool InsertStaff(string id,string name, string address, string phone, string email, string moreinfo)
        {
            string query = string.Format("INSERT dbo.Staff (id, staffname,address,phone, email, moreinfo )VALUES  (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}')", id, name, address,phone, email, moreinfo);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateStaff( string name, string address, string phone, string email, string moreinfo, string id)
        {
            string query = string.Format("UPDATE dbo.Staff SET staffname = N'{0}', address = N'{1}', phone =  N'{2}', email =  N'{3}', moreinfo = N'{4}'  WHERE id = '{5}'", name, address, phone, email, moreinfo, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteStaff(string id)
        {
           
            string query = string.Format("Delete Staff where id = N'{0}'", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
