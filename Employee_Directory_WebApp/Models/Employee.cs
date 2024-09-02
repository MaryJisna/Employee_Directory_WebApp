
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json.Serialization;

namespace Employee_Directory_WebApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string Address { get; set; }
        public DateTime DateOfJoining { get; set; }
        public int CTC { get; set; } // Cost to Company
        public int Salary { get; set; }
        public string TeamName { get; set; }
        public string ManagerName { get; set; }
        public int TotalExperience { get; set; } // Total experience in years and months
        public int InHouseExperience { get; set; } // Experience within the current company

        [JsonIgnore]
        [BindNever]
        public string ProfileImagePath { get; set; } // New property for storing the image file path

        [JsonIgnore]
        [BindNever]
        public List<LeaveDetails> Leaves { get; set; }
        [JsonIgnore]
        [BindNever]
        public List<Attendance> Attendances { get; set; }
    }
}

//using Microsoft.AspNetCore.Mvc.ModelBinding;
//using System.Text.Json.Serialization;

//namespace Employee_Directory_WebApp.Models
//{
//    public class Employee
//    {
//        public int Id { get; set; }
//        public string Name { get; set; }
//        public string Department { get; set; }
//        public string Position { get; set; }
//        public string Address { get; set; }
//        public DateTime DateOfJoining { get; set; }
//        public int CTC { get; set; } // Cost to Company
//        public int Salary { get; set; }
//        public string TeamName { get; set; }
//        public string ManagerName { get; set; }
//        public int TotalExperience { get; set; } // Total experience in years and months
//        public int InHouseExperience { get; set; } // Experience within the current company
//        [JsonIgnore]
//        [BindNever]
//        public List<LeaveDetails> Leaves { get; set; }
//        [JsonIgnore]
//        [BindNever]
//        public List<Attendance> Attendances { get; set; }
//    }
//}
