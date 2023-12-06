using Microsoft.AspNetCore.Mvc;
using UniBase.CORE;
using UniBase.CORE.DataBaseManagers;
using UniBase.Models;

namespace UniBase.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SJournalDataController : ControllerBase
    {
        private DBManager DBManager = DBManager.GetInstance();
        private JsonSerializerHelper JsonHelper = new JsonSerializerHelper();
        public SJournalDataController()
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
            List<prepJournalData> result = await DBManager.GetJournalsByFaculity(faculityId);
            string? JsonedResult = JsonHelper.JsonSerialize(result);
            if (JsonedResult != null)
            {
                return NotFound();
            }
            else
            {
                return Ok(JsonedResult);
            }

        }

    }
}

