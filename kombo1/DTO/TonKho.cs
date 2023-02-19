using kombo1.Db;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kombo1.DTO
{
    public struct Input1
    {
        public string ObjectName { get; set; }
        public double Values { get; set; }
    }
    public class TonKho : DbConnection
    {
        private DateTime startDate;
        private DateTime endDate;
        private int numberDays;

        public List<KeyValuePair<string, int>> FoodList { get; private set; }
        public List<Input1> ValuesList { get; private set; }
        public List<Input1> ValuesListToDay { get; private set; }
        private void GetAnalysisItems()
        {
            ValuesList = new List<Input1>();
            ValuesListToDay = new List<Input1>();
          
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"select o.ObjectName,o.TyLeSoChe* sum(info.count) as 'nhap'
                                            into #Nhap
                                             from Object as o, input as i, Inputinfo as info
                                             where info.IdInput = i.id and info.IdObject = o.id
                                             and i.InputDate between dateadd(day, -DATEDIFF(day,@toDate6, @fromDate6), @fromDate6) and  dateadd(day,-DATEDIFF(day,@toDate6, @fromDate6), @toDate6)
                                             group by   o.ObjectName,o.TyLeSoChe

                                            select o.ObjectName, sum(bi.count)*cti.HamLuong as 'xuat'
                                            into #Xuat
                                            from BillInfo as bi, food as f, CongThucInfo as cti, object as o, bill as b
                                            where bi.IdFood = f.id and cti.IDFood = bi.IdFood and o.id = cti.IDObject and b.id = bi.idbill
                                            and b.datecheckout between dateadd(day, -DATEDIFF(day,@toDate6, @fromDate6), @fromDate6) and  dateadd(day,-DATEDIFF(day,@toDate6, @fromDate6), @toDate6)
                                            group by o.ObjectName, cti.HamLuong, o.TyLeSoChe

                                            select #nhap.ObjectName, #nhap.nhap- #xuat.xuat as 'ton'
                                            into #ton
                                            from #nhap inner join #xuat on #nhap.ObjectName = #xuat.ObjectName

                                            select o.ObjectName, o.TyLeSoChe* sum(info.count) as 'nhap'
                                            into #nhap1
                                              from Object as o, input as i, Inputinfo as info
                                              where info.IdInput = i.id and info.IdObject = o.id and i.InputDate between @fromDate6 and @toDate6
                                              group by   o.ObjectName, o.TyLeSoChe

                                            select o.ObjectName, sum(bi.count)* cti.HamLuong as 'xuat'
                                             into #xuat1
                                             from BillInfo as bi, food as f, CongThucInfo as cti, object as o, bill as b
                                             where bi.IdFood = f.id and cti.IDFood = bi.IdFood and o.id = cti.IDObject and b.id = bi.IdBill and b.DateCheckOut between @fromDate6 and @toDate6
                                             group by o.ObjectName, cti.HamLuong, o.TyLeSoChe

                                              select #nhap1.ObjectName, #nhap1.nhap+#ton.ton as 'Soluong'
                                                into #NVLcon
                                              from #nhap1 inner join #ton on #nhap1.ObjectName = #ton.ObjectName

                                            select #NVLcon.ObjectName, #NVLcon.SoLuong - #xuat1.xuat as 'SLCon'
                                            from #NVLcon inner join #xuat1 on #NVLcon.ObjectName = #xuat1.ObjectName";
     // cách tính: Tồn kho ngày 30 = Tồn kho ngày 29 + Nhập NVL ngày 30 - Xuất bán ngày 30//

                  //  command.CommandText = @"select o.ObjectName,o.TyLeSoChe* sum(info.count)
                  //                      from Object as o, input as i, Inputinfo as info
                  //                      where info.IdInput = i.id and info.IdObject = o.id and i.InputDate between @fromDate6 and @toDate6
                  //                      group by  o.ObjectName,o.TyLeSoChe
                  //                      order by sum(info.count) desc";

                    command.Parameters.Add("@fromDate6", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate6", System.Data.SqlDbType.DateTime).Value = endDate;
                    var reader = command.ExecuteReader();
                    var resultTable = new List<KeyValuePair<string, double>>();
                    while (reader.Read())
                    {
                        resultTable.Add(new KeyValuePair<string, double>((string)reader[0],(double)reader[1]));
                      
                    }
                    reader.Close();

                   
                    if (numberDays <= 30)
                   {
                        foreach (var item in resultTable)
                        {
                            ValuesList.Add(new Input1()
                            {
                                ObjectName = item.Key.ToString(),
                                Values = item.Value
                           });
                      }
                    }



            }

        }
        }
        private void GetAnalysisItemsToDay()
        {
        
            ValuesListToDay = new List<Input1>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"select o.ObjectName,o.TyLeSoChe* sum(info.count) as 'nhap'
                                            into #Nhap
                                             from Object as o, input as i, Inputinfo as info
                                             where info.IdInput = i.id and info.IdObject = o.id
                                             and i.InputDate between dateadd(day, -1, @fromDate7) and  dateadd(day,-1, @toDate7)
                                             group by   o.ObjectName,o.TyLeSoChe

                                            select o.ObjectName, sum(bi.count)*cti.HamLuong as 'xuat'
                                            into #Xuat
                                            from BillInfo as bi, food as f, CongThucInfo as cti, object as o, bill as b
                                            where bi.IdFood = f.id and cti.IDFood = bi.IdFood and o.id = cti.IDObject and b.id = bi.idbill
                                            and b.datecheckout between dateadd(day, -1, @fromDate7) and  dateadd(day,-1, @toDate7)
                                            group by o.ObjectName, cti.HamLuong, o.TyLeSoChe

                                            select #nhap.ObjectName, #nhap.nhap- #xuat.xuat as 'ton'
                                            into #ton
                                            from #nhap inner join #xuat on #nhap.ObjectName = #xuat.ObjectName

                                            select o.ObjectName, o.TyLeSoChe* sum(info.count) as 'nhap'
                                            into #nhap1
                                              from Object as o, input as i, Inputinfo as info
                                              where info.IdInput = i.id and info.IdObject = o.id and i.InputDate between @fromDate7 and @toDate7
                                              group by   o.ObjectName, o.TyLeSoChe

                                            select o.ObjectName, sum(bi.count)* cti.HamLuong as 'xuat'
                                             into #xuat1
                                             from BillInfo as bi, food as f, CongThucInfo as cti, object as o, bill as b
                                             where bi.IdFood = f.id and cti.IDFood = bi.IdFood and o.id = cti.IDObject and b.id = bi.IdBill and b.DateCheckOut between @fromDate7 and @toDate7
                                             group by o.ObjectName, cti.HamLuong, o.TyLeSoChe

                                              select #nhap1.ObjectName, #nhap1.nhap+#ton.ton as 'Soluong'
                                                into #NVLcon
                                              from #nhap1 inner join #ton on #nhap1.ObjectName = #ton.ObjectName

                                            select #NVLcon.ObjectName, #NVLcon.SoLuong - #xuat1.xuat as 'SLCon'
                                            from #NVLcon inner join #xuat1 on #NVLcon.ObjectName = #xuat1.ObjectName";
                    command.Parameters.Add("@fromDate7", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate7", System.Data.SqlDbType.DateTime).Value = endDate;
                    var reader = command.ExecuteReader();
                    var resultTable = new List<KeyValuePair<string, double>>();
                    while (reader.Read())
                    {
                        resultTable.Add(new KeyValuePair<string, double>((string)reader[0], (double)reader[1]));

                    }
                    reader.Close();
                    if (numberDays <= 30)
                    {
                        foreach (var item in resultTable)
                        {
                            ValuesListToDay.Add(new Input1()
                            {
                                ObjectName = item.Key.ToString(),
                                Values = item.Value
                            });
                        }
                    }



                }

            }
        }
        private void GetProductAnalysis()
        {
            FoodList = new List<KeyValuePair<string, int>>();
        

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;

                    command.CommandText = @"select  f.FoodName, sum(bi.count) 
                                            from BillInfo as bi, Food as f, Bill as b
                                            where bi.IdFood = f.id and bi.IdBill = b.id and f.price >=65000 and b.DateCheckOut between @fromDate7 and @toDate7
                                             group by f.FoodName 
                                             order by sum(bi.count) desc";
                    command.Parameters.Add("@fromDate7", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate7", System.Data.SqlDbType.DateTime).Value = endDate;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        FoodList.Add(new KeyValuePair<string, int>(reader[0].ToString(), (int)reader[1]));
                    }
                    reader.Close();

                }
            }

           

                    
                
            

        }
        public bool LoadData(DateTime startDate, DateTime endDate)
        {
            endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, endDate.Hour, endDate.Minute, 59);
            if (startDate != this.startDate || endDate != this.endDate)
            {
                this.startDate = startDate;
                this.endDate = endDate;
                this.numberDays = (endDate - startDate).Days;
                GetProductAnalysis();
                GetAnalysisItems();
                GetAnalysisItemsToDay();

                Console.WriteLine("Lam moi du lieu {0} - {1}", startDate.ToString(), endDate.ToString());
                return true;
            }
            else
            {
                Console.WriteLine("dữ liệu không được làm mới {0} - {1}", startDate.ToString(), endDate.ToString());
                return false;
            }

        }

    }
}



//select o.ObjectName, o.TyLeSoChe* sum(info.count) as 'nhap'

// from Object as o, input as i, Inputinfo as info
// where info.IdInput = i.id and info.IdObject = o.id
// group by   o.ObjectName, o.TyLeSoChe

//select o.ObjectName, sum(bi.count)* cti.HamLuong as 'xuat'

//from BillInfo as bi, food as f, CongThucInfo as cti, object as o
//where bi.IdFood = f.id and cti.IDFood = bi.IdFood and o.id = cti.IDObject
//group by o.ObjectName, cti.HamLuong, o.TyLeSoChe



//select #nhap.ObjectName, #nhap.nhap- #xuat.xuat

//from #nhap inner join #xuat on #nhap.ObjectName = #xuat.ObjectName


//select * from ton
//select o.ObjectName, (-sum(bi.count)* cti.HamLuong+ sum(info.count)* o.TyLeSoChe)
//from object as o, CongThucInfo as cti, BillInfo as bi, InputInfo as info
//where o.id = cti.IDObject and cti.IDFood = bi.IdFood and info.IdObject = o.id
//group by o.ObjectName, cti.HamLuong, o.TyLeSoChe
