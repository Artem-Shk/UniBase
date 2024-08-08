using UniBase.Models;

namespace Unibase.Server.Models
{
    public class JournalHeaderBase : IBaseWebModel<JournalHeaderDB>, IBaseModel
    {

        public Int64 id { get; set; }
        public string? discipline { get; set; }
        public int? semester { get; set; }
        public int? studentCount { get; set; }
        public string? GroupName { get; set; }
        public string? teacherName { get; set; }

    }


}
