using kombo1.Db;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kombo1.Models
{
    public struct RevenueByDate
    {
        public string Date { get; set; }
        public double TotalAmount{ get; set; }
    }

    public class DashBoard : DbConnection
    {
        private DateTime startDate;
        private DateTime endDate;
        private int numberDays;

        public int NumBill { get; private set; } // tinh tong so bill da thanh toan
        public int NumSoup { get; private set; } // tinh tong so canh chua thit bam
        public double AvgDuration { get; private set; } //Thoi gian ngoi trung binh cua khach hang
        public int NumCustomers1M { get; private set; } // so khach su dung com nieu 1 mat chay
        public int NumCustomers2M { get; private set; }// so khach su dung com nieu 2 mat chay
      //  public int NumCustomers { get; private set; }
        public List<KeyValuePair<string, int>> TopFoodList { get; private set; }
        public List<KeyValuePair<string, int>> TopFoodCategoryList { get; private set; }
        public List<RevenueByDate> GrossRevenueList { get; private set; }
        public double TotalRevenue { get; set; }
        public int NumFood { get; set; }

        public DashBoard()
        {

        }
        #region private methods
        private void GetNumberItems()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;

                    // tinh tong so hoa don (bill)
                    command.CommandText = @"select count (id) 
                                            from Bill as b
                                            where Status = 1 and b.DateCheckOut between @fromDate1 and @toDate1";
                    command.Parameters.Add("@fromDate1", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate1", System.Data.SqlDbType.DateTime).Value = endDate;
                    NumBill = (int)command.ExecuteScalar();

                    // tinh tong so canh chua thit bam
                    command.CommandText = @"select sum(bi.count) 
                                            from bill as b, billinfo as bi, Food as f
                                            where f.id = 10 and b.id = bi.IdBill and f.id = bi.IdFood and b.DateCheckOut between @fromDate2 and @toDate2
                                            group by f.FoodName";
                    command.Parameters.Add("@fromDate2", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate2", System.Data.SqlDbType.DateTime).Value = endDate;
                    NumSoup = (int)command.ExecuteScalar();

                    //Thoi gian ngoi trung binh cua khach hang
                   // command.CommandText = @"select avg(Duration)
                           //                  from Bill
                           //                  where DateCheckOut between @fromDate3 and @toDate3";
                   // command.Parameters.Add("@fromDate3", System.Data.SqlDbType.DateTime).Value = startDate;
                   // command.Parameters.Add("@toDate3", System.Data.SqlDbType.DateTime).Value = endDate;
                  //  AvgDuration = (double)command.ExecuteScalar()*24*60 ;

                    ////tinh tong so khach hang, KOMBO.jsc quy uoc la 1 nieu = 1 khach
                    //tinh tong so khach hang su dung 1 mat chay
                    command.CommandText = @"select sum(bi.count)
                                            from bill as b, billinfo as bi, FoodCategory as fc, Food as f
                                            where fc.id = 1 and  b.Status =1 and fc.id = f.IdCategory and b.id = bi.IdBill and bi.IdFood = f.id and b.DateCheckOut between @fromDate4 and @toDate4";
                    command.Parameters.Add("@fromDate4", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate4", System.Data.SqlDbType.DateTime).Value = endDate;
                    NumCustomers1M = (int)command.ExecuteScalar();

                    //tinh tong so khach hang su dung 2 mat chay
                    command.CommandText = @"select sum(bi.count)
                                            from bill as b, billinfo as bi, FoodCategory as fc, Food as f
                                            where fc.id = 2 and  b.Status =1 and fc.id = f.IdCategory and b.id = bi.IdBill and bi.IdFood = f.id  and b.DateCheckOut between @fromDate5 and @toDate5";
                    command.Parameters.Add("@fromDate5", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate5", System.Data.SqlDbType.DateTime).Value = endDate;
                    NumCustomers2M = (int)command.ExecuteScalar();

                    

                }
            }
        }

        private void GetAnalysisItems()
        {
            GrossRevenueList = new List<RevenueByDate>();
            TotalRevenue = 0;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"select b.DateCheckOut,  sum(b.totalPrice)
                                            from Bill as b
                                            where b.DateCheckOut between @fromDate6 and @toDate6
                                            group by b.DateCheckOut";
                    command.Parameters.Add("@fromDate6", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate6", System.Data.SqlDbType.DateTime).Value = endDate;
                    var reader = command.ExecuteReader();
                    var resultTable = new List<KeyValuePair<DateTime, double>>();
                    while (reader.Read())
                    {
                        resultTable.Add(new KeyValuePair<DateTime, double>((DateTime)reader[0], (double)reader[1]));
                        TotalRevenue += (double)reader[1];
                    }
                    reader.Close();


                    // phan nhom theo ngay
                    if(numberDays <= 30)
                    {
                        foreach(var item in resultTable)
                        {
                            GrossRevenueList.Add(new RevenueByDate()
                            {
                                Date = item.Key.ToString("dd MMM"),
                                TotalAmount = item.Value
                            });
                        }
                    }

                    //phan nhom theo thang
                    else if(numberDays<= 365*2)
                    {
                        bool isYear = numberDays <= 365 ? true : false;
                        GrossRevenueList = (from orderList in resultTable
                                           group orderList by orderList.Key.ToString("MMM yyy")
                                               
                                            into order
                                            select new RevenueByDate
                                            {
                                                Date = isYear ? order.Key.Substring(0, order.Key.IndexOf(" ")) : order.Key,
                                                TotalAmount = order.Sum(amount => amount.Value)
                                            }).ToList();
                    }

                    //nhom theo tuan

                    else if (numberDays <= 92)
                    {
                        GrossRevenueList = (from orderList in resultTable
                                            group orderList by CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                                                orderList.Key, CalendarWeekRule.FirstDay, DayOfWeek.Monday)
                                            into order
                                            select new RevenueByDate
                                            {
                                                Date = "Week" + order.Key.ToString(),
                                                TotalAmount = order.Sum(amount => amount.Value)
                                            }).ToList();
                    }
                    //nhom theo nam
                    else
                    {
                      
                        GrossRevenueList = (from orderList in resultTable
                                            group orderList by orderList.Key.ToString("yyy")

                                            into order
                                            select new RevenueByDate
                                            {
                                                Date = order.Key,
                                                TotalAmount = order.Sum(amount => amount.Value)
                                            }).ToList();
                    }
                }

            }
        }

        private void GetProductAnalysis()
        {
            TopFoodList = new List<KeyValuePair<string, int>>();
            TopFoodCategoryList = new List<KeyValuePair<string, int>>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;
                    

                    //sap xep loai mon an ban duoc tu lon den be

                    command.CommandText = @"select top 10  fc.FoodCategoryName, Sum(bi.count) 
                                            from BillInfo as bi, Food as f, Bill as b, FoodCategory as fc
                                            where bi.IdFood = f.id and bi.IdBill = b.id and fc.id = f.IdCategory and b.DateCheckOut  between @fromDate8 and @toDate8
                                            group by fc.FoodCategoryName
                                            order by sum(bi.count) desc";
                    command.Parameters.Add("@fromDate8", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate8", System.Data.SqlDbType.DateTime).Value = endDate;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TopFoodCategoryList.Add(
                            new KeyValuePair<string, int>(reader[0].ToString(), (int)reader[1]));
                    }
                    reader.Close();

                    // top10 mon ban chay nhat
                    command.CommandText = @"select top 10  f.FoodName, sum(bi.count) 
                                            from BillInfo as bi, Food as f, Bill as b
                                            where bi.IdFood = f.id and bi.IdBill = b.id and b.DateCheckOut between @fromDate7 and @toDate7
                                             group by f.FoodName 
                                             order by sum(bi.count) desc";
                    command.Parameters.Add("@fromDate7", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate7", System.Data.SqlDbType.DateTime).Value = endDate;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TopFoodList.Add(
                            new KeyValuePair<string, int>(reader[0].ToString(), (int)reader[1]));
                    }
                    reader.Close();
                }
            }
            
        }

        #endregion

        #region public methods

        public bool LoadData(DateTime startDate, DateTime endDate)
        {
            endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, endDate.Hour, endDate.Minute, 59);
            if(startDate != this.startDate || endDate != this.endDate)
            {
                this.startDate = startDate;
                this.endDate = endDate;
                this.numberDays = (endDate - startDate).Days;

                GetNumberItems();
                GetProductAnalysis();
                GetAnalysisItems();
                Console.WriteLine("Lam moi du lieu {0} - {1}", startDate.ToString(), endDate.ToString());
                return true;
            }
            else
            {
                Console.WriteLine("dữ liệu không được làm mới {0} - {1}", startDate.ToString(), endDate.ToString());
                return false;
            }
           
        }


        #endregion
    }
}
