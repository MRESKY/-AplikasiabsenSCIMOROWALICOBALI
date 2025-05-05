using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MobileAttendanceApp.Models;
using Newtonsoft.Json;

namespace MobileAttendanceApp.Services
{
    public class LeaveService
    {
        private readonly HttpClient _httpClient;

        public LeaveService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<LeaveRecord>> GetLeaveRecordsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/leave");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<LeaveRecord>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching leave records: {ex.Message}");
                return new List<LeaveRecord>();
            }
        }

        public async Task<bool> AddLeaveAsync(LeaveRecord leaveRecord)
        {
            try
            {
                var json = JsonConvert.SerializeObject(leaveRecord);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                Console.WriteLine($"Sending POST request to api/leave with payload: {json}");
                var response = await _httpClient.PostAsync("api/leave", content);
                Console.WriteLine($"Response: {response.StatusCode}");

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding leave record: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> ApproveLeaveAsync(string id)
        {
            try
            {
                var response = await _httpClient.PutAsync($"api/leave/{id}/approve", null);
                Console.WriteLine($"Response: {response.StatusCode}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error approving leave record: {ex.Message}");
                return false;
            }
        }
    }
}