using MvcAlexSeriesExamen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MvcAlexSeriesExamen.Services
{
    public class ServiceSeries
    {
        private Uri UriApi;
        private MediaTypeWithQualityHeaderValue Header;
        public ServiceSeries(string url)
        {
            this.UriApi = new Uri(url);
            this.Header =
                new MediaTypeWithQualityHeaderValue("application/json");
        }

        private async Task<T> CallApi<T>(String request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = this.UriApi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                HttpResponseMessage response =
                    await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<List<Serie>> GetSeriesAsync()
        {
            string request = "api/Series";
            List<Serie> series = await this.CallApi<List<Serie>>(request);
            return series;
        }

        public async Task<Serie> FindSerieAsync(int id)
        {
            string request = "api/Series/" + id;
            Serie serie = await this.CallApi<Serie>(request);
            return serie;
        }




    }
}
