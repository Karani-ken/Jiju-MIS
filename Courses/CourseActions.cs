using Jiju_MIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.IO;

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
        public void DeleteCourse(char selectedCourse)
        {
            var newContent = "";
            string[] courses = File.ReadAllLines(path);
            foreach(var course in courses)
            {
                string[] Details = course.Split(',');
                if (!Details[0].Contains(selectedCourse))
                {
                    newContent += course + Environment.NewLine;
                  
                }

            }
            File.WriteAllText(path, newContent);
            Console.WriteLine("course deleted succesfully..");
         
        }
        public void UpdateCourse(char selectedCourse,string newCourseContent)
        {
            var newContent = "";
            string[] courses = File.ReadAllLines(path);
            foreach (var course in courses)
            {
                string[] Details = course.Split(',');
                if (Details[0].Contains(selectedCourse))
                {

                    newContent += newCourseContent + Environment.NewLine;
                    Console.WriteLine(course);
                }
                else
                {
                    newContent += course + Environment.NewLine;
                }

            }
            File.WriteAllText(path, newContent);
            Console.WriteLine("course deleted succesfully..");
        }
        public string selectedCourse(char selectedCourse)
        {
           
            string[] courses = File.ReadAllLines(path);
            foreach(var course in courses)
            {
                string[] courseDetails = course.Split(',');
                if (courseDetails[0].Contains(selectedCourse))
                {
                    Console.WriteLine(course.ToString());
                   string courseForPurchase = course;
                    return courseForPurchase;
                }
            }

            return null;
            
        }
    }
}
