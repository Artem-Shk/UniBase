using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
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
        public  string Get()
        {
            return "hoy";
        }
        private string? JsonSerialize<T>(T result)
        {
            if (result != null)
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                };

                string jsonString = JsonSerializer.Serialize(result, options);
                return jsonString;
            }
            else return null;
        }
        private List<ДекСписокГруппФакультета> SortGroupByYear(List<ДекСписокГруппФакультета> result)
        {
            result = result.OrderBy(элемент => элемент.Название.Substring(элемент.Название.Length - 2)).ToList();
            return result;
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
            List<ДекВсеДанныеСтудента> result = await DBManager.FindStudentByNameAsynch(name);
            return JsonSerialize(result);
        }
        [HttpGet("GetGroup/{faculities=ЭФ}")]
        public async Task<object> GetGroupJson(string fuckkultname)
        {
            List<ДекСписокГруппФакультета> result = await DBManager.GetGroupByFaculty(fuckkultname);
            return JsonSerialize( result);
        }
        [HttpGet("GetAllFacult")]
        public async Task<object> GetAllFacultJson()
        {
            List<string> result = await DBManager.AllFacultiesAsynch();
            return JsonSerialize(result);
        }
        [HttpGet("GetMenuData")]
        public async Task<object> GetMenuParameters()
        {
            List<MenuItemModel> result =  new List<MenuItemModel>();
            List<string> resultFaculity = await DBManager.AllFacultiesAsynch();
            foreach(string faculity in resultFaculity)
            {
                List<ДекСписокГруппФакультета> resultGroup = await DBManager.GetGroupByFaculty(faculity);
                resultGroup = SortGroupByYear(resultGroup);
                List<MenuItemModel> groups = resultGroup.Select(s => new MenuItemModel(s.Название, null)).ToList();
                result.Add(new MenuItemModel(faculity, groups));
            }
            return JsonSerialize(result);
        }
        [HttpGet("GetStudentsByGroup/{group_name}")]
        public async Task<object> GetStudentsByGroup(int groupId)
        {
            List<ДекВсеДанныеСтудента> result = await DBManager.GetStudentsByGroupCode(groupId);
            
            return JsonSerialize(result);
        }
    } 
}
