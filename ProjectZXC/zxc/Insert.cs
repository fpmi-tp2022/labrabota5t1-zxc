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
    class Insert
    {
        private static string[] dataNew;

        public static void StartInsert() {
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - Insert");
            bool check = false;
            while(check == false)
            {
                Console.WriteLine("Select an action");
                int num = Convert.ToInt32(Console.ReadLine());
                if(num == 0)
                {
                    check = true;
                    break;
                }
                if(num == 1)
                {
                    Console.WriteLine("Enter the name of the table you want to refer to (standard tables: deals, maclers, goods)");
                    string table = Console.ReadLine();

                    if(table == "deals")
                    {
                        Console.WriteLine("Enter data (dealID, date, name, type, amount, macler, customer, maclerID)");
                        bool ch = false;
                        while(ch == false)
                        {
                            string line = Console.ReadLine();
                            dataNew = line.Split(' ');
                            if (dataNew.Length != 8)
                            {
                                Console.WriteLine("Enter your details again");
                                Array.Clear(dataNew, 0, dataNew.Length);
                            }
                            if(dataNew.Length == 8)
                            {
                                ch = true;
                                break;
                            }
                        }
                        
                        using (var connection = new Data.MyDbContext())
                        {
                            var deal = new Data.Tables.deal
                            {
                                dealId = Convert.ToInt32(dataNew[0]),
                                date = dataNew[1],
                                name = dataNew[2],
                                type = dataNew[3],
                                amount = Convert.ToInt32(dataNew[4]),
                                macler = dataNew[5],
                                customer = dataNew[6],
                                maclerId = Convert.ToInt32(dataNew[7])
                            };
                            connection.deals.Add(deal);
                            connection.SaveChanges();
                        }
                    }
                    if(table == "maclers")
                    {
                        Console.WriteLine("Enter data (maclerID, name, address, birthday (dd.mm.yyyy))");
                        bool ch = false;
                        while (ch == false)
                        {
                            string line = Console.ReadLine();
                            dataNew = line.Split(' ');
                            if (dataNew.Length != 4)
                            {
                                Console.WriteLine("Enter your details again");
                                Array.Clear(dataNew, 0, dataNew.Length);
                            }
                            if (dataNew.Length == 4)
                            {
                                ch = true;
                                break;
                            }
                        }

                        using (var connection = new Data.MyDbContext())
                        {
                            var macler = new Data.Tables.macler
                            {
                                maclerId = Convert.ToInt32(dataNew[0]),
                                name = dataNew[1],
                                address = dataNew[2],
                                birthday = dataNew[3]
                            };
                            connection.maclers.Add(macler);
                            connection.SaveChanges();
                        }
                    }
                    if(table == "goods")
                    {
                        Console.WriteLine("Enter data (goodID, name, type, price, supplier, store date (dd.mm.yyyy), amount, maclerID, dealID)");
                        bool ch = false;
                        while (ch == false)
                        {
                            string line = Console.ReadLine();
                            dataNew = line.Split(' ');
                            if (dataNew.Length != 9)
                            {
                                Console.WriteLine("Enter your details again");
                                Array.Clear(dataNew, 0, dataNew.Length);
                            }
                            if (dataNew.Length == 9)
                            {
                                ch = true;
                                break;
                            }
                        }

                        using (var connection = new Data.MyDbContext())
                        {
                            var good = new Data.Tables.good
                            {
                                goodId = Convert.ToInt32(dataNew[0]),
                                name = dataNew[1],
                                type = dataNew[2],
                                price = Convert.ToDouble(dataNew[3]),
                                supplier = dataNew[4],
                                storeDate = dataNew[5],
                                amount = Convert.ToInt32(dataNew[6]),
                                maclerId = Convert.ToInt32(dataNew[7]),
                                dealId = Convert.ToInt32(dataNew[8])
                            };
                            connection.goods.Add(good);
                            connection.SaveChanges();
                        }
                    }
                }
            }
        }
    }
}
