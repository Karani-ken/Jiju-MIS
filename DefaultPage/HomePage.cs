using Jiju_MIS.Login;
using Jiju_MIS.Register;


namespace Jiju_MIS.DefaultPage
{
    public class HomePage
    {
        public void LoadingPage()
        {

            //temporary solution
            Console.WriteLine("Welcome to the JITU. Please select option 1 or 2 to continue: \n 1.Register \n 2.login\n....");
            var option = Console.ReadLine();
            bool convertedOption = int.TryParse(option, out int converted);
            if (convertedOption && converted == 1)
            {
                UserRegistration register = new UserRegistration();
                register.userRegistration();
            }
            else if (convertedOption && converted == 2)
            {
                UserLogin login = new UserLogin();
                AdminLogin admin = new AdminLogin();
                Console.WriteLine("Select your role: \n 1.Admin \n 2. User");
                var roleOption = Console.ReadLine();
                bool roleConverted = int.TryParse(option, out int convertRole);
                if(roleConverted && convertRole == 1)
                {
                    admin.LoginAdmin();
                }else if(roleConverted && convertRole == 2)
                {
                    login.LoginUser();
                }
                else
                {
                    Console.WriteLine("Invalid option");
                    LoadingPage();
                }
            }
            else
            {
                Console.WriteLine("Invelid option");
                LoadingPage();
            }
        }
    }
}
