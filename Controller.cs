using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Your_App.UI.Controllers
{
    public class YourDataController : Controller
    {
        public IActionResult YourAnalyticsDashboardPage() => View();

    public List<string> nodeFQDNs = new List<string>
    {
    "SERVER-#1",
    "SERVER-#2",
    "SERVER-#3",
    "SERVER-#4",
    "SERVER-#5",
    "SERVER-#6"
    };

        private readonly string InfluxDBURL = "https://[InfluxDB-IP-ADDR]:8086";
        private readonly string DatabaseName = "db_name";
        private readonly string Username = "username";
        private readonly string Password = "password";

        public async Task<IActionResult> UcmJsonCallsActive()
        {   
            List<CucmData> cucmDataList = new List<CucmData>();
            string influxDbUrl = InfluxDBURL;
            string databaseName = DatabaseName;           
            string username = Username;
            string password = Password;

            foreach (var nodeFQDN in nodeFQDNs)
            {
                string query = $"SELECT \"CallsActive\" FROM \"cisco_callmanager\" WHERE \"server\" = '{nodeFQDN}' AND time >= now() - 5m";
                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        string apiUrl = $"{influxDbUrl}/query?db={databaseName}&q={Uri.EscapeDataString(query)}";

                        var byteArray = Encoding.ASCII.GetBytes($"{username}:{password}");
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                        HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            string responseContent = await response.Content.ReadAsStringAsync();
                            string nodeName = nodeFQDN;

                            JObject jsonResponse = JObject.Parse(responseContent);

                            if (jsonResponse != null)
                            {
                                JToken valuesToken = null;
                                if (jsonResponse?["results"] != null && jsonResponse["results"].Any())
                                {
                                    var firstResult = jsonResponse["results"][0];
                                    if (firstResult?["series"] != null && firstResult["series"].Any())
                                    {
                                        valuesToken = firstResult["series"][0]?["values"]?[0];
                                    }
                                }

                                if (valuesToken != null)
                                {
                                    string callsActive = valuesToken[1]?.ToString();
                                    if (callsActive != null)
                                    {
                                        CucmData cucmData = new CucmData()
                                        {
                                            Node = nodeFQDN,
                                            CallsActive = callsActive,
                                        };
                                        cucmDataList.Add(cucmData);
                                    }
                                    else
                                    {
                                        CucmData cucmDataError = new CucmData()
                                        {
                                            Node = nodeFQDN,
                                            CallsActive = "N/A",
                                        };
                                        cucmDataList.Add(cucmDataError);
                                    }
                                }
                                else
                                {
                                    CucmData cucmDataError = new CucmData()
                                    {
                                        Node = nodeFQDN,
                                        CallsActive = "N/A",
                                    };
                                    cucmDataList.Add(cucmDataError);
                                }
                            }
                            else
                            {
                                CucmData cucmDataError = new CucmData()
                                {
                                    Node = nodeFQDN,
                                    CallsActive = "N/A",
                                };
                                cucmDataList.Add(cucmDataError);
                            }
                        }   
                    }
                }
                catch (Exception ex)
                {
                    string errorMessage = "An error occured : " + ex.Message;
                    ViewBag.ErrorMessage = errorMessage;
                    return View();
                }
            }
            return Json(cucmDataList);
        }     
    }
}