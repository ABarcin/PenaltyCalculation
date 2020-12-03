using PenaltyCalculation.Entity;
using System;
using System.Collections.Generic;
using System.Text;

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
