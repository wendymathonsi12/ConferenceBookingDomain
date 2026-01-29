namespace ConferenceRoomDomain;

public class BookingService
{
    private readonly List<ConferenceRoom> _rooms = new();
    private readonly List<Booking> _bookings = new();

    
    public void AddRoom(ConferenceRoom room) => _rooms.Add(room);

    public string ProcessBookingRequest(BookingRequest request)
    {
      
        var room = _rooms.FirstOrDefault(r => r.Id == request.RoomId);
        if (room == null)
            return "REJECTED: Room does not exist.";
        bool isOverlapping = _bookings.Any(b => 
            b.RoomId == request.RoomId && 
            b.Status != BookingStatus.Cancelled &&
            request.StartTime < b.EndTime && 
            b.StartTime < request.EndTime);

        if (isOverlapping)
            return $"REJECTED: Room '{room.Name}' is already booked for this time.";
        var newBooking = new Booking(request.RoomId, request.StartTime, request.EndTime);
        _bookings.Add(newBooking);
        
        return $"SUCCESS: Booking confirmed for {room.Name} (ID: {newBooking.Id})";
    }

    public IEnumerable<Booking> GetBookings() => _bookings.AsReadOnly();
}
