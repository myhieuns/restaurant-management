using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kombo1.DTO
{
  public class Object1
    {
        public Object1(int id, string objectname, int idunit, int idsuplier, double tylesoche)
        {
            this.ID = id;
            this.ObjectName = objectname;
            this.IDUnit = idunit;
            this.IDSuplier = idsuplier;
            this.TyLeSoChe = tylesoche;
        }
        public Object1(DataRow row)
        {
            this.ID = (int)row["id"];
            this.ObjectName = row["objectname"].ToString();
            this.IDUnit = (int)row["idunit"];
            this.IDSuplier = (int)row["idsuplier"];
            this.TyLeSoChe = (double)row["tylesoche"];
        }
        private int iD;
        private string objectName;
        private int iDUnit;
        private int iDSuplier;
        private double tyLeSoChe;
        
        public int ID { get => iD; set => iD = value; }
        public string ObjectName { get => objectName; set => objectName = value; }
        public int IDUnit { get => iDUnit; set => iDUnit = value; }
        public int IDSuplier { get => iDSuplier; set => iDSuplier = value; }
        public double TyLeSoChe { get => tyLeSoChe; set => tyLeSoChe = value; }
    }
}
