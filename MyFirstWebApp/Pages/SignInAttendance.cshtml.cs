using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFirstWebApp.Data;
using System.Data;
using MyFirstWebApp.Data;
using MyFirstWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MyFirstWebApp.Pages
{
    public class SignInAttendanceModel : PageModel
    {

        private readonly ApplicationDbContext _context;

        public SignInAttendanceModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Attendance> Attendance { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Attendance != null)
            {
                Attendance = await _context.Attendance
                    .Include(s => s.Student)
                    .AsNoTracking()
                    .ToListAsync();
            }
        }

        public RedirectToPageResult OnPost()
        {

            var RFID = Request.Form["RFID"];
            var CurrentTime = DateTime.Now;

            //Now we need to look up what Student ID is from the RFID table by
            //querying (asking) the database "which student ID has this RFID that
            //was just scanned in?"

            var DatabaseQuery = "SELECT StudentID FROM RFID WHERE RFID=" + RFID;

            int RFIDInt = Convert.ToInt32(RFID);

            var QueryResponse = _context.RFIDCard
                .Where (x => x.RFID == RFIDInt)
                .FirstOrDefault();
            if (QueryResponse != null)
            {
                // Hooray!
                // Once we get the student ID, we then write into the Attendance Table
                // The Student ID and the CurrentTime

                var attendance = new Attendance();
                attendance.StudentID = QueryResponse.StudentID;
                attendance.AttDateTime = CurrentTime;

                _context.Attendance.Add(attendance);
                _context.SaveChanges();
                return RedirectToPage("SignInAttendance");


            }
            else
            {
                // Boo!
                // Something went wrong and we can show an error message

                // then reload the page
                return RedirectToPage("SignInAttendance");
            }





        }
    }
}
