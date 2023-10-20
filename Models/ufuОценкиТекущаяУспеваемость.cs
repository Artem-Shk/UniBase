namespace UniBase.Models
{
    public class ufuОценкиТекущаяУспеваемость : IBaseWebModel<ufuОценкиТекущаяУспеваемость>, IBaseModel
    {
       public int КодЖурнала { get; set; }
       public int Группа { get; set; }
       public int КодГруппы { get; set; }
       public string КодПреподавателя { get; set; }
       public string Дисциплина { get; set; }
       public int Семестр { get; set; }
       public int Значение { get; set; }
       public int Оценка { get; set; }
       public int КодСтудента { get; set; }
       public int ФИО { get; set; }
    }
}
