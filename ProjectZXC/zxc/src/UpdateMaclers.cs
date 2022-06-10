using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SQLite.EF6.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zxc.Data;

namespace zxc
{
    public class UpdateMaclers
    {
        public static string name;
        public static void StartUpdateMaclers()
        {
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - Update maclers statistics");

            MyDbContext context = new MyDbContext();
            bool checkOperations = false;
            var data = context.deals.ToList();
            var data2 = context.maclers.ToList();
            var data3 = context.maclerStatistics.ToList();
            var data4 = context.goods.ToList();

            while (checkOperations == false)
            {
                Console.WriteLine("Select an action");
                int num = Convert.ToInt32(Console.ReadLine());
                if (num == 0)
                {
                    checkOperations = true;
                    break;
                }
                if (num == 1)
                {
                    foreach (var item in data)
                    {
                        bool check = false;
                        foreach (var item3 in data3)
                        {
                            if (item.maclerId == item3.maclerID)
                            {
                                check = true;
                                foreach (var item4 in data4)
                                {
                                    if (item4.maclerId == item.maclerId)
                                    {
                                        item3.amount += item.amount;
                                        item3.sumprice += item.amount * item4.price;
                                        break;
                                    }
                                }
                            }
                        }
                        if (check == false)
                        {
                            using (var connection = new Data.MyDbContext())
                            {
                                double pr = 0;
                                foreach (var item2 in data2)
                                {
                                    if (item2.maclerId == item.maclerId)
                                    {
                                        name = item2.name;
                                    }
                                }
                                foreach (var item4 in data4)
                                {
                                    if (item4.maclerId == item.maclerId)
                                    {
                                        pr = item4.price;
                                    }
                                }
                                var maclerStat = new Data.Tables.maclerStatistic
                                {
                                    maclerID = item.maclerId,
                                    maclerName = name,
                                    amount = item.amount,
                                    sumprice = pr
                                };
                                connection.maclerStatistics.Add(maclerStat);
                                connection.SaveChanges();
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
