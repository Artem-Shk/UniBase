namespace UniBase.Models
{
    public class Journal
    {
        public class AttendanceRecord
        {
            public int Id { get; set; }
            public int StudentId { get; set; }
            public string StudentName { get; set; }
            public int TeacherId { get; set; }
            public string TeacherName { get; set; }
            public int SubjectId { get; set; }
            public DateTime Date { get; set; }
            public bool IsPresent { get; set; }
        }

        public string JournalName { get; set; }
        string PrepodName { get; set; }
        string GroupName { get; set; }
        int StudentCount { get; set; }
        int semesterHours { get; set; }
        int semesterToday { get; set; }
        int MidleAttendance { get; set; }
        List<AttendanceRecord> recordList;

    }
}

