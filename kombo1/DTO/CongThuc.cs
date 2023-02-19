using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kombo1.DTO
{
   public class CongThuc
    {
        public CongThuc(int id, int idFood)
        {
            this.ID = id;
            this.IDFood = iDFood;
        }

        public CongThuc(DataRow row)
        {
            this.ID = (int)row["id"];
            this.IDFood = (int)row["idfood"];
        }

        private int iD;
        private int iDFood;

        public int ID { get => iD; set => iD = value; }
        public int IDFood { get => iDFood; set => iDFood = value; }
    }
    

}
