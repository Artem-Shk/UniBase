using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unibase.Server.Models
{
    [Table("ЖурналДанные")]
    public class JournalAttence
    {
        [Key]
        public int key { get; set; }
        public int journalKey { get; set; }
        
        public int studentKey { get; set; }
        public int dataKey { get; set; }
        public int valuekey { get; set; }
        DateTime changeDate { get; set; }
    }
}
