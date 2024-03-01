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
        private readonly DBManager _dBManager;
        private readonly JsonSerializerHelper JsonHelper = new();
        public JournalDataController(DBManager DBManager)
        {
            _dBManager = DBManager;
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
            List<FaculityPackage> result = await new JournalFabric(faculityId, _dBManager).createDataForFaculityAsync();
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
        [HttpGet("GetJornalsHeaders/{faculityId=8}&{lastId=0}")]
        public async Task<IActionResult> GetJornalsHeaders(int faculityId, int lastId =0)
        {
           
            JournalFabric fabric = new JournalFabric(faculityId, _dBManager);
            List<JournalHeaderWeb> result = await fabric.CreateHeaders(faculityId);
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
        [HttpGet("GetJornalBody/{journalId=9673}&{date}&{nagrCode}")]
        public async Task<IActionResult> GetJornalBody(int journalId = 9673, string date = "17.01.2024", int nagrCode = 68458)
        {
            //Взять инстанс базы
            // Вызвать методы асинхронно
            List<JournalPartRow>  JournalPartRows =  await _dBManager.getJournalDataPart(journalId);
            int NagrHours = await _dBManager.GetNagrHours(nagrCode);
            int StudentCount = await _dBManager.GetStudentCount(nagrCode);
            int hours = await _dBManager.getJournalHoursWithPeroid(journalId, date);
            int EvalCount = _dBManager.getJournalEvalCount(journalId);
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
                studentCount = StudentCount,
                
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

