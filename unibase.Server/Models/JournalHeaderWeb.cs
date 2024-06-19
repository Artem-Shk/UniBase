namespace Unibase.Server.Models
{
    public class JournalHeaderWeb : JournalHeaderBase
    {
        
        public int? code { get; set; }
        public List<int?>? nagrCode { get; set; }
        public List<string?> lectionType { get; set; }
 
    }
}
