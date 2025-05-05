using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using mobile-attendance-app.Models;

namespace mobile-attendance-app.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://your-api-url.com/") // Replace with your API URL
            };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<bool> SendAttendanceRecordAsync(AttendanceRecord record)
        {
            var json = JsonConvert.SerializeObject(record);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/attendance", content); // Adjust the endpoint as necessary
            return response.IsSuccessStatusCode;
        }

        public async Task<AttendanceRecord[]> GetAttendanceRecordsAsync()
        {
            var response = await _httpClient.GetAsync("api/attendance"); // Adjust the endpoint as necessary
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AttendanceRecord[]>(json);
            }
            return Array.Empty<AttendanceRecord>();
        }
    }
}