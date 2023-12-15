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
        private async void collectData(int faculityID = 28, string AcademicYear = "2023-2024")
        {
           
            List<Journal> TeacherJournals = new List<Journal>();
            var prepods = await data_base_manager.GetPrepodsByFaculityIDAsynch(28);
            //взять преподов
            foreach (var prepod in prepods)
            {

                //взять журналы препода
                Task<List<JournalData>> journals = data_base_manager.GetGetJournalByPrepodIDAndAcademicYear(prepod.Код, AcademicYear);
                //взять записи журнала
                foreach (JournalData journal in journals.Result)
                {
                    var journal_return = new Journal()
                    {
                        GroupName = journal.GroupName,
                        JournalName = journal.discipline,
                        PrepodName = prepod.ФИО,
                    };

                    TeacherJournals.Add(journal_return);

                }


            }
        }
        private async Task createDataForFaculityAsync()
        {
            List<Journal> TeacherJournals = new List<Journal>();
            var prepods = await data_base_manager.GetPrepodsByFaculityIDAsynch(28); 

        }
        private void collectData(int faculityID)
        {
            DBManager data_base_manager = DBManager.GetInstance();
        }
        public void AttadanceProcent()
        {

        }
        private class FaculityPackage : JournalData 
        {
            public string? Attandance { get; set; }
            public string? page { get; set; }
            FaculityPackage()
            {

            }
        }
    }
}
