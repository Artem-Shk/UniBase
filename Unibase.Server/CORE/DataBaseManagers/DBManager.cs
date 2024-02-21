using Microsoft.EntityFrameworkCore;
using Unibase.Server.Models;
using UniBase.Models;

namespace UniBase.CORE.DataBaseManagers
{
    //узнать что быстрее запросы или сервер ;\
    public class DBManager
    {
       
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

        public DBManager() {
            context = new DekanatModel();
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
        public async Task<List<JournalData>> GetGetJournalByPrepodIDAndAcademicYear(int prepodID, string AcademicYear)
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
            const int nullValue = 6;
            var query = from ЖурналДанные record in context.ЖурналДанные

                        join ДекВсеДанныеСтудента student in context.ДекВсеДанныеСтудента
                        on record.КодСтудента equals student.Код
                        join ЖурналЗначения value in context.ЖурналЗначения
                        on record.КодЗначения equals value.Код 
                        join ЖурналДаты date in context.ЖурналДаты 
                        on record.КодДаты equals date.Код
                        where  value.Код != nullValue && record.КодЖурнала == journalID
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
        //TODO: Оптимизировать
        public async Task<List<JournalData>> GetJournalsByFaculity(int LastId, int FaculityID, string AcademicYear = "2023-2024")
        {
            var query = context.prepJournalData.FromSqlRaw($@"
           SELECT   TOP 20  PrepJournal.[Код] as [key]
                ,PrepJournal.[Дисциплина] as [discipline]
                ,p.ФИО as teacherName
                ,Groups.Название as GroupName
                ,Groups.Код_Факультета
                ,PrepJournal.[ВидЗанятий] as lectionType
                ,PrepJournal.[Семестр] as semester
                ,PrepJournal.[УчебныйГод] as academicYear
                ,Nagr.Студентов as studentCount
                ,CAST(Nagr.Часов as int) as [lectionHours]
                ,p.Код as teacherCode
            FROM [Деканат].[dbo].[ЖурналПреподавателя] PrepJournal
            INNER JOIN [Деканат].[dbo].[Преподаватели] p ON PrepJournal.[КодПреподавателя] = p.[Код]
            INNER JOIN [Деканат].[dbo].[ПреподавателиКафедры] KafValue ON p.[Код] = KafValue.КодПреподавателя
            INNER JOIN [Деканат].[dbo].[Все_Группы] Groups ON Groups.Код = PrepJournal.[КодГруппы] and Groups.Код_Факультета = {FaculityID}
            INNER JOIN [Деканат].[dbo].Нагрузка Nagr ON PrepJournal.Дисциплина = Nagr.Дисциплина and Nagr.КодГруппы = PrepJournal.КодГруппы and 
            Nagr.ВидЗанятий = PrepJournal.ВидЗанятий 
            and (Nagr.Семестр / Groups.Курс) = PrepJournal.[Семестр]
            INNER JOIN [Деканат].[dbo].[Кафедры] Kafs ON kafs.Код_Факультета = {FaculityID} and KafValue.КодКафедры = kafs.Код and Nagr.КодКафедры = kafs.Код
            WHERE (PrepJournal.[УчебныйГод] = '{AcademicYear}') and PrepJournal.[Код] > {LastId} 
            ORDER BY PrepJournal.[Код] ASC;
        ");
            return await query.ToListAsync();
        }
        public async Task<List<JournalHeaderDB>> GetJournalHeaderData(int LastId, int FaculityID, string AcademicYear = "2023-2024")
        {
            var query = context.JournalHeader.FromSqlRaw($@"
                   SELECT TOP (120) PrepJournal.[Код] as code
                      ,PrepJournal.[Дисциплина] as discipline
                      ,PrepJournal.[ВидЗанятий] as lectionType
                      ,PrepJournal.[Семестр] as semester
                      ,PrepJournal.[КодСтрокиНагрузки] as nagrCode
	                  ,nagr.Студентов as studentCount
	                  ,Groups.Название as GroupName
	                  ,Prepods.ФИО as teacherName
                  FROM [Деканат].[dbo].[ЖурналПреподавателя] PrepJournal
                  inner join [Деканат].dbo.Нагрузка nagr on PrepJournal.КодСтрокиНагрузки =nagr.Код
                  inner join [Деканат].dbo.Все_Группы Groups on PrepJournal.КодГруппы = Groups.Код
                  inner join [Деканат].dbo.Преподаватели Prepods on PrepJournal.КодПреподавателя = Prepods.Код 
                  where PrepJournal.УчебныйГод = '{AcademicYear}' and Groups.Код_Факультета = {FaculityID} and PrepJournal.Код > {LastId}
                  order by code,discipline,GroupName
        ");
            var result = await query.ToListAsync();
            return result;
        }
        public async Task<int> getJournalHours(int journalId)
        {
            var result = context.ЖурналДаты.AsNoTracking()
                                            .Where(id => id.КодЖурнала == journalId )
                                            .Select(date => date.Дата);
            int c = result.Count();
            return  c;
        }
        public async Task<int> getJournalHoursWithPeroid(int journalId, string date)
        {
            var result = context.ЖурналДаты.AsNoTracking()
                                            .Where(id => id.КодЖурнала == journalId && id.Дата < DateTime.Parse(date))
                                            .Select(date => date.Дата);
            int c = result.Count();
            return c;
        }
        public  int getJournalEvalCount(int journalId)
        {
            var result =  context.ЖурналДанные.AsNoTracking()
                                              .Where(key => key.КодЖурнала ==journalId && key.КодЗначения < 6)
                                              .Select(data => data.КодЗначения).Count();
            return  result;
        }
        public async Task<List<JournalPartRow>> getJournalDataPart(int journalId)
        {
            var result = context.JournalPartRow.FromSqlRaw($@"SELECT  [Код] as [key]
                                                      ,[КодЖурнала] as journalKey
                                                      ,[КодСтудента] as studentKey
                                                      ,[КодДаты] as dataKey
                                                      ,[КодЗначения] as valueKey
                                                      ,[ДатаИзменения] as changeDate
                                                        FROM [Деканат].[dbo].[ЖурналДанные]
                                                        WHERE [КодЖурнала] = {journalId}
            ");
            return await result.ToListAsync();
        }
        public async Task<int> GetNagrHours(int NagrId)
        {
            float result = await context.Нагрузка.AsNoTracking()
                                       .Where(key => key.Код == NagrId)
                                       .Select(data => data.Часов)
                                       .FirstOrDefaultAsync();
            
            return ((int)result);

        }
        public async Task<int> GetStringNagrCodeFromPrepJournal(int journalId)
        {
            var query = context.ЖурналПреподавателя.AsNoTracking()
                                                    .Where(key => key.Код == journalId)
                                                    .Select(data => data.КодСтрокиНагрузки);
            var res = await query.FirstAsync();
            return  res;
        }
        public async Task<int> GetStudentCount(int NagrId)
        {
            float result = await context.Нагрузка.AsNoTracking()
                                       .Where(key => key.Код == NagrId)
                                       .Select(data => data.Студентов)
                                       .FirstOrDefaultAsync();
            return ((int)result);
        }
       
    }
}
