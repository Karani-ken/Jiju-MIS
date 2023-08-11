


using Jiju_MIS.Models;
using System.Numerics;

namespace Jiju_MIS.Register
{
    public class UserRegistration
    {
        List<UserData> users = new List<UserData>();
        public List<UserData> userRegistration()
        {
          
            //add a new users
            Console.WriteLine("Welcome to the Jitu ltd. Please Register to continue:");
            string UserName, Password, confirmPwd;
            Console.WriteLine("Enter the UserName:");
            UserName= Console.ReadLine();
            Console.WriteLine("Enter your Password:");
            Password= Console.ReadLine();
            Console.WriteLine("Please confirm your Password:");
            confirmPwd=Console.ReadLine();
           DetailsValidation(UserName, Password, confirmPwd);
           AddUser(UserName, Password);
            
            return users;
        }
        public void DetailsValidation(string userName, string Password, string confirmPwd)
        {
           if(userName == null  || Password == null || confirmPwd == null)
            {
                Console.WriteLine("Invalid Input!!");
                userRegistration();
            }
           else if(Password != confirmPwd)
            {
                Console.WriteLine("Passwords do not Match!!");
                userRegistration();
            }
            else
            {
                
            }
        }
        public void AddUser(string username,  string password)
        {
            // var User = new UserData() { Id = 1, userName = UserName, password = Password, Role = Role.user };
            var User = "UserName: " + username + "Password: " + password + "Role:" + "user";

            //create a path
            var path = @"C:\Data\User.txt";
            File.AppendAllText(path, User);
            Console.WriteLine("Registration successfull...");
        }
    }
}
