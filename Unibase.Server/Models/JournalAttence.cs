﻿using System.ComponentModel.DataAnnotations;

namespace Unibase.Server.Models
{

    public class JournalPartRow
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
