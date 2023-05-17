namespace MyFirstWebApp.Models
{
    public class Attendance
    {
        public int AttendanceID { get; set; }
        public int StudentID { get; set; }
        public ICollection<Student> Student { get; set; }
        public DateTime AttDateTime { get; set; }
    }
}
