using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PenaltyCalculation.Models
{
    public class ResultModel
    {
        public string CountryName { get; set; }
        public decimal PenaltyPrize { get; set; }
        public string CountryCurrencyName { get; set; }
        public string Message { get; set; }
        public decimal CountryCurrencyValue { get; set; }
        public List<DateTime> PenaltyDate { get; set; }
    }
}

