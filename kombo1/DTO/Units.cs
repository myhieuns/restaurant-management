using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kombo1.DTO
{
   public class Units
    {
        private int id;
        private string unitName;

        public Units(int id, string unitname)
        {
            this.Id = id;
            this.UnitName = unitname;
        }

        public Units(DataRow row)
        {
            this.Id = (int)row["id"];
            this.UnitName = row["unitname"].ToString();
        }

        public int Id { get => id; set => id = value; }
        public string UnitName { get => unitName; set => unitName = value; }
    }
}
