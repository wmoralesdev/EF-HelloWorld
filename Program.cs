using System;
using System.Collections.Generic;
using System.Linq;
using HelloWorld.Context;
using HelloWorld.Models;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new PooContext())
            {
                // Emptying Table first
                db.Courses.RemoveRange(db.Courses);
                db.Students.RemoveRange(db.Students);
                
                var availableCourses = new List<Course>()
                {
                    new Course
                    {
                        CourseName = "Math",
                        Students = new List<Student>()
                        {
                            new Student { FullName = "Walter" },
                            new Student { FullName = "Daniela" },
                        }
                    },
                    new Course
                    {
                        CourseName = "Science",
                        Students = new List<Student>()
                        {
                            new Student { FullName = "Ronaldios" },
                            new Student { FullName = "Enma" },
                            new Student { FullName = "Miguel" },
                        }
                    },
                    new Course
                    {
                        CourseName = "Robotics",
                        Students = new List<Student>()
                        {
                            new Student { FullName = "Xiomara" },
                        }
                    }
                };

                availableCourses.ForEach(course => {
                    db.Add(course);
                });

                db.SaveChanges();

                var course = db.Courses
                    .OrderBy(c => c.CourseId)
                    .ToList();

                var students = db.Students
                    .OrderBy(s => s.StudentId)
                    .ToList();

                var scienceStudents = db.Courses
                    .Where(c => c.CourseName.ToLower().Equals("science"))
                    .SelectMany(c => c.Students)
                    .ToList();

                course.ForEach(c => Console.WriteLine($"Id: {c.CourseId}, Name: {c.CourseName}"));
                Console.WriteLine();

                students.ForEach(s => Console.WriteLine($"Id: {s.StudentId}, Name: {s.FullName}"));
                Console.WriteLine();

                scienceStudents.ForEach(sc => Console.WriteLine($"Id: {sc.StudentId}, Name: {sc.FullName}"));
            }
        }
    }
}


//Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;