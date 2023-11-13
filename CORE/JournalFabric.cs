using System.Xml.Serialization;
using UniBase.CORE.DataBaseManagers;
using UniBase.Models;

namespace UniBase.CORE
{
    public  class JournalFabric
    {
        private Journal GroupJournal { get; set; }
        private List<int> KafTeachersID;
        public JournalFabric()
        {
            collectData(28);
        }
        public void AuthKeys(int DekanId)
        {
            
        }
        //collected data from database
        private async void collectData(int faculityID = 28, string AcademicYear = "2023-2024")
        {
            DBManager data_base_manager = DBManager.GetInstance();
            List<Journal> TeacherJournals = new List<Journal>();
            var prepods = await data_base_manager.GetPrepodsByFaculityIDAsynch(28);
            //взять преподов
            foreach (var prepod in  prepods)
            {
                
                //взять журналы препода
                Task<List<prepJournalData>> journals =  data_base_manager.GetGetJournalByPrepodIDAndAcademicYear(prepod.Код, AcademicYear);
                //взять записи журнала
                foreach(prepJournalData journal in journals.Result) 
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
        public void AttadanceProcent()
        {
           
        }
    }
}
