using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency;
using NUnit.Framework;

namespace TravelAgencyTests
{
    [TestFixture]
   public class TourScheduleTests
    {
        public TourSchedule Sut;

        [SetUp]
        public void Setup()
        {
            Sut = new TourSchedule();   
        }

        [Test]
        public void CanCreateNewTour()
        {
            var tourDate = new DateTime(2017,4,27,6,30,01);
           
            Sut.CreateTour("birthdaytour", tourDate, 15);
           

            var tourList = Sut.GetToursFor(tourDate);

            Assert.IsTrue(tourList.Count() == 1);

            Assert.IsTrue(tourList.Where(x => x.TourDate.Date == tourDate.Date && x.Name == "birthdaytour") != null);

        }

        [Test]
        public void GetToursForGivenDayOnly()
        {
            Sut.CreateTour("New years Morning Tour", new DateTime(2017,1,1), 15 );
            Sut.CreateTour("New Years Afternoon Tour", new DateTime(2017,1,1),14 );
            Sut.CreateTour("Christmas Tour", new DateTime(2017,12,24), 20 );
            Sut.CreateTour("Vacation Tour", new DateTime(2017,6,8), 10);

            var tourList = Sut.GetToursFor(new DateTime(2017, 1, 1));

            Assert.IsTrue(tourList.Count() == 2);

        }

        [Test]
        public void SendingInMoreToursThanAllowed_ReturnsFalse()
        {
            var toursToday = new DateTime(2017,05,24);

            Sut.CreateTour("Tour one", toursToday, 15);
            Sut.CreateTour("Tour two", toursToday, 15);
            Sut.CreateTour("Tour three", toursToday, 15);


            Assert.Throws<TourAllocationException>(() =>
            {
                
                Sut.CreateTour("Tour four", toursToday, 15);
            });


        }

    }

   
}
