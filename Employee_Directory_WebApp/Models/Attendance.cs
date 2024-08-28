namespace Employee_Directory_WebApp.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
        public string Remark { get; set; }
    }
}
