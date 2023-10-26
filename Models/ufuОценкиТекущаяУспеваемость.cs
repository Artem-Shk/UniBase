namespace UniBase.Models
{
    public class ufuОценкиТекущаяУспеваемость : IBaseWebModel<ufuОценкиТекущаяУспеваемость>, IBaseModel
    {
       public int КодЖурнала { get; set; }
       public int КодПреподавателя { get; set; }
       public string Дисциплина { get; set; }
    }
}
