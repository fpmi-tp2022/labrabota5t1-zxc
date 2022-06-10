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
    class Select
    {
        public static void SelectStart()
        {
            MyDbContext context = new MyDbContext();
            Console.WriteLine("Enter select operation");
            Console.WriteLine("0 - exit");
            Console.WriteLine("1 - information about the quantity sold and the total cost for the specified period.");
            Console.WriteLine("2 - a list of firms-buyers indicating information on the number of units \nand the cost of goods purchased by them for each.");
            Console.WriteLine("3 - which type of product that is in the greatest demand.");
            Console.WriteLine("4 - maclers who have made the maximum number of transactions - information \nabout him and supplier firms.");
            Console.WriteLine("5 - for each supplying company - a list of maclers with information on the \nquantity and cost of goods sold by them for each macler.");

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
                    var data = context.goods.ToList();
                    int amount = 0;
                    int allprice = 0;
                    foreach (var item in data)
                    {
                        amount += Convert.ToInt32(item.amount);
                        allprice += Convert.ToInt32(item.amount) * Convert.ToInt32(item.price);
                        Console.WriteLine(string.Format("Product Name: {0}, amount: {1}, sum price: {2}",
                            item.name, Convert.ToInt32(item.amount), Convert.ToInt32(item.amount) * Convert.ToInt32(item.price)));
                    }
                    Console.WriteLine(string.Format("Amount: {0}, sum price: {1}", amount, allprice));
                }

                if (num == 2)
                {
                    var data = context.deals.ToList();
                    var data2 = context.goods.ToList();
                    foreach (var item in data)
                    {
                        var price = 0;
                        foreach (var pr in data2)
                        {
                            if (item.dealId == pr.dealId)
                            {
                                price = Convert.ToInt32(pr.price);
                            }
                        }
                        var name = item.name;
                        var customer = item.customer;
                        var amount = item.amount;
                        Console.WriteLine(string.Format("Product name: {0}, customer: {1}, amount: {2}, price: {3}",
                            name, customer, amount, price));
                    }
                }

                if (num == 3)
                {
                    var data = context.goods.ToList();
                    var data2 = context.deals.ToList();
                    int index = 0;
                    int max = 0;
                    int i = 0;
                    foreach (var item in data)
                    {
                        if (item.amount > max)
                        {
                            max = item.amount;
                            index = i;
                        }
                        ++i;
                    }

                    var item1 = data[index];
                    string companyName;
                    int dealid = item1.dealId;

                    foreach (var q in data2)
                    {
                        if (dealid == q.dealId)
                        {
                            companyName = q.customer;
                            Console.WriteLine(string.Format("Customer: {0}, amount: {1}, price: {2}", companyName, item1.amount, item1.price));
                            break;
                        }
                    }
                }
                if (num == 4)
                {
                    var data = context.deals.ToList();
                    int maxAmount = 0;
                    int maclerId = 0;
                    foreach (var item in data)
                    {
                        if (item.amount > maxAmount)
                        {
                            maxAmount = item.amount;
                            maclerId = item.maclerId;
                        }
                    }

                    var data2 = context.maclers.ToList();
                    var data3 = context.goods.ToList();

                    foreach (var item2 in data2)
                    {
                        if (maclerId == item2.maclerId)
                        {
                            Console.WriteLine(string.Format("Name: {0}, address: {1}, birthday: {2}", item2.name, item2.address, item2.birthday));
                            break;
                        }
                    }

                    foreach (var item3 in data3)
                    {
                        if (maclerId == item3.maclerId)
                        {
                            Console.WriteLine(string.Format("Product name: {0}, type: {1}, price: {2}, store date: {3}, amount: {4}",
                                item3.name, item3.type, item3.price, item3.storeDate, item3.amount));
                        }
                    }
                }

                if (num == 5)
                {
                    var data = context.maclers.ToList();
                    var data2 = context.goods.ToList();

                    foreach (var item in data)
                    {
                        bool check = false;
                        int maclerId = (int)item.maclerId;
                        foreach (var item2 in data2)
                        {
                            if (maclerId == item2.maclerId)
                            {
                                Console.WriteLine(string.Format("Macler: {0}, amount: {1}, price: {2}", item.name, item2.amount, item2.price));
                                check = true;
                                break;
                            }
                        }
                        if (check == false)
                        {
                            Console.WriteLine(string.Format("Macler: {0}, amount: {1}, price: {2}", item.name, 0, 0));
                        }

                    }
                }
                Console.WriteLine("Something else?");
            }
        }
    }
}
