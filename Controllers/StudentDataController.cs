using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using UniBase.CORE.DataBaseManagers;
using UniBase.Models;

namespace UniBase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentDataController : ControllerBase
    {
        private DBManager DBManager = DBManager.GetInstance();

        public StudentDataController()
        {

        }

        // GET: StudentDataController
        [HttpGet]
        public string Get()
        {
            return "huy";
        }
        [HttpGet("GetHTMLByName/{name=Иван}")]
        public async Task<object> GetHTMLByName(string name)
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
        [HttpGet("GetJsonTableRowData/{name=Иван}")]
        public async Task<object> GetJsonTableRowData(string name, bool jsontype)
        {
            Console.WriteLine("get data by " + name);
            List<ДекВсеДанныеСтудента> result = await DBManager.FindStudentByNameAsynch(name);
            if (result.Count > 0)
            {
                var options = new JsonSerializerOptions { WriteIndented = true,
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                };
                
                string jsonString = JsonSerializer.Serialize(result,options);
                return jsonString;
            }
            else return null;
        }



    }
}
