using Microsoft.AspNetCore.Mvc;
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

