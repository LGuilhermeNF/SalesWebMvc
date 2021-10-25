using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordsService _salesRecordsService;

        public SalesRecordsController(SalesRecordsService salesRecordsService)
        {
            _salesRecordsService = salesRecordsService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }

            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minData"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxData"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecordsService.FindByDateAsync(minDate, maxDate);
            return View(result);

        }

        public IActionResult GroupingSearch()
        {
            return View();
        }
    }
}
