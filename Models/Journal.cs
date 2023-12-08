namespace UniBase.Models
{
    public class Journal
    {
        public string JournalName { get; set; }
        public string PrepodName { get; set; }
        public string GroupName { get; set; }
        public int StudentCount { get; set; }
        public int semesterHours { get; set; }
        public int semesterToday { get; set; }
        public int MidleAttendance { get; set; }

        List<AttendanceRecord>? recordList;
    }
}

