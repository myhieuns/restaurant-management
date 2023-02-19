using kombo1.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kombo1.DAO
{
   public class InputDAO
    {
        private static InputDAO instance;

        public static InputDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new InputDAO();
                return InputDAO.instance;
            }
            private set { InputDAO.instance = value; }
        }


        private InputDAO() { }
        public void InsertInput()
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InsertInput ");
        }

        
        public int GetUnCheckInput()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from dbo.Input where day(Inputdate) = day(getdate()) and MONTH(inputdate) = MONTH(getdate()) and Year(inputdate) = year(getdate())");
            if (data.Rows.Count > 0)
            {
                Input input = new Input(data.Rows[0]);
                return input.ID;
            }
            return -1;
        }

        public int GetIDInput()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("Select id from dbo.Input where day(Inputdate) = day(getdate()) and MONTH(inputdate) = MONTH(getdate()) and Year(inputdate) = year(getdate())");
            }
            catch
            {
                return 1;
            }

        }
        public int GetMaxIDInput()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("select max(id) from units");
            }
            catch
            {
                return 1;
            }

        }
        public void InsertInputInfo(int idInput, int idObject, int count)
        {
            DataProvider.Instance.ExecuteNonQuery(" exec USP_InsertInputInfo @idInput , @idObject , @count", new object[] { idInput, idObject, count });
        }

        public DataTable GetListInput()
        {
            return DataProvider.Instance.ExecuteQuery(@"select o.id, o.ObjectName, info.Count, i.InputDate
                                                         from input as i, InputInfo as info, object as o
                                                         where o.id = info.IdObject and info.IdInput = i.id");
        }

    }
}
