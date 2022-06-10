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
    class Program
    {
        static void Main(string[] args)
        {
            if (Authorization.AuthorizationStart())
            {
                Console.WriteLine("Select an action");
                Console.WriteLine("0 - Exit");
                Console.WriteLine("1 - Select");
                Console.WriteLine("2 - Select date");
                Console.WriteLine("3 - Insert");
                Console.WriteLine("4 - Delete");
                Console.WriteLine("5 - Update maclers");
                Console.WriteLine("6 - Update a table with a date");

                bool check = false;
                while (check == false)
                {
                    int num = Convert.ToInt32(Console.ReadLine());
                    if (num > 6 || num < 0)
                    {
                        Console.WriteLine("Error. Try again...");
                    }
                    if (num == 0)
                    {
                        check = true;
                    }
                    if (num == 1)
                    {
                        Select.SelectStart();
                    }
                    if (num == 2)
                    {
                        SelectDate.StartSelectDate();
                    }
                    if (num == 3)
                    {
                        Insert.StartInsert();
                    }
                    if (num == 4)
                    {
                        Delete.StartDelete();
                    }
                    if (num == 5)
                    {
                        UpdateMaclers.StartUpdateMaclers();
                    }
                    if (num == 6)
                    {
                        UpWDate.UpWDateStart();
                    }
                }
            }
        }
    }
}
