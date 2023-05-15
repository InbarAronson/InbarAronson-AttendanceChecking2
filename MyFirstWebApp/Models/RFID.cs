using System.ComponentModel.DataAnnotations;

namespace MyFirstWebApp.Models
{
    public class RFIDCard
    {
        public int StudentID { get; set; }
        [Key]
        public int RFID { get; set; }
    }
}
