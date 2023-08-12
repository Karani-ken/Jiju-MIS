using Jiju_MIS.Login;
using Jiju_MIS.Register;


namespace Jiju_MIS.DefaultPage
{
    public class HomePage
    {
        public void LoadingPage()
        {

            //temporary solution
            Console.WriteLine("please select option 1 or 2 to continue: \n 1.Register \n 2.login\n....");
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
                login.loginUser();
            }
            else
            {
                Console.WriteLine("Invelid option");
                LoadingPage();
            }
        }
    }
}
