using PenaltyCalculation.Data;
using PenaltyCalculation.Entity;
using System.Collections.Generic;
using System.Linq;

namespace PenaltyCalculation.Service
{
    public class CalculationProcessingService : IProcessingService
    {
        private readonly DbObjectContext _context;
        public CalculationProcessingService(DbObjectContext context)
        {
            _context = context;
        }
        public List<Country> GetAllCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountryById(int id)
        {
            return _context.Countries.FirstOrDefault(x => x.Id == id);
        }
        public List<Holiday> GetAllHolidaysByCountryId(int countryId)
        {
            return _context.Holidays.Where(x => x.CountryId == countryId).ToList();
        }
        public List<OffDay> GetOffDaysByCountryId(int countryId)
        {

            return _context.OffDays.Where(x => x.CountryId == countryId).ToList();
        }
    }
}
