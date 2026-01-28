using System;
using RoomBookingApp;
using RoomBookingApp.Domain;  
using RoomBookingApp.Services;


Console.WriteLine("Conference Booking Domain");
 try { 
    var boardroom = new ConferenceRoom("bitcube", 12, RoomType.Boardroom);
    var meeting = new Booking(boardroom.Id, DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));
    boardroom.AddBooking(meeting); Console.WriteLine($"Room: {boardroom.Name} ({boardroom.Type}) created."); 
       Console.WriteLine($"Booking Status: {meeting.Status}"); 
  }
   catch (Exception ex) 
 { 
    Console.WriteLine($"Business Rule Violation: {ex.Message}"); 
}