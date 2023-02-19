using kombo1.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace kombo1.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new AccountDAO();
                return instance;
            }
            private set { instance = value; }
        }

        private AccountDAO() { }

        public bool LoginAdmin(string userName, string passWord)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(passWord);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);
            string hasPass = "";
            foreach(byte item in hasData)
            {
                hasPass += item;
            }
            string query = "USP_LoginAdmin @userName , @passWord";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, hasPass });

            return result.Rows.Count > 0;
        }

        public bool LoginNVBan(string userName, string passWord)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(passWord);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);
            string hasPass = "";
            foreach (byte item in hasData)
            {
                hasPass += item;
            }
            //DEMO loi SQL injection
            //string query = "select * from Account where UserName = N'" + userName + "' and PassWord = N'" + passWord + "' and IdRole = N'NVBan' ";
            // DataTable result = DataProvider.Instance.ExecuteQuery(query);
            // pass: "   'OR 1=1--   "
            string query = "USP_LoginStaff @userName , @passWord";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, hasPass });

            return result.Rows.Count > 0;
        }
        public Account GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from account where userName = '" + userName + "'");

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }

            return null;
        }

        public bool UpdateAccount(string userName, string accountName, string passWord, string newPassWord)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @userName , @accountName , @passWord , @newPassWord", new object[] { userName, accountName, passWord, newPassWord });

            return result > 0;

        }

        public bool UpdatePassWordAccount(string userName, string displayName, string pass, string newPass)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @userName , @displayName , @password , @newPassword", new object[] { userName, displayName, pass, newPass });

            return result > 0;

        }
        public bool InsertAccount(string name, string displayName, string type)
        {
            string query = string.Format("INSERT dbo.Account ( UserName, AccountName, Idrole )VALUES  ( N'{0}', N'{1}', N'{2}')", name, displayName, type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateAccount1(string name, string displayName, string type)
        {
            string query = string.Format("UPDATE dbo.Account SET userName = N'{0}' , accountName = N'{1}', idrole = N'{2}' WHERE UserName = N'{0}'", name, displayName, type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteAccount(string name)
        {
            string query = string.Format("Delete Account where UserName = N'{0}'", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool ResetPassword(string name)
        {
            string query = string.Format("Update Account set Password = N'20720532132149213101239102231223249249135100218' where UserName = N'{0}'", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool Manager(string pass)
        {
            string query = string.Format("select password from account");
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExecuteQuery("select a.username, a.AccountName, r.RoleName , r.ID from Account as a, role as r where a.IdRole = r.id");
        }
        public DataTable GetListIDRole()
        {
            return DataProvider.Instance.ExecuteQuery("select id, roleName from role");
        }
    }
}
