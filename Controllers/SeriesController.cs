using Microsoft.AspNetCore.Mvc;
using MvcAlexSeriesExamen.Models;
using MvcAlexSeriesExamen.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcAlexSeriesExamen.Controllers
{
    public class SeriesController : Controller
    {
        ServiceSeries service;
        public SeriesController(ServiceSeries service)
        {
            this.service = service;
        }


        public async Task<IActionResult> GetSeries()
        {
            List<Serie> series = await this.service.GetSeriesAsync();
            return View(series);
        }

        public async Task<IActionResult> Details(int idserie)
        {
            Serie serie = await this.service.FindSerieAsync(idserie);
            return View(serie);

        }


    }
}
