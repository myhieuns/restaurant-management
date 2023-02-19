using kombo1.Db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kombo1.DTO
{
   
    public class Input 
    {
        
       
            public Input(int id, DateTime dateInput)
            {
                this.ID = id;
                this.DateInput = dateInput;
            }

            public Input(DataRow row)
            {
                this.ID = (int)row["id"];
                this.DateInput = (DateTime?)row["inputDate"];
            }

            private DateTime? dateInput;
            private int iD;

            public DateTime? DateInput { get => dateInput; set => dateInput = value; }
            public int ID { get => iD; set => iD = value; }
        


    }
}
