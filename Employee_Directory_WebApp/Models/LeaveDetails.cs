namespace Employee_Directory_WebApp.Models
{
    public class LeaveDetails
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime LeaveDate { get; set; }
        public string LeaveType { get; set; } // Casual, Sick, etc.
        public string Status { get; set; } // Approved, Pending, etc.
    }
}
