namespace UniBase.Models
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
            
            public string subjectValue { get; set; }
    }
}
