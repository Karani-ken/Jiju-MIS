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
            var userDetails= username + password;
            getUser(userDetails);


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
            string line;
            StreamReader file = new StreamReader(@"C:\Data\User.txt");
            while ((line = file.ReadLine()) != null)
            {
                //Splits each line into words
                String[] words = line.Split(' ');
                //try matching usernames to find the exact username
                if (words.Contains(user))
                {
                    
                    Console.WriteLine(user);
                   
                }

            }

        }

    }
}

