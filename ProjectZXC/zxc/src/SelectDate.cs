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
    class SelectDate
    {
        public static void StartSelectDate() {
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - Search for a deal by date");

            bool checkOperation = false;

            while(checkOperation == false)
            {
                try
                {
                    int n = Convert.ToInt32(Console.ReadLine());
                    if (n == 0)
                    {
                        checkOperation = true;
                        break;
                    }
                    if (n == 1)
                    {
                        Console.WriteLine("Enter date (format dd.mm.yyyy)");
                        var date = Console.ReadLine();
                        if (date.Length == 0)
                        {
                            Console.WriteLine("Error. Empty string");
                            Console.WriteLine("Select an action");
                        }
                        else
                        {
                            MyDbContext context = new MyDbContext();
                            var data = context.deals.ToList();
                            bool check = false;


                            foreach (var item in data)
                            {
                                if (date == item.date)
                                {
                                    Console.WriteLine(string.Format("Date: {0}, name: {1}, type: {2}, amount: {3}, macler: {4}, customer: {5}, maclerID: {6}",
                                        item.date, item.name, item.type, item.amount, item.macler, item.customer, item.maclerId));
                                    check = true;
                                }
                            }
                            if (check == false)
                            {
                                Console.WriteLine("There were no transactions on this day");
                            }
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Select an action");
                }
            }
        }
    }
}
