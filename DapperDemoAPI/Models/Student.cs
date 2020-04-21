using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemoAPI.Models
{
    public class Student
    {
        public int Age { get; set; }

        public string StuName { get; set; }

        public string Subject { get; set; }
    }

    public class UniversityStu
    {
        public int Age { get; set; }

        public string StuName { get; set; }

        public string Major { get; set; }
    }

    public enum Gender
    {
        male = 1,
        female = 2
    }
}
