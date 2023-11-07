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
        public string PrepodName { get; set; }
        public string GroupName { get; set; }
        public int StudentCount { get; set; }
        public int semesterHours { get; set; }
        public int semesterToday { get; set; }
        public int MidleAttendance { get; set; }
        List<AttendanceRecord> recordList;
    }
}

