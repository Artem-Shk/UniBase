using System.Xml.Serialization;
using UniBase.CORE.DataBaseManagers;
using UniBase.Models;

namespace UniBase.CORE
{
    public  class JournalFabric
    {
        private Journal GroupJournal { get; set; }
        private List<int> KafTeachersID;

        public void AuthKeys(int DekanId)
        {
            
        }
        private void collectData(int prepodID, string? AcademicYear)
        {
            DBManager data_base_manager = DBManager.GetInstance();
            data_base_manager.GetGetJournalByPrepodIDAndAcademicYear(prepodID,AcademicYear);

        }
        public void AttadanceProcent()
        {
           
        }
    }
}
