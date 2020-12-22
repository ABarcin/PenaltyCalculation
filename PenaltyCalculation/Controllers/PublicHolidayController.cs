using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PenaltyCalculation.Models;
using PenaltyCalculation.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PenaltyCalculation.Controllers
{
    public class PublicHolidayController : Controller
    {
        private readonly IProcessingService _context;
        public PublicHolidayController(IProcessingService processingService)
        {
            _context = processingService;
        }
    
        public IActionResult Index()
        {
            var countries = _context.GetAllCountries();
            var model = new PublicHolidayModel();
            foreach (var item in countries)
                model.Countries.Add(new SelectListItem { Text = item.CountryName, Value = item.Id.ToString() });
            return View("Index", model);
        }
        [HttpPost]
        public IActionResult Holiday(PublicHolidayModel model)
        {
            var publicHoldiays = _context.GetAllHolidaysByCountryId(model.SelectedCountryId);
            var publicHolidaysDate = new List<DateTime>();
            foreach (var item in publicHoldiays)
            {
                publicHolidaysDate.Add(item.HolidayDate);
            }
            model.PublicHolidays = publicHolidaysDate;
            return View("PublicHolidayView", model);
        }
       

    }
}
