using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency;

namespace TravelAgencyTests
{
    public class TourScheduleStub : ITourSchedule
    {
        public List<Tour> Tours { get; set; }

        public TourScheduleStub()
        {
            Tours = new List<Tour>();
        }

        public void CreateTour(string tourName, DateTime tourDate, int nbrOfSeats)
        {
           Tours.Add(new Tour
           {
               Name = tourName,
               TourDate = tourDate,
               NbrOfSeats = nbrOfSeats
           });
        }

        public List<Tour> GetToursFor(DateTime tourDate)
        {
            return Tours;
            
        }
    }
}
