using UniBase.Models;

namespace Unibase.Server.Models
{
    public class JournalHeader : IBaseWebModel<JournalHeader>, IBaseModel
    {
        public int? code { get; set; }
        public string? discipline { get; set; }
        public string? lectionType { get; set; }
        public int? semester { get; set; }
        public int? nagrCode { get; set; }
        public int? studentCount { get; set; }
        public string? GroupName { get; set; }
        public string? teacherName { get; set; }





    }
}
