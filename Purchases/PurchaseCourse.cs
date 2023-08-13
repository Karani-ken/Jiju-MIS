using Jiju_MIS.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jiju_MIS.Purchases
{
    public class PurchaseCourse
    {
        private int Balance=20000;
        string path = @"C:\Data\Analytics.txt";
        CourseActions courses = new CourseActions();
        string userName;
        public void CoursePurchase(string username)
        {
            userName = username;
            courses.DisplayCourses();
            Console.WriteLine("Select a course to purchase:");
            var option = Console.ReadLine();
            char selectedOption = Convert.ToChar(option);
            string selectedCourse = courses.selectedCourse(selectedOption);
            if (selectedCourse != null)
            {
                string[] Details = selectedCourse.Split(',');
                int price = Convert.ToInt32(Details[2]);
                Console.WriteLine(price);
                if(Balance >= price)
                {
                    var newline = "\n";
                    File.AppendAllText(path, selectedCourse +",Purchased by:," + username + newline);
                    Console.WriteLine("Course purchased successfully");
                }
                else
                {
                    int topUpBalance = price - Balance;
                    Console.WriteLine($"Insufficient Balance.Please top up" +
                        $" KES.{topUpBalance} to continue with the purchase");
                    TopUp();
                }



            }
            else
            {
                Console.WriteLine("Not enough balance");
                CoursePurchase(username);
            }
        }
        public void ViewAnalytics()
        {
            string[] Purchases = File.ReadAllLines(path);
            foreach(var purchase in Purchases)
            {
                Console.WriteLine(purchase);
            }
        }
        public void ViewAnalytics(string username)
        {
            string[] Purchases = File.ReadAllLines(path);
            foreach (var purchase in Purchases)
            {
                string[] myCourses = purchase.Split(",");
                if(myCourses != null && myCourses.Length > 0 && myCourses.Contains(username))
                {
                    Console.WriteLine(purchase);

                }                           

            }
           // Console.WriteLine("You have not purchased any courses");

        }

        public void TopUp()
        {
            int amount;
            Console.WriteLine("Enter the Amount to top up");
            amount = int.Parse(Console.ReadLine());
            Balance += amount;
            Console.WriteLine($"Top Up of Kes.{amount} successfull current Balance is Kes.{Balance}");
            CoursePurchase(userName);
        }
    }
}
