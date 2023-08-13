using Jiju_MIS.Courses;
using Jiju_MIS.Models;
using Jiju_MIS.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jiju_MIS.Login
{
    public class AdminLogin
    {
        CourseActions courses = new CourseActions();
        PurchaseCourse purchase = new PurchaseCourse();
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
                Console.WriteLine("Login Successfull\n\n");
                Console.WriteLine("select an option to proceed:\n 1.View Courses\n 2.Add new course\n " +
                    "3.Delete course\n 4.Update Course\n 5.View Analytics");
                var option = Console.ReadLine();
                int selectedOption = Convert.ToInt32(option);
                if (selectedOption == 1)
                {
                   
                    Console.WriteLine("Coursename,price,decription");
                    courses.DisplayCourses();
                }
                else if(selectedOption == 2)
                {
                    courses.CourseRegistration();

                }else if(selectedOption == 3)
                {
                    DeleteCourseModule();
                }else if(selectedOption ==4)
                {
                    UpdateCourseModule();
                }else if(selectedOption ==5)
                {
                    purchase.ViewAnalytics();
                }
                

                
            }
            else
            {
                Console.WriteLine("Login failed, Wrong credentials or role is not admin");
                LoginAdmin();
            }


        }
        public void DeleteCourseModule()
        {
            Console.WriteLine("Delete a course");
            courses.DisplayCourses();
            Console.WriteLine("Select a course to delete...");
            char selectedCourse = Char.Parse(Console.ReadLine());
            courses.DeleteCourse(selectedCourse);

        }
        public void UpdateCourseModule()
        {
            Console.WriteLine("Update a course");
            courses.DisplayCourses();
            Console.WriteLine("Select a course to update...");
            char selectedCourse = Char.Parse(Console.ReadLine());
            string coursename, description;
            int Id, price;
            Console.WriteLine("Course Name:");
            coursename = Console.ReadLine();
            Console.WriteLine("Course Id:");
            Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Price:");
            price = int.Parse(Console.ReadLine());
            Console.WriteLine("Course Description");
            description = Console.ReadLine();
            var course = new CourseData() { Id = Id, coursename = coursename, price = price, description = description };
            string courseDetails = $"{course.Id},{course.coursename},{course.price},{course.description}\n";
            courses.UpdateCourse(selectedCourse,courseDetails);
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
                if (AdminDetails.Length == 3 && AdminDetails[0] == username && AdminDetails[1] == password && AdminDetails[2].Contains("admin"))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
