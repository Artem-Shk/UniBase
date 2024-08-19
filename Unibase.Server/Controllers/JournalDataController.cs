using Microsoft.AspNetCore.Mvc;
using Unibase.Server.Models;
using UniBase.CORE;
using UniBase.CORE.DataBaseManagers;

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
    
        [HttpGet("GetJornalsHeaders/{FaculityID=8}/{pageNum=0}/{startDate}&{EndDate}/{semestr}/{name?}")]
        public async Task<IActionResult> GetJornalsHeaders(int FaculityID, int pageNum = 0, 
                                                            string startDate = "27.12.2005",
                                                            string EndDate = "27.12.2024", int semestr = 1, string name = "")
        {
            JournalFabric fabric = new JournalFabric(_dBManager, semestr, FaculityID, startDate, EndDate,  pageNum, name);
            List<JournalHeaderWeb> result = await fabric.CreateHeaders(FaculityID);
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
        [HttpGet("GetJornalBody/{journalId=9673}&{date}&{nagrCode}&{lectionType}")]
        public async Task<IActionResult> GetJornalBody(int journalId = 9673, string date = "17.01.2024", int nagrCode = 68458, string lectionType = "Лек")
        {
            //Взять инстанс базы
            // Вызвать методы асинхронно
            List<JournalPartRow> JournalPartRows = await _dBManager.getJournalDataPart(journalId);
            int NagrHours = await _dBManager.GetNagrHours(nagrCode, lectionType);
            int StudentCount = await _dBManager.GetStudentCount(nagrCode, lectionType);
            int hours = await _dBManager.getJournalHoursWithPeroid(journalId, date);
            int EvalCount = _dBManager.getJournalEvalCount(journalId, lectionType);
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
        [HttpGet("GetRowCount/{FaculityID=8}&{startDate}&{EndDate}/{semestr?}/{name?}")]
        public async Task<IActionResult> GetRowCount(int FaculityID, string startDate = "27.12.2023", string EndDate = "25.12.2024", int semestr = 1,string name = "")
        {
            var results = await _dBManager.GetRowCount(startDate, EndDate, FaculityID, semestr, name);
            return Ok(JsonHelper.JsonSerialize(results));
        }
        private Double GetMiddleValue(int attencCount, List<JournalPartRow> journalAttence)
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
            return Math.Round(midleAttence, 2);
        }
        private int CountN(List<JournalPartRow> journalAttence)
        {
            // 7 это Н
            int result = journalAttence.Count(x => x.valuekey == 7);
            return result;
        }
    }
}

