using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PenaltyCalculation.Entity
{
    [Table("Holiday")]
    public class Holiday : BaseEntity
    {
        public int CountryId { get; set; }
        public DateTime HolidayDate { get; set; }
    }
}
