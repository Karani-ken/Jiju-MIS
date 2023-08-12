﻿using System.IO;
namespace Jiju_MIS.Login
{
    public class UserLogin
    {
        public void LoginUser()
        {
            Console.WriteLine("Welcome to the Jitu. Please Enter login Details to login");
            Console.WriteLine("Username:");
            string username = Console.ReadLine();
            Console.WriteLine("Password");
            string password = Console.ReadLine();            
            DetailsValidation(username);
            bool userAuthenticated = GetUser(username, password);
            if(userAuthenticated)
            {
                Console.WriteLine("Login Successfull");
            }
            else
            {
                Console.WriteLine("Login failed, Wrong credentials");
                LoginUser();
            }


        }
        public void DetailsValidation(string userName)
        {
            if(string.IsNullOrEmpty(userName))
            {
                Console.WriteLine("Invalid input");
                LoginUser();
            }
        }
        static bool GetUser(string username,string password)
        {
            string path = @"C:\Data\User.txt";
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
               string[] UsersDetails = line.Split(',');
                if(UsersDetails.Length == 3 && UsersDetails[0] == username && UsersDetails[1] == password)
                {
                    return true;
                }
            }

            return false;
        }

    }
}

