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
        public List<LeaveDetails> Leaves { get; set; }
        public List<Attendance> Attendances { get; set; }
    }
}
