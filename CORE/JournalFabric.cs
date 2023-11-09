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
            List<Journal> FacilitiJournals = new List<Journal>();
            var prepods = await data_base_manager.GetPrepodsByFaculityIDAsynch(28);
            foreach (var prepod in  prepods)
            {
                Task<List<prepJournalData>> journals =  data_base_manager.GetGetJournalByPrepodIDAndAcademicYear(prepod.Код, AcademicYear);
                foreach(var journal in journals.Result) 
                {
                    

                } 
                var journal_return = new Journal()
                {
                    GroupName = journal.Result.
                };
                foreach (var journalEntry in journal.Result) {
                    FacilitiJournals.Add
                }
                
            }
        }
        public void AttadanceProcent()
        {
           
        }
    }
}
