using Unibase.Server.Models;
using UniBase.CORE.DataBaseManagers;
using UniBase.Models;

namespace UniBase.CORE
{
    public class JournalFabric
    {
        private Journal GroupJournal { get; set; }
        private  DBManager data_base_manager = DBManager.GetInstance();
        public JournalFabric(int faculityId)
        {
            collectData(faculityId);
            GroupJournal = new Journal();
        }
        public void AuthKeys(int DekanId)
        {
        }
        //collected data from database

        public async Task<List<FaculityPackage>> createDataForFaculityAsync()
        {
            List<FaculityPackage> faculityJournal = new List<FaculityPackage>();
            var journals = await data_base_manager.GetJournalsByFaculity(0,28);
            if(journals is not null)
            {
                foreach(var journal in journals)
                {
                    var journalRecords = await data_base_manager.GetAttandanceRecord(journal.key);
                    FaculityPackage pack = new FaculityPackage(journal);
                    if (journalRecords.Count > 0)
                    {
                        pack.Attandance =  AttadanceProcent(journalRecords, pack.studentCount, pack.lectionHours);
                        pack.midelEval = MidleValue(journalRecords);
                    }
                    faculityJournal.Add(pack);
                }
            }
            return faculityJournal;
        }

        private void collectData(int faculityID)
        {
            DBManager data_base_manager = DBManager.GetInstance();
        }
        public float? AttadanceProcent(List<AttendanceRecord> records, int student_count, int? lec_hours)
        {
            // 7 is Н
            const int AbsentValue = 7;
            int absentCount = records.Count(r => r.SubjectId == AbsentValue);


            if (absentCount == 0 || student_count == 0 || lec_hours == 0)
            {
                return 100.0f;
            }

            float? result = 100 - (student_count * lec_hours) / (float)absentCount;
            return result;
        }
        public  float MidleValue(List<AttendanceRecord> records)
        {
            const int maxEvalValue = 5;
            var validRecords = records.Where(r => r.SubjectId <= maxEvalValue).ToList();
            int length = validRecords.Count;
            if (length > 0)
            {
                float result = validRecords.Sum(r => r.SubjectId) / (float)length;
                return result;
            }
            return 0;
        }
        
    }
}
