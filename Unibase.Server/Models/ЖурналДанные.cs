namespace UniBase.Models
{
    public class ЖурналДанные : IBaseWebModel<ДекВсеДанныеСтудента>, IBaseModel
    {
        public int Код { get; set; }
        public int КодЖурнала { get; set; }
        public int КодДаты { get; set; }
        public int КодЗначения { get; set; }
        public int КодСтудента { get; set; }


    }
}
