using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using UniBase.CORE;
using UniBase.CORE.DataBaseManagers;
using UniBase.Models;

namespace UniBase.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentDataController : ControllerBase
    {
        private DBManager DBManager = DBManager.GetInstance();
        private JsonSerializerHelper JsonHelper = new JsonSerializerHelper();
        public StudentDataController()
        {
        }
        // GET: studentdata
        [HttpGet]
        public string Get()
        {
            return "hoy";
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
        public async Task<IActionResult> GetJsonTableRowData(string name, bool jsontype)
        {
            List<ДекВсеДанныеСтудента> result = await DBManager.FindStudentByNameAsynch(name);
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
        [HttpGet("GetGroup/{faculities=ЭФ}")]
        public async Task<object> GetGroupJson(string fuckkultname)
        {
            List<ДекСписокГруппФакультета> result = await DBManager.GetGroupByFaculty(fuckkultname);
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
        [HttpGet("GetAllFacult")]
        public async Task<object> GetAllFacultJson()
        {
            List<string?> result = await DBManager.AllFacultiesAsynch();
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
        [HttpGet("GetMenuData")]
        public async Task<object> GetMenuParameters()
        {
            List<MenuItemModel> result = new List<MenuItemModel>();
            List<string?> list = await DBManager.AllFacultiesAsynch();

            if (list == null)
            {
                return NotFound(); // Возвращаем ошибку 404 Not Found, если resultFaculity равен null
            }
            else
            {
                List<string> resultFaculity = list;
                foreach (string faculity in resultFaculity)
                {
                    List<ДекСписокГруппФакультета> resultGroup = await DBManager.GetGroupByFaculty(faculity);
                    resultGroup = SortGroupByYear(resultGroup);
                    List<MenuItemModel> groups = resultGroup.Select(s => new MenuItemModel(s.Название, null)).ToList();
                    result.Add(new MenuItemModel(faculity, groups));
                }
                string? JsonedResult = JsonHelper.JsonSerialize(result);
                if (JsonedResult == null)
                {
                    return NotFound(); // Возвращаем ошибку 404 Not Found, если JsonedResult равен null
                }
                else
                {
                    return Ok(JsonedResult); // Возвращаем успешный результат с сериализованным объектом в JSON
                }
            }




        }
        [HttpGet("GetStudentsByGroup/{group_name}")]
        public async Task<object> GetStudentsByGroup(int groupId)
        {
            List<ДекВсеДанныеСтудента> result = await DBManager.GetStudentsByGroupCode(groupId);
            if (result == null)
            {
                return NotFound(); // Возвращаем ошибку 404 Not Found, если результат равен null
            }

            return Ok(JsonHelper.JsonSerialize(result));
        }
    }
}
