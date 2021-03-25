using MvcAlexSeriesExamen.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MvcAlexSeriesExamen.Services
{
    public class ServicePersonajes
    {
        private Uri UriApi;
        private MediaTypeWithQualityHeaderValue Header;
        public ServicePersonajes(string url)
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
        public async Task<Personaje> FindPersonaje(int id)
        {
            string request = "/api/Personajes/" + id;
            Personaje personaje = await this.CallApi<Personaje>(request);
            return personaje;

        }

        public async Task AddPersonaje(string nombre, string imagen, int idserie)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/Personajes";
                client.BaseAddress = this.UriApi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                Personaje personaje = new Personaje();
                personaje.NombrePersonaje = nombre;
                personaje.Imagen = imagen;
                personaje.IdSerie = idserie;
                string json = JsonConvert.SerializeObject(personaje);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                await client.PostAsync(request, content);

            }
        }

        public async Task CambiarSerie(int idpersonaje, int idserie)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "/api/Personajes/CambioDeSerie/" + idpersonaje + "/" + idserie;
                client.BaseAddress = this.UriApi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                StringContent content = new StringContent("", Encoding.UTF8, "application/json");
                await client.PutAsync(request, content);


            }


        }

        public async Task<List<Personaje>> PersonajesSerie(int idserie)
        {
            string request = "/api/Personajes/FindPersonajeSerie/" + idserie;
            List<Personaje> personajes = await this.CallApi<List<Personaje>>(request);
            return personajes;

        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            string request = "/api/Personajes";
            List<Personaje> personajes = await this.CallApi<List<Personaje>>(request);
            return personajes;
        }
    }
}
