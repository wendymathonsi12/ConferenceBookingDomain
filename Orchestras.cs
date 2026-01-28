using ConferenceBookingApp.Services;

var service = new BookingService();

var room1 = new ConferenceRoom("Grand Hall", 50, RoomLayout.Theater);
service.AddRoom(room1);

Console.WriteLine("--- Assignment 1.2: Booking Logic Demo ---\n");

// 2. Scenario: Valid Booking
var request1 = new BookingRequest(room1.Id, DateTime.Now.AddHours(1), DateTime.Now.AddHours(2), "Team Alpha");
Console.WriteLine($"Request 1: {service.ProcessBookingRequest(request1)}");

// 3. Scenario: Double-Booking
var request2 = new BookingRequest(room1.Id, DateTime.Now.AddHours(1.5), DateTime.Now.AddHours(3), "Beta Testing");
Console.WriteLine($"Request 2: {service.ProcessBookingRequest(request2)}");

// 4. Scenario: Non-existent Room
var request3 = new BookingRequest(Guid.NewGuid(), DateTime.Now, DateTime.Now.AddHours(1), "Invisible Team");
Console.WriteLine($"Request 3: {service.ProcessBookingRequest(request3)}");
