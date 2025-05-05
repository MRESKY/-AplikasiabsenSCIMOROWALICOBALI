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

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://your-api-url.com/"); // Replace with your API URL
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<bool> SendAttendanceRecordAsync(AttendanceRecord record)
        {
            try
            {
                var json = JsonConvert.SerializeObject(record);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                Console.WriteLine($"Sending POST request to api/attendance with payload: {json}");
                var response = await _httpClient.PostAsync("api/attendance", content);
                Console.WriteLine($"Response: {response.StatusCode}");

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending attendance record: {ex.Message}");
                return false;
            }
        }

        public async Task<AttendanceRecord[]> GetAttendanceRecordsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/attendance");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<AttendanceRecord[]>(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching attendance records: {ex.Message}");
            }
            return Array.Empty<AttendanceRecord>();
        }
    }
}

builder.Services.AddHttpClient<ApiService>(client =>
{
    client.BaseAddress = new Uri("https://your-api-url.com/"); // Replace with your API URL
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});