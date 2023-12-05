using UniBase.Models;

namespace DecanatLiteWeb.Models
{
    public class HomeModel
    {
        public DekanatModel context;

        public PseudoDb pseudoContext;

        // private SearchCore _searchModule;
        /// <summary>
        /// find thing object
        /// </summary>
        //  public SearchCore searchModule;
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        private static List<string> _propertis;
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        //TODO: rename it
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        private static List<string> _fuckcults;
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public List<string> FieldNames
        {
            get
            {
                if (_propertis != null)
                {
                    return _propertis;
                }
                else
                {
                    _propertis = context.ReturnДекВсеДанныеСтудентаFields();
                    return _propertis;
                }

            }
        }
        public List<string> Fuckults
        {
            get
            {
                if (_fuckcults != null)
                {
                    return _fuckcults;
                }
                else
                {
                    //TODO:  .AsNoTracking() return
#pragma warning disable CS8619 // Допустимость значения NULL для ссылочных типов в значении не соответствует целевому типу.
                    _fuckcults = pseudoContext.ДекСпециальности
                    .Select(f => f.Факультет)
                    .Distinct()
                    .ToList(); ;

#pragma warning restore CS8619 // Допустимость значения NULL для ссылочных типов в значении не соответствует целевому типу.
                    return _fuckcults;
                }

            }
        }
        public List<string> specialties
        {
            get
            {
                if (_fuckcults != null)
                {
                    return _fuckcults;
                }
                else
                {
                    //TODO:  .AsNoTracking() return
#pragma warning disable CS8619 // Допустимость значения NULL для ссылочных типов в значении не соответствует целевому типу.
                    _fuckcults = pseudoContext.ДекСпециальности
                    .Select(f => f.Название_Спец)
                    .Distinct()
                    .ToList(); ;

#pragma warning restore CS8619 // Допустимость значения NULL для ссылочных типов в значении не соответствует целевому типу.
                    return _fuckcults;
                }
            }
        }
        public Dictionary<string, string> TreeviewChain;
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        private HomeModel()
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        {
            context = new DekanatModel();
            pseudoContext = new PseudoDb();
            //          searchModule = new SearchCore(context);
        }
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        private static HomeModel _instance;
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.

        public static HomeModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new HomeModel();
            }
            return _instance;
        }
        private void SetTreeViewChain()
        {
            for (int sab = 0; sab > _fuckcults.Count(); sab++)
            {

            }
        }


    }
    public class PseudoDb
    {
        //Make it work
        public List<string> ReturnДекВсеДанныеСтудентаFields()
        {
            return ДекВсеДанныеСтудента.First().ModelField();
        }
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public virtual List<ДекВсеДанныеСтудента> ДекВсеДанныеСтудента { get; set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public List<ДекСпециальности> ДекСпециальности = new List<ДекСпециальности> {
            new ДекСпециальности{Факультет = "asdas",Название_Спец= "aaaaaarrrr"},
            new ДекСпециальности{Факультет = "marazm",Название_Спец= "bebay"},
            new ДекСпециальности{Факультет = "Asad ben laedem",Название_Спец = "Salavat"},
        };



    }
}
