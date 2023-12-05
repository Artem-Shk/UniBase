using Microsoft.AspNetCore.Mvc;
using UniBase.CORE;
using UniBase.CORE.DataBaseManagers;
using UniBase.Models;

namespace UniBase.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class JournalDataController : ControllerBase
    {
        private DBManager DBManager = DBManager.GetInstance();
        private JsonSerializerHelper JsonHelper = new JsonSerializerHelper();
        public JournalDataController()
        {
        }
        // GET: journaldata
        [HttpGet]
        public string Get()
        {
            return "hzy";
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

