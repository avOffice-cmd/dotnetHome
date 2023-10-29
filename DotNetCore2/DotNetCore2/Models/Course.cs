﻿namespace DotNetCore2.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Code { get; set; }

        public ICollection<StudentCourse> Courses { get; set; }
    }
}