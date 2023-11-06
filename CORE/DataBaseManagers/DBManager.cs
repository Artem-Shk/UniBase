using UniBase.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Microsoft.Data.SqlClient;

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
        private void  ToJournalType(List<ufuОценкиТекущаяУспеваемость> result)
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
            entity.КодПреподавателя == prepodID).OrderBy(entity => entity.КодЖурнала);
            
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
        public async Task<List<prepJournalData>> GetGetJournalByPrepodIDAndAcademicYear(int prepodID, string AcademicYear)
        {
            SqlParameter prepod_id = new SqlParameter("prepod_id", prepodID);
            SqlParameter academic_year = new SqlParameter("academic_year", AcademicYear);
            var query = context.prepJournalData.FromSqlRaw($"SELECT DISTINCT PrepJournal.[Код] as [key]\r\n\t  ,PrepJournal.[Дисциплина] as [discipline]\r\n\t  ,p.ФИО as teacherName\r\n      ,Groups.Название as GroupName\r\n      ,PrepJournal.[ВидЗанятий] as lectionType\r\n      ,PrepJournal.[Семестр] as semester\r\n      ,PrepJournal.[УчебныйГод] as academicYear\r\n\t  ,Nagr.Студентов as studentCount\r\n\t  ,Nagr.Часов as lectionHours\r\n\t  ,(\r\n\t\t\tSELECT  COUNT(*) \r\n\t\t\tFROM [Деканат].[dbo].ЖурналДанные\r\n\t\t\tWHERE КодЗначения = 7 and КодЖурнала = PrepJournal.Код\r\n\t\t\tGROUP BY КодЗначения\r\n\t\t) AS N_count\r\n\t   ,(\r\n\t\t\tSELECT  COUNT(*) / (Nagr.Студентов * Nagr.Часов)*100 as пропуски\r\n\t\t\tFROM [Деканат].[dbo].ЖурналДанные\r\n\t\t\tWHERE КодЗначения = 7 and КодЖурнала = PrepJournal.Код\r\n\t\t\tGROUP BY КодЗначения\r\n\t\t) AS truancy\r\n\t\t,p.Код as teacherCode\r\nFROM [Деканат].[dbo].[ЖурналПреподавателя] PrepJournal\r\nINNER JOIN [Деканат].[dbo].[Преподаватели] p ON PrepJournal.[КодПреподавателя] = p.[Код]\r\nINNER JOIN [Деканат].[dbo].[Все_Группы] Groups ON PrepJournal.[КодГруппы] = Groups.Код\r\nINNER JOIN [Деканат].[dbo].Нагрузка Nagr ON PrepJournal.Дисциплина = Nagr.Дисциплина and Nagr.КодПреподавателя =p.[Код] and\r\n Nagr.КодГруппы = Groups.Код \r\n and Nagr.ВидЗанятий = PrepJournal.ВидЗанятий \r\n and (Nagr.Семестр /  Groups.Курс) =  PrepJournal.[Семестр]\r\nINNER JOIN [Деканат].[dbo].ЖурналДанные JournalData ON PrepJournal.Код = JournalData.КодЖурнала\r\nINNER JOIN [Деканат].[dbo].ЖурналЗначения JournalValue ON JournalData.КодЗначения = JournalValue.Код\r\n\r\n WHERE p.[Код] = {prepod_id} and PrepJournal.[УчебныйГод] = '{academic_year}'", prepod_id, academic_year);

            return await query.ToListAsync();
        }

    }
}
