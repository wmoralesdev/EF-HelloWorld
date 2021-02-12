using System.Collections.Generic;

namespace HelloWorld.Models
{
    public class Course
    {
        public Course() {
            Students = new List<Student>();
        }
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public int MaxCapacity { get; set; }

        public List<Student> Students { get; set; }

        public virtual int EnrolledStudents { get => Students.Count; }
    }
}