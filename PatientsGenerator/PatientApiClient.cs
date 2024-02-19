using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PatientsGenerator
{
    public class PatientApiClient
    {
        private readonly HttpClient _httpClient;

        public PatientApiClient(string baseUrl)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task AddPatientAsync(PatientModel patient)
        {
            var json = JsonSerializer.Serialize(patient);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("BirthDate", patient.BirthDate),
                new KeyValuePair<string, string>("GenderId", patient.GenderId),
                new KeyValuePair<string, string>("IsOfficial", patient.IsOfficial),
                new KeyValuePair<string, string>("Family", patient.Family),
                new KeyValuePair<string, string>("Given", patient.Given),
            });
            var response = await _httpClient.PostAsync("patients", formContent);

            response.EnsureSuccessStatusCode();
        }
    }
}
