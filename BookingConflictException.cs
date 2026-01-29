public class BookingConflictException : Exception
{
    public BookingConflictException(string message) : base(message) { }
    public BookingConflictException(Guid roomId, DateTime start) 
        : base($"Room {roomId} is unavailable for the requested slot starting at {start}.") { }
}
