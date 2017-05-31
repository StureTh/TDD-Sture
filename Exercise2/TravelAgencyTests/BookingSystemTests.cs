using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace TravelAgencyTests
{
    [TestFixture]
    public class BookingSystemTests
    {
        private TourScheduleStub tourScheduler;
        private BookingSystem sut;
        private Passenger passenger;

        [SetUp]
        public void Setup()
        {
            tourScheduler = new TourScheduleStub();

            sut = new BookingSystem(tourScheduler);

            
        }


        [Test]
        public void CanCreateBooking()
        {

            Tour tour = new Tour("Magical Mystery Tour", new DateTime(2017, 5, 31), 1);
            passenger = new Passenger("Klas", "Klättermus");
            List<Booking> bokingsList = new List<Booking>();


            tourScheduler.Tours.Add(tour);
            sut.CreateBooking("Magical Mystery Tour", new DateTime(2017, 5, 31), passenger);

            bokingsList = sut.GetBookingFor(passenger);

            Assert.AreEqual(1, bokingsList.Count);
            Assert.AreEqual(tour, bokingsList.FirstOrDefault().Tour);





        }

        [Test]
        public void CreateBookingOnInvalidTour_ThrowsException()
        {   
            passenger = new Passenger("Klas","Klättermus");

            Assert.Throws<NoTourAvailableException>(() => sut.CreateBooking("Secret Tour", DateTime.Now, passenger));


        }

        [Test]
        public void CreateBookingOnFullTour_ThrowsException()
        {
            Tour tour = new Tour("Magical Mystery Tour",new DateTime(2017,5,31),1);

            var firstPassenger = passenger;
            var secondPassenger = new Passenger("John", "Lennon");

            tourScheduler.Tours.Add(tour);

            sut.CreateBooking("Magical Mystery Tour", new DateTime(2017,5,31),firstPassenger);

            Assert.Throws<NoSeatsLeftException>(
                () => sut.CreateBooking("Magical Mystery Tour", new DateTime(2017, 5, 31), secondPassenger));


        }

    }
}

   
