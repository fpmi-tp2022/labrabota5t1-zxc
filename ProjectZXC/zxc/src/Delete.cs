using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zxc.Data;

namespace zxc
{
    class Delete
    {
        public static void StartDelete()
        {
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - Delete");
            bool check = false;
            MyDbContext context = new MyDbContext();
            while (check == false)
            {
                Console.WriteLine("Select an action");
                int num = Convert.ToInt32(Console.ReadLine());
                if (num == 0)
                {
                    check = true;
                    break;
                }
                if (num == 1)
                {
                    Console.WriteLine("Enter the name of the table you want to refer to (standard tables: deals, maclers, goods)");
                    string line = Console.ReadLine();

                    if(line == "deals")
                    {
                        Console.WriteLine("Enter the id you want to delete");
                        int id = Convert.ToInt32(Console.ReadLine());
                        using (var context1 = new MyDbContext())
                        {
                            string stringComand = string.Format("DELETE FROM deals WHERE dealId = {0}", id);
                            context1.Database.ExecuteSqlCommand(stringComand);
                        }
                    }
                    if(line == "maclers")
                    {
                        Console.WriteLine("Enter the id you want to delete");
                        int id = Convert.ToInt32(Console.ReadLine());
                        using (var context1 = new MyDbContext())
                        {
                            string stringComand = string.Format("DELETE FROM maclers WHERE dealId = {0}", id);
                            context1.Database.ExecuteSqlCommand(stringComand);
                        }
                    }
                    if(line == "goods")
                    {
                        Console.WriteLine("Enter the id you want to delete");
                        int id = Convert.ToInt32(Console.ReadLine());
                        using (var context1 = new MyDbContext())
                        {
                            string stringComand = string.Format("DELETE FROM goods WHERE dealId = {0}", id);
                            context1.Database.ExecuteSqlCommand(stringComand);
                        }
                    }
                }
            }
        }
    }
}
