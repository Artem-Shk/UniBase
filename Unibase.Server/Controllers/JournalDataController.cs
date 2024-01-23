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
        [HttpGet("GetJornalBody/{journalId=9673}")]
        public async Task<IActionResult> GetJornalBody(int journalId,string date)
        {
            DBManager manager = DBManager.GetInstance();
            int hours = await manager.getJournalHours(journalId, date);
            int attencCount = await manager.getJournalAttencCount(journalId);
            List<JournalAttence> journalAttence = await manager.getJournalAttenc(journalId);
            Double midleAttence = GetMiddleValue(attencCount, journalAttence);

        }
        private Double GetMiddleValue(int attencCount, List<JournalAttence> journalAttence)
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
        // дописать конструктор

    }
}

