using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PenaltyCalculation.Entity
{
    [Table("OffDay")]
    public class OffDay : BaseEntity
    {

        public int CountryId { get; set; }
        public string OffWeekDay { get; set; }
    }
}
