Console.WriteLine("--- Conference Room Domain Model Demo ---");

try 
{
   
    var room = new ConferenceRoom("BITCUBE", 10, RoomLayout.U_Shape);
   
    var request = new BookingRequest(
        room.Id, 
        DateTime.Now.AddDays(1), 
        DateTime.Now.AddDays(1).AddHours(2), 
        "John Doe"
    );

   
    var booking = new Booking(request.RoomId, request.StartTime, request.EndTime);
    
    Console.WriteLine($"Room '{room.Name}' created successfully.");
    Console.WriteLine($"Booking Status: {booking.Status} for {request.RequestedBy}");
    
    booking.Confirm();
    Console.WriteLine($"Booking Confirmed: {booking.Status}");
}
catch (Exception ex)
{
    Console.WriteLine($"Business Rule Violation: {ex.Message}");
}
