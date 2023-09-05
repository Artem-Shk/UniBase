using UniBase.Models;
using Microsoft.EntityFrameworkCore;


namespace UniBase.CORE.DataBaseManagers
{
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
        public List<ДекВсеДанныеСтудента> FindStudentByName(string name)
        {
            return context.ДекВсеДанныеСтудента
                .AsNoTracking()
                .Where(entity => entity.ФИО.Contains(name.ToLower())
                || entity.Зачетка == name
                || entity.Название.ToLower().Contains(name.ToLower()))
                .ToList();
        }
        public async Task<List<string?>> AllFacultiesAsynch()
        {
            return await context.Факультеты
                  .AsNoTracking()
                  .Select(f => f.Сокращение)
                  .ToListAsync();
        }

    }
}
