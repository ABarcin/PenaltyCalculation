using PenaltyCalculation.Entity;
using System.Collections.Generic;

namespace PenaltyCalculation.Service
{
    public interface IProcessingService
    {
        List<Country> GetAllCountries();
        Country GetCountryById(int id);
        List<Holiday> GetAllHolidaysByCountryId(int countryId);
        List<OffDay> GetOffDaysByCountryId(int countryId);
    }
}
