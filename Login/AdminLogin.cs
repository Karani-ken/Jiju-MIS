using Jiju_MIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jiju_MIS.Login
{
    public class AdminLogin
    {
  
        public void LoginAdmin()
        {
            Console.WriteLine("Welcome to the Jitu. Please Enter login Details to login");
            Console.WriteLine("Username:");
            string username = Console.ReadLine();
            Console.WriteLine("Password");
            string role = "admin";
            string password = Console.ReadLine();
            DetailsValidation(username);
            bool adminAuthenticated = GetAdmin(username, password);
            if (adminAuthenticated)
            {
                Console.WriteLine("Login Successfull");
            }
            else
            {
                Console.WriteLine("Login failed, Wrong credentials or role is not admin");
                LoginAdmin();
            }


        }
        public void DetailsValidation(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                Console.WriteLine("Invalid input");
                LoginAdmin();
            }
        }
        static bool GetAdmin(string username, string password)
        {
            string path = @"C:\Data\User.txt";
            string[] lines = File.ReadAllLines(path);
            
            foreach (string line in lines)
            {
                string[] AdminDetails = line.Split(',');
                if (AdminDetails.Length == 3 && AdminDetails[0] == username && AdminDetails[1] == password && AdminDetails[2]== "admin")
                {
                    return true;
                }
            }

            return false;
        }
    }
}
