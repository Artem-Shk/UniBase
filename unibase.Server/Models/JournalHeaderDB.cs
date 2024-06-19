using UniBase.Models;

namespace Unibase.Server.Models
{
    public class JournalHeaderDB : JournalHeaderBase
    {
        public int? code { get; set; }
        public string? lectionType { get; set; }
        public  int? nagrCode { get; set; }
        public int? groupCode { get; set; }

        public int? disciplineCode { get; set; }



    }
}
