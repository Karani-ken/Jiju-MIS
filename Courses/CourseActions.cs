using Jiju_MIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jiju_MIS.Courses
{
    public class CourseActions
    {
        List<CourseData> courses = new List<CourseData>();
        string path = @"C:\Data\Courses.txt";

        public List<CourseData> CourseRegistration()
        {
            Console.WriteLine("Add a new course.\n Enter the course details:");
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
            if(coursename==null && price== 0 && description == null)
            {
                Console.WriteLine("Fields cannot be null...");
                CourseRegistration();
            }
            else
            {
                AddDetails(Id,coursename,price,description);
            }
            return courses;
        }
        public void AddDetails(int id ,string coursename, int price, string description)
        {
            //Random rand = new Random();
            //int id = rand.Next();
            var course = new CourseData() {Id=id ,coursename= coursename, price = price, description=description };
            // var User = "UserName: " + username + "Password: " + password + "Role:" + "user";

            //create a path
            string courseDetails = $"{course.Id},{course.coursename},{course.price},{course.description}\n";
            File.AppendAllText(path, courseDetails);
            Console.WriteLine("New Course added successfully...");
            Console.WriteLine(courseDetails);
        }
        public void DisplayCourses()
        {

            string[] courses = File.ReadAllLines(path);

            foreach (var course in courses)
            {
                Console.WriteLine(course.ToString());
            }

        }
        public void selectedCourse(int selectedCourse)
        {

            string[] courses = File.ReadAllLines(path);
            foreach(var course in courses)
            {

            }
        }
    }
}
