using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace zxc
{
    class Authorization
    {
        public static bool AuthorizationStart()
        {
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - Sign In");
            Console.WriteLine("2 - Sign Up");

            bool check = false;
            while(check == false)
            {
                Console.WriteLine("Select an action");
                try
                {
                    int num = Convert.ToInt32(Console.ReadLine());
                    if (num == 0)
                    {
                        break;
                    }
                    if (num == 1)
                    {
                        Console.WriteLine("Enter login");
                        string log = Console.ReadLine();
                        Console.WriteLine("Enter password");
                        string pas = Console.ReadLine();
                        ushort secretKey = 0x0088;
                        string strlog = EncodeDecrypt(log, secretKey);
                        string strpas = EncodeDecrypt(pas, secretKey);

                        bool ac = false;
                        string line;
                        StreamReader sr = new StreamReader("logpas.txt");
                        while (ac == false)
                        {
                            if ((line = sr.ReadLine()) != null)
                            {
                                string[] b = line.Split(' ');
                                if (b[0] == strlog && b[1] == strpas)
                                {
                                    check = true;
                                    sr.Close();
                                    return true;
                                }
                            }
                            else
                            {
                                ac = true;
                            }
                        }
                        if (ac == true) Console.WriteLine("Wrong login or password");
                        sr.Close();
                    }
                    if (num == 2)
                    {
                        StreamWriter sw = new StreamWriter("logpas.txt");
                        Console.WriteLine("Enter login");
                        string log = Console.ReadLine();
                        Console.WriteLine("Enter password");
                        string pas = Console.ReadLine();
                        ushort secretKey = 0x0088;
                        string strlog = EncodeDecrypt(log, secretKey);
                        string strpas = EncodeDecrypt(pas, secretKey);
                        string res = strlog + " " + strpas;
                        sw.WriteLine(res);
                        sw.Close();
                    }
                }
                catch
                {
                    Console.WriteLine("Error. Try again...");
                }
                
            }
            return false;
        }
 
        public static string EncodeDecrypt(string str, ushort secretKey)
        {
            var ch = str.ToArray(); 
            string newStr = "";     
            foreach (var c in ch)  
                newStr += TopSecret(c, secretKey);
            return newStr;
        }
 
        public static char TopSecret(char character, ushort secretKey)
        {
            character = (char)(character ^ secretKey); 
            return character;
        }
 
    }
}
