using Microsoft.EntityFrameworkCore;
using PenaltyCalculation.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PenaltyCalculation.Data
{

    public class DbObjectContext : DbContext
    {
        public DbObjectContext(DbContextOptions<DbObjectContext> options) : base(options)
        {
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<OffDay> OffDays { get; set; }
    }

}
