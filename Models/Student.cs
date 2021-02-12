using System.Collections.Generic;

namespace HelloWorld.Models
{
    public class Student
    {
        public Student()
        {
            this.Courses = new List<Course>();
        }

        public int StudentId { get; set; }

        public string FullName { get; set; }

        public List<Course> Courses { get; set; }

        public virtual int EnrolledCourses { get => Courses.Count; }
    }
}