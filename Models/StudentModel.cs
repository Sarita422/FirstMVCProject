using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentDetails.Models
{
    public class StudentModel
    {
        public int? ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
    }
}