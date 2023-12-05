using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;

namespace UniBase.CORE.requests
{
    public class Requester
    {
        readonly HttpClient client = new HttpClient();

        public async Task<string> MMISAuthKey()
        {
            string url = "https://mmis-web.rudn-sochi.ru/api/tokenauth";
            var data = new { userName = "shakrislanov.a", password = "Dstayte8", isParent = false, fingerprint = "d6005043edad6d17dc0ae27b80fbd2a5" };
            var content = OBJToContentConverter(data);
            HttpResponseMessage response = await client.PostAsync(url, content);
            string resp = await response.Content.ReadAsStringAsync();
            //starts with access "accessToken\": end with "
            string pattern = "\"accessToken\":\"([^\"]*)\"";
            Match match = Regex.Match(resp, pattern);
            if (match.Success)
            {
                string accessToken = match.Groups[1].Value;
                return accessToken;
            }
            else
            {
                return "";
            }
        }
        //Делать обработку данных на сервере?
        public async Task<string> MMIS_Attendance_percentage(string Year, string sem, string Form)
        {
            string url = "https://mmis-web.rudn-sochi.ru/api/Journals/Stat/Attendance?year=" + Year + "&sem=" + sem + "&formID=Form";
            var authToken = await MMISAuthKey();
            HttpClient client = new HttpClient();
            // Устанавливаем заголовок Authorization
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            HttpResponseMessage response = await client.GetAsync(url);
            string resp = await response.Content.ReadAsStringAsync();
            return resp;
        }
        private StringContent OBJToContentConverter(object data)
        {
            string json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return content;
        }
    }
}
