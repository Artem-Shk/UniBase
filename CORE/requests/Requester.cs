using Azure;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System;

namespace UniBase.CORE.requests
{
    public class Requester
    {
        HttpClient client = new HttpClient();
        
        public async Task<string>  MMISAuthKey()
        {
            string url = "https://mmis-web.rudn-sochi.ru/api/tokenauth";
            var data = new {userName = "shakrislanov.a",password="Dstayte8",isParent=false,fingerprint="d6005043edad6d17dc0ae27b80fbd2a5"};
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
        public async void MMIS_Attendance_percentage()
        {
            string url = "https://mmis-web.rudn-sochi.ru/WebApp/#/Journals/Stat/Attendance";
            var authToken = RequestResults.authToken;
            var data = new { Autoken = authToken};


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
