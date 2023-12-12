namespace UniBase.Models
{
    public class ДекСпециальности : IBaseWebModel<ДекСпециальности>, IBaseModel
    {
        public int? Код { get; set; }
        public string? Факультет { get; set; }
        public string? Название_Спец { get; set; }
    }
}
