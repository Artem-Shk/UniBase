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
        private static List<string> _propertis;
        //TODO: rename it
        private static List<string> _fuckcults;
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
                    _fuckcults = pseudoContext.ДекСпециальности
                    .Select(f => f.Факультет)
                    .Distinct()
                    .ToList(); ;

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
                    _fuckcults = pseudoContext.ДекСпециальности
                    .Select(f => f.Название_Спец)
                    .Distinct()
                    .ToList(); ;

                    return _fuckcults;
                }
            }
        }
        public Dictionary<string, string> TreeviewChain;
        private HomeModel()
        {
            context = new DekanatModel();
            pseudoContext = new PseudoDb();
            //          searchModule = new SearchCore(context);
        }
        private static HomeModel _instance;

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
        public virtual List<ДекВсеДанныеСтудента> ДекВсеДанныеСтудента { get; set; }
        public List<ДекСпециальности> ДекСпециальности = new List<ДекСпециальности> {
            new ДекСпециальности{Факультет = "asdas",Название_Спец= "aaaaaarrrr"},
            new ДекСпециальности{Факультет = "marazm",Название_Спец= "bebay"},
            new ДекСпециальности{Факультет = "Asad ben laedem",Название_Спец = "Salavat"},
        };



    }
}
