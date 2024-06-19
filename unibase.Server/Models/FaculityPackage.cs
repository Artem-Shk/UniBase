using UniBase.Models;

namespace Unibase.Server.Models
{
    public class FaculityPackage : JournalData
    {
        public float? Attandance { get; set; }
        public string? page { get; set; }
        public float midelEval { get; set; }
        public FaculityPackage(JournalData daddy)
        {
            this.key = daddy.key;
            this.lectionType = daddy.lectionType;
            this.academicYear = daddy.academicYear;
            this.discipline = daddy.discipline;
            this.lectionHours = daddy.lectionHours;
            this.GroupName = daddy.GroupName;
            this.semester = daddy.semester;
            this.teacherName = daddy.teacherName;
            this.teacherCode = daddy.teacherCode;
            this.studentCount = daddy.studentCount;
        }
    }
}
