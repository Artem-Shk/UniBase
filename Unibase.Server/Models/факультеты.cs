namespace UniBase.Models
{
    public class Факультеты : IBaseWebModel<Факультеты>, IBaseModel
    {
        public int Код { get; set; }
        public string? Сокращение { get; set; }
    }
}
