using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kombo1.DTO
{
   public class Account
    {
        public Account(string userName, string accountName, string roleName, string password = null)
        {
            this.UserName = userName;
            this.AccountName = accountName;
            this.IdRole = roleName;
            this.Password = password;
        }

        public Account(DataRow row)
        {
            this.UserName = row["userName"].ToString();
            this.AccountName = row["accountName"].ToString();
            this.IdRole = row["idrole"].ToString();
            this.Password = row["password"].ToString(); 
        }
        private string idRole;
        private string password;
        private string accountName;
        private string userName;

        public string UserName { get => userName; set => userName = value; }
        public string AccountName { get => accountName; set => accountName = value; }
        public string Password { get => password; set => password = value; }
        public string IdRole { get => idRole; set => idRole = value; }
    }
}
