using System.IO;
namespace Jiju_MIS.Login
{
    public class UserLogin
    {
        public void loginUser()
        {
            Console.WriteLine("Welcome to the Jitu. Please Enter login Details to login");
            Console.WriteLine("Username:");
            var username = Console.ReadLine();
            Console.WriteLine("Password");
            var password = Console.ReadLine();
            DetailsValidation(username);
            
           


        }
        public void DetailsValidation(string userName)
        {
            if(string.IsNullOrEmpty(userName))
            {
                Console.WriteLine("Invalid input");
                loginUser();
            }
        }
        public void getUser(string user)
        {
            string path = @"C:\Data\User.txt";
            string[] Users = File.ReadAllLines(path);

            string pathUsername  = Users[1];
            string pathPassword = Users[2];
            string pathRole = Users[3];

            foreach(var item in Users)
            {
                if(pathUsername == user.n)
            }

        }

    }
}

