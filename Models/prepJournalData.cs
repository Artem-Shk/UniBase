namespace UniBase.Models
{
    public class prepJournalData : IBaseWebModel<ДекСпециальности>, IBaseModel
    {
        public string key { get; set; }
        string discipline { get; set; }
        string teacherName { get; set; }
        string GroupName { get; set; }
        string lectionType { get; set; }
        int semester { get; set; }
        string academicYear { get; set; }
        int studentCount { get; set; }
        int lectionHours { get; set; }
        int N_count { get; set; }
        float truancy { get; set; }
        int teacherCode { get; set; }
    }
}
