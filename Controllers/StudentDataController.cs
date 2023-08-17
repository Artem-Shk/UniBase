using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using UniBase.CORE.DataBaseManagers;
using UniBase.Models;

namespace UniBase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ForecastHuev1Controller : ControllerBase
    {
        private DBManager DBManager = DBManager.GetInstance();

        public ForecastHuev1Controller()
        {

        }

        // GET: StudentDataController
        [HttpGet]
        public string Get()
        {
            return "huy";
        }
        [HttpGet("GetJsonByName/{name=Иван}")]
        public async Task<object> GetJsonByName(string name)
        {

            List<ДекВсеДанныеСтудента> result = await DBManager.FindStudentByNameAsynch(name);
            HtmlContentBuilder builder = new HtmlContentBuilder();
            if (result != null)
            {
                for (int rowid = 0; rowid < result.Count; rowid++)
                {
                    builder.AppendHtmlLine("<tr>");
                    var row = result[rowid].toList();
                    for (int c = 0; c < DBManager.FieldNames.Count; c++)
                    {
                        Console.WriteLine(row.Count);
                        builder.AppendHtmlLine("<td id=\"data\"" +
                                               "data-formatter=\"field\">" + row[c] + "</td>");
                    }
                    builder.AppendHtmlLine("</tr>");
                }
            }
            var writer = new StringWriter();
            builder.WriteTo(writer, HtmlEncoder.Default);
            Console.WriteLine("success");
            return writer.ToString();
        }

        // GET: StudentData/Details/5
    
    }
}
