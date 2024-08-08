namespace UniBase.Models
{
    public class ДекСписокГруппФакультета : IBaseWebModel<ДекВсеДанныеСтудента>, IBaseModel
    {

        public int Код { get; set; }
        public string? Название { get; set; }
        public int? Код_Факультета { get; set; }
        public string? Специальность { get; set; }
        public string? Название_Спец { get; set; }
        public int? Код_Специальности { get; set; }
        public string? Сокращение { get; set; }

    }
}
