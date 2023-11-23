namespace UniBase.Models
{
    public class prepJournalData : IBaseWebModel<ДекСпециальности>, IBaseModel
    {
        public int key { get; set; }
        public string discipline { get; set; }
        public string teacherName { get; set; }
        public string GroupName { get; set; }
        public string lectionType { get; set; }
        public int semester { get; set; }
        public string academicYear { get; set; }
        public int studentCount { get; set; }
        public int? lectionHours { get; set; }
        public int? teacherCode { get; set; }
        public int? faculity { get; set; }
        public int? kafedra { get; set; }
    }
}

