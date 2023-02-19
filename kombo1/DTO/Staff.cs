using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kombo1.DTO
{
   public class Staff
    {
        public Staff(string id, string staffName, string userName, string address, string phone, string email, string moreInfo)
        {
            this.Id = id;
            this.StaffName = staffName;
            this.UserName = userName;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.MoreInfo = moreInfo;
        }
        public Staff(DataRow row)
        {
            this.Id = row["id"].ToString();
            this.StaffName = row["staffname"].ToString();
            this.UserName = row["username"].ToString();
            this.Address = row["address"].ToString();
            this.Phone = row["phone"].ToString();
            this.Email = row["email"].ToString();
            this.MoreInfo = row["moreinfo"].ToString();
        }
        private string id;
        private string staffName;
        private string userName;
        private string address;
        private string phone;
        private string email;
        private string moreInfo;

        public string Id { get => id; set => id = value; }
        public string StaffName { get => staffName; set => staffName = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string MoreInfo { get => moreInfo; set => moreInfo = value; }
    }
}
