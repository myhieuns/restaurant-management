using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kombo1.DTO
{
   public class Table
    {
        public Table(int id, string name, string status)
        {
                this.ID = id;
                this.TableFoodName = name;
                this.Status = status;
        }

        public Table(DataRow row)
        {
            this.ID = (int)row["id"];
            this.TableFoodName = row["tablefoodname"].ToString();
            this.Status = row["status"].ToString();
        }

        private string status;

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        private string name;

        public string TableFoodName
        {
            get { return name; }
            set { name = value; }
        }

        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}