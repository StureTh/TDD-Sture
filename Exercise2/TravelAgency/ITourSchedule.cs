using System;
using System.Collections.Generic;

namespace TravelAgency
{
    public interface ITourSchedule
    {
        void CreateTour(string tourName, DateTime tourDate, int nbrOfSeats);
        List<Tour> GetToursFor(DateTime tourDate);
    }
}