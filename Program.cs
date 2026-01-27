// Domain namespace 
Console.WriteLine("--- Testing Domain Model ---");
 

Console.WriteLine("Conference Model");
 try { 
    var boardroom = new ConferenceRoom("Apollo 11", 12, RoomType.Boardroom);
    var meeting = new Booking(boardroom.Id, DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));
    boardroom.AddBooking(meeting); Console.WriteLine($"Room: {boardroom.Name} ({boardroom.Type}) created."); 
       Console.WriteLine($"Booking Status: {meeting.Status}"); 
  }
   catch (Exception ex) 
 { 
    Console.WriteLine($"Business Rule Violation: {ex.Message}"); 
}