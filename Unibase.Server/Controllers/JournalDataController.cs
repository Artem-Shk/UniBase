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
            List<FaculityPackage> result = await new JournalFabric().createDataForFaculityAsync();
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(JsonHelper.JsonSerialize(result));
                lastID = result.Last().key;
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
        [HttpGet("GetJornalBody/{journalId=9673}&{date}")]
        public async Task<IActionResult> GetJornalBody(int journalId = 9673, string date = "17.01.2024")
        {
            DBManager manager = DBManager.GetInstance();
            JournalBody body = new JournalBody(); 
            int hours = await manager.getJournalHours(journalId, date);
            int attencCount = await manager.getJournalAttencCount(journalId);
            List<JournalAttence> journalAttence = await manager.getJournalAttenc(journalId);
            Task<Double> midleAttence = GetMiddleValue(attencCount, journalAttence);

            Task<int> Ncount = CountN(journalAttence);


            body.midleAttence = await midleAttence;
            body.Ncount = await Ncount;

            if (body == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(JsonHelper.JsonSerialize(body));
            }

        }
        private async Task<Double> GetMiddleValue(int attencCount, List<JournalAttence> journalAttence)
        {
            Double midleAttence = 0;
            foreach (var item in journalAttence)
            {
               
                if (item.valuekey < 6)
                {
                    midleAttence += item.valuekey;
                }
                if (midleAttence > 0)
                {
                    midleAttence = midleAttence / attencCount;
                }
                
            }
            return midleAttence;
        }
        private async Task<int> CountN(List<JournalAttence> journalAttence)
        {
            // 7 это Н
            int result = journalAttence.Count(x => x.journalKey == 7);
            return result;
        }

    }
}

