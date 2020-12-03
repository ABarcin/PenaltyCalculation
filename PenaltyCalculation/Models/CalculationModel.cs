using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PenaltyCalculation.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PenaltyCalculation.Models
{
    public class CalculationModel
    {
        public CalculationModel()
        {
            Countries = new List<SelectListItem>();
        }
        [DisplayName("Checked out date")]
        public DateTime CheckedOutDate { get; set; }

        [DisplayName("Returned date")]
        public DateTime ReturnedDate { get; set; }

        [DisplayName("Select country")]
        public int SelectedCountryId { get; set; }
        public IList<SelectListItem> Countries { get; set; }

    };
}
