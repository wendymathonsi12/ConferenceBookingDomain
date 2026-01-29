public class Program
{
    public static async Task Main()
    {
        Console.WriteLine("--- Conference Booking System 1.3 ---");
        var room = new ConferenceRoom("BitCube Boardroom", 10, RoomLayout.Medium);

        // 1. Valid Scenario
        try
        {
            var booking1 = new Booking(room.Id, DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));
            room.AddBooking(booking1);
            Console.WriteLine("Success: Booking 1 added.");

            // Save Asynchronously
            await BookingFileService.SaveBookingsAsync(room.Bookings);
            Console.WriteLine("Success: Data persisted to file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected Error: {ex.Message}");
        }

        // 2. Invalid Scenario (Conflict)
        try
        {
            Console.WriteLine("\nAttempting overlapping booking...");
            var booking2 = new Booking(room.Id, DateTime.Now.AddHours(1.5), DateTime.Now.AddHours(2.5));
            room.AddBooking(booking2);
        }
        catch (BookingConflictException ex)
        {
            Console.WriteLine($"Caught Expected Conflict: {ex.Message}");
        }

        // 3. Invalid Scenario (Guard Clause)
        try
        {
            Console.WriteLine("\nAttempting invalid room creation...");
            var badRoom = new ConferenceRoom("", -5, RoomLayout.small);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Caught Validation Error: {ex.Message}");
        }
    }
}
