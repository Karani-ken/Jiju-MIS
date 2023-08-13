using Jiju_MIS.Courses;
using Jiju_MIS.Purchases;
using System.IO;
namespace Jiju_MIS.Login
{
    public class UserLogin
    {
        PurchaseCourse purchasedCourse = new PurchaseCourse();

        CourseActions courses = new CourseActions();
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
                
                Console.WriteLine("Select an option:\n 1: View All courses \n 2: My Courses");
                var options = Console.ReadLine();
                bool selectedOption = int.TryParse(options, out int convertedOption);
                if(selectedOption && convertedOption == 1)
                {

                    Console.WriteLine("Coursename,price,decription");
                    courses.DisplayCourses();                  
                    purchasedCourse.CoursePurchase(username);
                }
                else if(selectedOption && convertedOption == 2)
                {
                    purchasedCourse.ViewAnalytics(username.ToLower());

                }
                else
                {
                    Console.WriteLine("Invalid option");

                }
            }
            else
            {
                Console.WriteLine("Login failed, Wrong credentials");
                LoginUser();
            }


        }
        public void ViewCourses()
        {
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

