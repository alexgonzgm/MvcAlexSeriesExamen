using Microsoft.AspNetCore.Mvc;
using MvcAlexSeriesExamen.Models;
using MvcAlexSeriesExamen.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcAlexSeriesExamen.Controllers
{
    public class PersonajesController : Controller
    {
        ServicePersonajes service;
        ServiceSeries ss;
        public PersonajesController(ServicePersonajes service, ServiceSeries ss)
        {
            this.service = service;
            this.ss = ss;
        }
        public async Task<IActionResult> AddPersonaje()
        {
            List<Serie> series = await this.ss.GetSeriesAsync();
            ViewData["SERIES"] = series;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddPersonaje(string nombre, string imagen, int idserie)
        {
            List<Serie> series = await this.ss.GetSeriesAsync();
            ViewData["SERIES"] = series;
            await this.service.AddPersonaje(nombre, imagen, idserie);

            return RedirectToAction("GetSeries", "Series");
        }


        public async Task<IActionResult> GetPersonajesSerie(int idserie)
        {
            List<Personaje> personajes = await this.service.PersonajesSerie(idserie);
            return View(personajes);
        }

        public async Task<IActionResult> CambioSerie()
        {
            List<Personaje> personajes = await this.service.GetPersonajesAsync();
            List<Serie> series = await this.ss.GetSeriesAsync();
            ViewData["LP"] = personajes;
            ViewData["LS"] = series;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CambioSerie(int idpersonaje, int idserie)
        {
            await this.service.CambiarSerie(idpersonaje, idserie);

            return RedirectToAction("GetSeries", "Series");
        }


    }
}
