


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
            var isValid = DetailsValidation(UserName, Password, confirmPwd);
              if(isValid == 0)
                {
                    AddUser(UserName, Password);
                }
                else
                {
                Console.WriteLine("Something went wrong");
            }


            return users;
        }
        public int DetailsValidation(string userName, string Password, string confirmPwd)
        {
           if(userName == null  || Password == null || confirmPwd == null)
            {
                Console.WriteLine("Invalid Input!!");
                userRegistration();
            }
           else if(Password != confirmPwd)
            {
                Console.WriteLine("Passwords do not Match!!");
                
            }
            else
            {
                return 0;
            }
            return 0;
        }
        public void AddUser(string username,  string password)
        {
            Random rand = new Random();
            int id = rand.Next();
             var User = new UserData() { Id = id, userName = username, password = password, Role = Role.user };
           // var User = "UserName: " + username + "Password: " + password + "Role:" + "user";
            
            //create a path
            var path = @"C:\Data\User.txt";
            string userDetails =$"{User.Id}\t\t{User.userName}\t\t{User.password}\t\t{User.Role} \n";
            File.AppendAllText(path, userDetails);
            Console.WriteLine("Registration successfull...");
           
        }
        
    }
}
