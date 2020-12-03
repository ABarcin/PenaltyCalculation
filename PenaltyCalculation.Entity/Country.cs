using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PenaltyCalculation.Entity
{
    [Table("Country")]
    public class Country : BaseEntity
    {
        public string CountryName { get; set; }
        public decimal CountryCurrencyValue { get; set; }
        public string CountryCurrencyName { get; set; }

    }
}
