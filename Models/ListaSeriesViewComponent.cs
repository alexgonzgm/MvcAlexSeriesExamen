using Microsoft.AspNetCore.Mvc;
using MvcAlexSeriesExamen.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcAlexSeriesExamen.Models
{
    public class ListaSeriesViewComponent : ViewComponent
    {

        private ServiceSeries service;

        public ListaSeriesViewComponent(ServiceSeries service)
        {
            this.service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Serie> series = await this.service.GetSeriesAsync();
            return View(series);
        }

    }
}
