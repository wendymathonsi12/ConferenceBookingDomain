public class BookingConflictException : Exception
{
    public BookingConflictException(string message) : 
    base("Booking overlaps with an existing booking ")
    {
        
    }
    public BookingConflictException(Guid roomId, DateTime start) 
        : base($"Room {roomId} is unavailable for the requested slot starting at {start}.") { }
}
