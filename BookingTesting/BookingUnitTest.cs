using homecoming.api.Abstraction;
using homecoming.api.Model;
using homecoming.api.Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookingTesting
{
    [TestClass]
    public class BookingUnitTest
    {
        public BookingUnitTest()
        {

        }

        [TestMethod]
        public void TestBookingNumberOfDays()
        {
            //Arrange
            int expected = 3;
            Booking booking = new Booking() { BookingId = 1, CustomerId = 1,RoomId = 1, NoOfRooms  = 2, NoOfOccupants= 3, BookingPrice = 1500, Check_In_Date = System.DateTime.Today, Check_Out_Date = System.DateTime.Today.AddDays(3) };
            IRepository<Booking> repo = new BookingRepo(null);

            //Act
            repo.Add(booking);

            //Assert
            int actual = booking.NoOfDaysBooked;
            Assert.AreEqual(expected, actual,"Unexpected result found!");
        }
    }
}
