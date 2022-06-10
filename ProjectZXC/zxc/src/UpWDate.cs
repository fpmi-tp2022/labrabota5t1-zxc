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
    public class UpWDate
    {
        public static int[] dmy(string line)
        {
            int[] a = new int[3];
            int d, m, y;
            string[] date = line.Split('.');
            d = Convert.ToInt32(date[0]);
            m = Convert.ToInt32(date[1]);
            y = Convert.ToInt32(date[2]);
            a[0] = d;
            a[1] = m;
            a[2] = y;
            return a;
        }
        public static bool CheckDate(string line1, int[] arr)
        {
            int[] arr2 = dmy(line1);
            if (arr2[2] < arr[2]) return true;
            if (arr2[2] > arr[2]) return false;
            if (arr2[1] < arr[1]) return true;
            if (arr2[1] > arr[1]) return false;
            if (arr2[0] < arr[0]) return true;
            if (arr2[0] > arr[0]) return false;
            return false;
        }
        public static void UpWDateStart()
        {
            MyDbContext context = new MyDbContext();
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - Update table");
            bool checkOperations = false;

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
                    Console.WriteLine("Enter time period (dd.mm.yyyy)");
                    string line = Console.ReadLine();
                    int[] arr;
                    arr = dmy(line);
                    var data = context.goods.ToList();
                    var data1 = context.deals.ToList();
                    foreach (var item in data)
                    {
                        foreach(var item1 in data1)
                        {
                            if(item.dealId == item1.dealId)
                            {
                                if (CheckDate(item1.date, arr))
                                {
                                    item.amount -= item1.amount;
                                    context.SaveChanges();
                                    if(item.amount == 0)
                                    {
                                        using (var context1 = new MyDbContext())
                                        {
                                            string stringComand = string.Format("DELETE FROM goods WHERE dealId = {0}", item.dealId);
                                            context1.Database.ExecuteSqlCommand(stringComand);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
