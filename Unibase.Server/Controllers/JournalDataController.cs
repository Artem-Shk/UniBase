using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            List<JournalData> result = await DBManager.GetJournalsByFaculity(faculityId, lastID);
            
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

    }
}

