using Microsoft.EntityFrameworkCore;
using UniBase.Models;

namespace UniBase.CORE.DataBaseManagers
{
    //узнать что быстрее запросы или сервер ;\
    public class DBManager
    {
        private static DBManager _instance = GetInstance();
        private readonly DekanatModel context;
        private static List<string>? _propertis;
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
            if (_instance is null)
            {
                _instance = new DBManager();
            }
            return _instance;
        }
        public async Task<List<ДекСписокГруппФакультета>> GetGroupByFaculty(string GroupName)
        {
            return await context.ДекСписокГруппФакультета
                .AsNoTracking()
                .Where(entity =>
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
        public async Task<List<string>> AllFacultiesAsynch()
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
            // потом как нибудь поправить
            var query = context.prepJournalData.FromSqlRaw(
                $"SELECT DISTINCT PrepJournal.[Код] as [key] " +
                $",PrepJournal.[Дисциплина] as [discipline]" +
                $",p.ФИО as teacherName" +
                $",Groups.Название as GroupName" +
                $",PrepJournal.[ВидЗанятий] as lectionType" +
                $",PrepJournal.[Семестр] as semester" +
                $",PrepJournal.[УчебныйГод] as academicYear" +
                $",Nagr.Студентов as studentCount " +
                $",CAST(Nagr.Часов as int) as [lectionHours]" +
                $",p.Код as teacherCode" +
                $" FROM [Деканат].[dbo].[ЖурналПреподавателя] PrepJournal" +
                $" INNER JOIN [Деканат].[dbo].[Преподаватели] p ON PrepJournal.[КодПреподавателя] = p.[Код]" +
                $" INNER JOIN [Деканат].[dbo].[Все_Группы] Groups ON PrepJournal.[КодГруппы] = Groups.Код" +
                $" INNER JOIN [Деканат].[dbo].Нагрузка Nagr ON PrepJournal.Дисциплина = Nagr.Дисциплина and Nagr.КодПреподавателя =p.[Код] and" +
                $" Nagr.КодГруппы = Groups.Код " +
                $" and Nagr.ВидЗанятий = PrepJournal.ВидЗанятий" +
                $" and (Nagr.Семестр /  Groups.Курс) =  PrepJournal.[Семестр]" +
                $" INNER JOIN [Деканат].[dbo].ЖурналДанные JournalData ON PrepJournal.Код = JournalData.КодЖурнала" +
                $" INNER JOIN [Деканат].[dbo].ЖурналЗначения JournalValue ON JournalData.КодЗначения = JournalValue.Код" +
                $" WHERE p.[Код] = {prepodID} and PrepJournal.[УчебныйГод] = '{AcademicYear}'", prepodID, AcademicYear);
            var res = query.GetType();

            return await query.ToListAsync();
        }
        public async Task<List<Преподаватели>> GetPrepodsByFaculityIDAsynch(int FaculityID)
        {
            var query = from kafId in context.Кафедры
                        where kafId.Код_Факультета == FaculityID
                        from PrepID in context.ПреподавателиКафедры
                        where PrepID.КодКафедры == kafId.Код
                        from name in context.Преподаватели
                        where name.Код == PrepID.КодПреподавателя
                        select new Преподаватели()
                        {
                            кодКафедры = kafId.Код,
                            ФИО = name.ФИО,
                            кодФакультета = kafId.Код_Факультета

                        };
            return await query.AsNoTracking().Distinct().ToListAsync();
        }
        public async Task<List<AttendanceRecord>> GetAttandanceRecord(int journalID)
        {
            var query = from ЖурналДанные record in context.ЖурналДанные
                        where record.КодЖурнала == journalID
                        from ДекВсеДанныеСтудента student in context.ДекВсеДанныеСтудента
                        where student.Код == record.КодСтудента
                        from ЖурналЗначения value in context.ЖурналЗначения
                        where value.Код == record.КодЗначения
                        from ЖурналДаты date in context.ЖурналДаты
                        where date.Код == record.КодЗначения
                        select new AttendanceRecord()
                        {
                            Id = record.Код,
                            StudentId = record.КодСтудента,
                            StudentName = student.ФИО,
                            Date = date.Дата,
                            SubjectId = record.КодЗначения,
                            subjectValue = value.Значение
                        };
            return await query.AsNoTracking().ToListAsync();
        }
        public async Task<List<prepJournalData>> GetJournalsByFaculity(int FaculityID, string AcademicYear = "2023-2024")
        {
            var query = context.prepJournalData.FromSqlRaw(
              $"SELECT distinct  PrepJournal.[Код] as [key]\r\n\t" +
              $"  ,PrepJournal.[Дисциплина] as [discipline]\r\n\t" +
              $"  ,p.ФИО as teacherName\r\n" +
              $"      ,Groups.Название as GroupName\r\n\t" +
              $"   , Groups.Код_Факультета\r\n" +
              $"      ,PrepJournal.[ВидЗанятий] as lectionType\r\n" +
              $"      ,PrepJournal.[Семестр] as semester\r\n" +
              $"      ,PrepJournal.[УчебныйГод] as academicYear\r\n\t" +
              $"  ,Nagr.Студентов as studentCount \r\n\t" +
              $"  ,CAST(Nagr.Часов as int) as [lectionHours]\r\n\t\t" +
              $",p.Код as teacherCode\r\n\t\t" +
              $",kafs.Код\r\n\r\n" +
              $"FROM [Деканат].[dbo].[ЖурналПреподавателя] PrepJournal\r\n" +
              $"INNER JOIN [Деканат].[dbo].[Преподаватели] p ON PrepJournal.[КодПреподавателя] = p.[Код]\r\n" +
              $"INNER JOIN [Деканат].[dbo].[ПреподавателиКафедры] KafValue ON p.[Код] = KafValue.КодПреподавателя \r\n" +
              $"INNER JOIN [Деканат].[dbo].[Все_Группы] Groups ON  Groups.Код = PrepJournal.[КодГруппы] and  Groups.Код_Факультета = '{FaculityID}'\r\n\r\n" +
              $"INNER JOIN [Деканат].[dbo].Нагрузка Nagr ON PrepJournal.Дисциплина = Nagr.Дисциплина and \r\n" +
              $"Nagr.КодГруппы = PrepJournal.КодГруппы \r\n" +
              $"and Nagr.ВидЗанятий = PrepJournal.ВидЗанятий \r\n" +
              $"and (Nagr.Семестр /  Groups.Курс) =  PrepJournal.[Семестр]\r\n" +
              $"INNER JOIN [Деканат].[dbo].[Кафедры] Kafs on kafs.Код_Факультета = '{FaculityID}' and KafValue.КодКафедры = kafs.Код and Nagr.КодКафедры = kafs.Код\r\n" +
              $"WHERE ( PrepJournal.[УчебныйГод] = '{AcademicYear}'  )\r\n" +
              $"ORDER By teacherCode"
            );
            var res = query.GetType();
            return await query.ToListAsync();
        }

    }
}
