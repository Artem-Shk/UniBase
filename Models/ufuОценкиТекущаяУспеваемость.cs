namespace UniBase.Models
{
    public class ufuОценкиТекущаяУспеваемость : IBaseWebModel<ufuОценкиТекущаяУспеваемость>, IBaseModel
    {
        public int КодЖурнала { get; set; }
        public int КодПреподавателя { get; set; }
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public string Дисциплина { get; set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.


    }
}
