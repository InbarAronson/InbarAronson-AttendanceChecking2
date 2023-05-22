using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFirstWebApp.Models
{
    public class RFIDCard
    {
        [ForeignKey ("Student")]
        public int StudentID { get; set; }
        [Key]
        public int RFID { get; set; }
    }
}
