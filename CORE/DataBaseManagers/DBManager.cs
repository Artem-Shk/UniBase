using UniBase.Models;
using Microsoft.EntityFrameworkCore;


namespace UniBase.CORE.DataBaseManagers
{
    //узнать что быстрее запросы или сервер ;\
    public class DBManager
    {
        private static DBManager _instance;
        private readonly DekanatModel context;
        private static List<string> _propertis;
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
        private DBManager()
        {
            context = new DekanatModel();
        }
        private void  FromPrepJournalResultToJournal(List<ufuОценкиТекущаяУспеваемость> result)
        {
            foreach(ufuОценкиТекущаяУспеваемость res in result)
            {
                
            }
        }
        
        public static DBManager GetInstance()
        {
            if(_instance is null)
            {
                _instance = new DBManager();
            }
            return _instance;
        }
        public async Task<List<ДекСписокГруппФакультета>> GetGroupByFaculty(string GroupName)
        {
            return await context.ДекСписокГруппФакультета
                .AsNoTracking()
                .Where(entity=>
                entity.Сокращение.ToLower() == GroupName.ToLower()).ToListAsync();

        }

        public async Task<List<ДекВсеДанныеСтудента>> FindStudentByNameAsynch(string name)
        {
            return await context.ДекВсеДанныеСтудента 
            .AsNoTracking()
            .Where(entity =>
            entity.Фамилия.ToLower() == name.ToLower()
            || entity.Имя.ToLower() == name.ToLower()
            || entity.ФИО.ToLower() == name.ToLower()
            || entity.Зачетка == name
            || entity.Название.ToLower() == name.ToLower())
            .ToListAsync();
        }
        //public List<ДекВсеДанныеСтудента> FindStudentByName(string name)
        //{
        //    return context.ДекВсеДанныеСтудента
        //        .AsNoTracking()
        //        .Where(entity => entity.ФИО.Contains(name.ToLower())
        //        || entity.Зачетка == name
        //        || entity.Название.ToLower().Contains(name.ToLower()))
        //        .ToList();
        //}
        public async Task<List<string?>> AllFacultiesAsynch()
        {
            return await context.Факультеты
                  .AsNoTracking()
                  .Select(f => f.Сокращение)
                  .ToListAsync();
        }
        public async Task<List<ДекВсеДанныеСтудента>> GetStudentsByGroupCode(int groupCode)
        {
            return await context.ДекВсеДанныеСтудента
            .AsNoTracking()
            .Where(entity =>
            entity.Код_Группы == groupCode)
            .ToListAsync();
        }
        public async Task<List<ufuОценкиТекущаяУспеваемость>> GetJournalsByPrepodId(int prepodID)
        {
            var query = context.ufuОценкиТекущаяУспеваемость
            .AsNoTracking()
            .Where(entity =>
            entity.КодПреподавателя == prepodID);

            return await query.ToListAsync();
        }
        public async Task<List<string>> GetDisciplinesByPrepodID(int prepodID)
        {
            var query = context.ufuОценкиТекущаяУспеваемость
            .AsNoTracking().Where(entity =>
            entity.КодПреподавателя == prepodID)
            .Select(ent => ent.Дисциплина)
            .Distinct();
            return await query.ToListAsync();
        }

    }
}
