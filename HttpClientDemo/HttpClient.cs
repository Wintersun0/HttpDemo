using System.Diagnostics;
using System.Text;

namespace HttpClientDemo
{
    internal class HttpClient
    {
        private readonly System.Net.Http.HttpClient _httpClient;

        public HttpClient()
        {
            _httpClient = new System.Net.Http.HttpClient();
        }

        public string SendMessage(string message, string url)
        {
            var data = new { wx_data = message };
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = _httpClient.PostAsync($"{url}send", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseText = response.Content.ReadAsStringAsync().Result;
                    Trace.WriteLine("POST 请求成功，服务器响应：");
                    Trace.WriteLine(responseText);
                    return responseText ?? "";
                }
                else
                {
                    var errorText = response.Content.ReadAsStringAsync().Result;
                    Trace.WriteLine($"POST 请求失败：{response.StatusCode} - {errorText}");
                    return "";
                }
            }
            catch (HttpRequestException e)
            {
                Trace.WriteLine($"请求发生异常：{e.Message}");
                return "";
            }
        }

        public string GetMessage(string query, string url)
        {
            try
            {
                HttpResponseMessage response;
                if (String.IsNullOrEmpty(query))
                    response = _httpClient.GetAsync($"{url}").Result;
                else
                    response = _httpClient.GetAsync($"{url}?{query}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseText = response.Content.ReadAsStringAsync().Result;
                    Trace.WriteLine("GET 请求成功，服务器响应：");
                    Trace.WriteLine(responseText);
                    return responseText ?? "";
                }
                else
                {
                    var errorText = response.Content.ReadAsStringAsync().Result;
                    Trace.WriteLine($"GET 请求失败：{response.StatusCode} - {errorText}");
                    return "";
                }
            }
            catch (HttpRequestException e)
            {
                Trace.WriteLine($"请求发生异常：{e.Message}");
                return "";
            }
        }
    }
}
