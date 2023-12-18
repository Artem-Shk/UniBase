using Unibase.Server.Models;
using UniBase.CORE.DataBaseManagers;
using UniBase.Models;

namespace UniBase.CORE
{
    public class JournalFabric
    {
        private Journal GroupJournal { get; set; }
        private  DBManager data_base_manager = DBManager.GetInstance();
        public JournalFabric()
        {
            collectData(28);
            GroupJournal = new Journal();
        }
        public void AuthKeys(int DekanId)
        {

        }
        //collected data from database

        public async Task createDataForFaculityAsync()
        {
            List<FaculityPackage> faculityJournal = new List<FaculityPackage>();
            var journals = await data_base_manager.GetJournalsByFaculity(0,28);

            if(journals is not null)
            {
                foreach(var journal in journals)
                {
                    var journalRecords = data_base_manager.GetAttandanceRecord(journal.key);
                    FaculityPackage barby = new FaculityPackage(journal);
                    if (journalRecords.Result.Count > 0)
                    {
                        barby.Attandance = AttadanceProcent(journalRecords.Result,barby.studentCount,barby.lectionHours);

                    }
                    faculityJournal.Add(barby);
                }
            }
        }
        private void collectData(int faculityID)
        {
            DBManager data_base_manager = DBManager.GetInstance();
        }
        public float? AttadanceProcent(List<AttendanceRecord> records, int student_count, int? lec_hours)
        {
            int absentCount = records.Count(r => r.subjectValue == "Н  "); 


            if (absentCount == 0 || student_count == 0 || lec_hours == 0)
            {
                return 100.0f;
            }

            float? result = 100 - (student_count * lec_hours) / (float)absentCount;
            return result;
        }
        public class FaculityPackage : JournalData 
        {
            public float? Attandance { get; set; }
            public string? page { get; set; }
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
}
