using System.ComponentModel.DataAnnotations;
using UniBase.Models;

namespace Unibase.Server.Models
{
    public class Нагрузка : IBaseModel
    {
        [Key]
        public int Код { get; set; }
        public float Часов { get; set; }
        public int Студентов { get; set; }
    }
}
