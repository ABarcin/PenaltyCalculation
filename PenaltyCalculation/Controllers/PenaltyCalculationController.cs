using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PenaltyCalculation.Models;
using PenaltyCalculation.Service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PenaltyCalculation.Controllers
{
    public class PenaltyCalculationController : Controller
    {
        private readonly IProcessingService _context;
        public PenaltyCalculationController(IProcessingService processingService)
        {
            _context = processingService;
        }
        public IActionResult Index()
        {
            var countries = _context.GetAllCountries();
            var model = new CalculationModel();
            model.ReturnedDate = DateTime.Now.Date;
            model.CheckedOutDate = DateTime.Now.Date;
            foreach (var item in countries)
                model.Countries.Add(new SelectListItem { Text = item.CountryName, Value = item.Id.ToString() });

            return View(model);
        }

        [HttpPost]
        public IActionResult CalculatePenalty(CalculationModel model)
        {
            var checkedOutDate = model.CheckedOutDate;
            var returnedDate = model.ReturnedDate.AddDays(1);

            var betweenDates = new List<DateTime>();


            while (checkedOutDate != returnedDate)
            {
                betweenDates.Add(checkedOutDate);
                checkedOutDate = checkedOutDate.AddDays(1);
            }

            var countryOffdays = _context.GetOffDaysByCountryId(model.SelectedCountryId);
            var publicHoldiays = _context.GetAllHolidaysByCountryId(model.SelectedCountryId);

            var penaltyDates = new List<DateTime>();
            foreach (var date in betweenDates)
            {
                var dateIsOff = countryOffdays.Any(x => date.ToString("dddd", new CultureInfo("en-GB")) == x.OffWeekDay.ToString());
                if (dateIsOff)
                    continue;

                var dateIsPublic = publicHoldiays.Any(x => date == x.HolidayDate.Date);
                if (dateIsPublic)
                    continue;

                penaltyDates.Add(date);
            }
            var selectedCountry = _context.GetCountryById(model.SelectedCountryId);
            var resultModel = new ResultModel
            {
                CountryName = selectedCountry.CountryName,
                CountryCurrencyName = selectedCountry.CountryCurrencyName,
                CountryCurrencyValue = selectedCountry.CountryCurrencyValue

            };
            if (penaltyDates.Count > 10)
            {
                resultModel.PenaltyPrize = penaltyDates.Count * 5 * selectedCountry.CountryCurrencyValue;
                resultModel.Message = penaltyDates.Count+" Days Penalty = ";
                resultModel.PenaltyDate = penaltyDates;
            }
            else
                resultModel.Message = "There is No Penalty";
            return View("Result", resultModel);

        }

    }
}
