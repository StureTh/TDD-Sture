using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
  public class TourSchedule : ITourSchedule
    {
      readonly List<Tour> _tourList = new List<Tour>();

        public void CreateTour(string tourName, DateTime tourDate, int nbrOfSeats)
        {
           



            if (_tourList.Where(x => x.TourDate == tourDate).Count() < 3)
            {
                var birthDayTour = new Tour(tourName, tourDate, nbrOfSeats);

                _tourList.Add(birthDayTour);

            }
            else
            {
                throw new TourAllocationException("Cant have more than three tours per day");
            }



        }

        public List<Tour> GetToursFor(DateTime tourDate)
        {

           return _tourList.Where(x => x.TourDate == tourDate).ToList();

        }
    }
}
