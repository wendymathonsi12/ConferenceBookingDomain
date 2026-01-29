using ConferenceRoomDomain;
static async Task Main()
{


    SeedData data = new SeedData();
    List<ConferenceRoom> rooms = data.SeedData();
    Bookingmanager manager = new Bookingmanager();
    BookingFileStore store = new BookingFileStore("booking.json");
        try
    {
      manager.CreateBooking(new BookingRequest(rooms[0]), 
      DateTime.Now, DateTime.Now.AddHours(1));
      await store.SaveAsynce(manager.GetBookings());
    }
    catch(BookingConflictException ex)
    {
        System.Console.WriteLine(ex.Message);
    }

}