using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Unibase.Server.Models;
using UniBase.CORE;
using UniBase.CORE.DataBaseManagers;
using UniBase.Models;

namespace UniBase.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class JournalDataController : ControllerBase
    {
        private readonly DBManager DBManager = DBManager.GetInstance();
        private readonly JsonSerializerHelper JsonHelper = new();
        public JournalDataController()
        {
        }
        // GET: journaldata
        [HttpGet("get")]
        public string Get()
        {
            return "Ok";
        }
        [HttpGet("GetJornals/{faculityId=8}")]
        public async Task<IActionResult> GetJornals(int faculityId)
        {
            const int list = 200;
            int lastID = 0;
            List<FaculityPackage> result = await new JournalFabric(faculityId).createDataForFaculityAsync();
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                lastID = result.Last().key;
                return Ok(JsonHelper.JsonSerialize(result));
                
            }

        }
        [HttpGet("GetJornalsHeaders/{faculityId=8}")]
        public async Task<IActionResult> GetJornalsHeaders(int faculityId)
        {
            DBManager manager = DBManager.GetInstance();
            List<JournalHeader> result = await manager.GetJournalHeaderData(0, faculityId);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(JsonHelper.JsonSerialize(result));
            }
        }
        // ЭТО ЛЮТОЕ ДЕРМИЩЕ ПОЛНОЕ ОРЕШКОВ
        [HttpGet("GetJornalBody/{journalId=9673}&{date}")]
        public async Task<IActionResult> GetJornalBody(int journalId = 9673, string date = "17.01.2024")
        {
            //Взять инстанс базы
            DBManager manager = DBManager.GetInstance();
            // Вызвать методы асинхронно
            int nagrCode = await manager.GetStringNagrCodeFromPrepJournal(journalId);
            List<JournalPartRow>  JournalPartRows =  await manager.getJournalDataPart(journalId);
            int NagrHours = await manager.GetNagrHours(nagrCode);
            int StudentCount = await manager.GetStudentCount(nagrCode);
            int hours = await manager.getJournalHoursWithPeroid(journalId, date);
            int EvalCount =  manager.getJournalEvalCount(journalId);
            Double midleAttence = GetMiddleValue(EvalCount, JournalPartRows);
            int Ncount = CountN(JournalPartRows);
            //выставить данные в обьект
            JournalBody body = new JournalBody
            {
                midleAttence = midleAttence,
                Ncount = Ncount,
                nagrHours = NagrHours,
                hours = hours,
                EvalCount = EvalCount,
                studentCount = StudentCount
            };
            if (body == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(JsonHelper.JsonSerialize(body));
            }

        }
        
       
        private  Double GetMiddleValue(int attencCount, List<JournalPartRow> journalAttence)
        {
            float midleAttence = 0.00f;
            foreach (var item in journalAttence)
            {
          

                if (item.valuekey < 6)
                {
                    midleAttence += item.valuekey;
                }
              
            }
            if (midleAttence > 0)
            {
                midleAttence = midleAttence / attencCount;
            }
            return Math.Round( midleAttence, 2);
        }
        private int CountN(List<JournalPartRow> journalAttence)
        {
            // 7 это Н
            int result = journalAttence.Count(x => x.valuekey == 7);
            return result;
        }
        

    }
}

