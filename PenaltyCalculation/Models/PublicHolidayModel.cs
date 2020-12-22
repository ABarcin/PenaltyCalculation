using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PenaltyCalculation.Models
{
    public class PublicHolidayModel
    {
        public PublicHolidayModel()
        {
            Countries = new List<SelectListItem>();
        }
        public string CountryName { get; set; }
        public List<DateTime> PublicHolidays { get; set; }
        public IList<SelectListItem> Countries { get; set; }
        [DisplayName("Select Country For Public Holiday")]
        public int SelectedCountryId { get; set; }
    }
}
