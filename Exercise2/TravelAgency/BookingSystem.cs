using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
   public class BookingSystem
    {
        private ITourSchedule TourScheduler;
       public List<Booking> BookingList { get; set; }
        public BookingSystem(ITourSchedule tourScheduler)
        {
            this.TourScheduler = tourScheduler;
            BookingList = new List<Booking>();
        }


       public void CreateBooking(string name, DateTime date, Passenger passenger)
       {
           var tour = TourScheduler.GetToursFor(date).FirstOrDefault(x => x.Name == name);

           if (tour == null)
           {
               throw new NoTourAvailableException(name, date);
           }
           if (NumberOfSeatsLeft(tour) <= 0)
           {
               throw new NoSeatsLeftException(tour);
           }
           else
           {
               BookingList.Add(new Booking(tour,passenger));
           }

       }


       public int NumberOfSeatsLeft(Tour tour)
       {
           List<Booking> bookings = BookingList.Where(x => x.Tour == tour).ToList();


           return tour.NbrOfSeats - bookings.Count();
       }

       public List<Booking> GetBookingFor(Passenger passenger)
       {
           var currentBookings = BookingList.Where(x => x.Passenger == passenger).ToList();

           return currentBookings;
       } 
    }
}
