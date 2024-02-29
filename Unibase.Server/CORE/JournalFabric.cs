﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Unibase.Server.Models;
using UniBase.CORE.DataBaseManagers;
using UniBase.Models;


namespace UniBase.CORE
{
    public class JournalFabric
    {
        private Journal GroupJournal { get; set; }
        private  DBManager _data_base_manager;
        public JournalFabric(int faculityId,DBManager manager)
        {
            _data_base_manager = manager;

            GroupJournal = new Journal();
        }
        public void AuthKeys(int DekanId)
        {
        }
        //collected data from database
        public async Task<List<FaculityPackage>> createDataForFaculityAsync()
        {
            List<FaculityPackage> faculityJournal = new List<FaculityPackage>();
            var journals = await _data_base_manager.GetJournalsByFaculity(0,28);
            if(journals is not null)
            {
                foreach(var journal in journals)
                {
                    var journalRecords = await _data_base_manager.GetAttandanceRecord(journal.key);

                    FaculityPackage pack = new FaculityPackage(journal);
                    if (journalRecords.Count > 0)
                    {
                        pack.Attandance =  AttadanceProcent(journalRecords, pack.studentCount, pack.lectionHours);
                        pack.midelEval = MidleValue(journalRecords);
                    }
                    faculityJournal.Add(pack);
                }
            }
            return faculityJournal;
        }

        public float? AttadanceProcent(List<AttendanceRecord> records, int student_count, int? lec_hours)
        {
            // 7 is Н
            const int AbsentValue = 7;
            int absentCount = records.Count(r => r.SubjectId == AbsentValue);


            if (absentCount == 0 || student_count == 0 || lec_hours == 0)
            {
                return 100.0f;
            }

            float? result = 100 - (student_count * lec_hours) / (float)absentCount;
            return result;
        }
        public  float MidleValue(List<AttendanceRecord> records)
        {
            const int maxEvalValue = 5;
            var validRecords = records.Where(r => r.SubjectId <= maxEvalValue).ToList();
            int length = validRecords.Count;
            if (length > 0)
            {
                float result = validRecords.Sum(r => r.SubjectId) / (float)length;
                return result;
            }
            return 0;
        }
        public async Task<List<JournalHeaderWeb>>  CreateHeaders(int faculityId)
        {
            List<JournalHeaderDB> resultDB = await _data_base_manager.GetJournalHeaderData(faculityId);
            List<JournalHeaderWeb> result = new List<JournalHeaderWeb>();
            for (int i = 0; i < resultDB.Count; i++)
            {   JournalHeaderWeb WebItem = new JournalHeaderWeb();
                WebItem.discipline = resultDB[i].discipline;
                WebItem.GroupName = resultDB[i].GroupName;
                WebItem.semester = resultDB[i].semester;
                WebItem.teacherName = resultDB[i].teacherName;
                WebItem.studentCount = resultDB[i].studentCount;
                WebItem.code = resultDB[i].code;
                WebItem.nagrCode = new List<int?>();
                WebItem.lectionType = new List<string?>();
                
                while (i + 1 < resultDB.Count && 
                       (resultDB[i].disciplineCode == resultDB[i + 1].disciplineCode &&
                        resultDB[i].groupCode == resultDB[i + 1].groupCode))
                {
                 
                    WebItem.nagrCode.Add(resultDB[i].nagrCode);
                    WebItem.lectionType.Add(resultDB[i].lectionType);
                    i++;
                }
                if (
                    (i > 0 && i + 1 < resultDB.Count )
                    &&  (resultDB[i].disciplineCode == resultDB[i - 1].disciplineCode &&
                        resultDB[i].groupCode == resultDB[i - 1].groupCode &&
                        resultDB[i].disciplineCode != resultDB[i + 1].disciplineCode)
                        );
                {
                    WebItem.nagrCode.Add(resultDB[i].nagrCode);
                    WebItem.lectionType.Add(resultDB[i].lectionType);
                }
                result.Add(WebItem);
            }

            return result;
        }

    }
}
