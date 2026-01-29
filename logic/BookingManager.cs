using System.Net.Cache;
using ConferenceRoomDomain;

public class Bookingmanager
{
    // centralised busineess logic 
    private readonly List<Booking> _bookings;
    public  IReadOnlyList<Booking> GetBookings()
    {
        return _bookings.ToList();
    }
    public Booking CreateBooking(BookingRequest bookingRequest, DateTime now, DateTime dateTime)
    {
        // guard clause 
        if(bookingRequest.Room == null)
        {
            throw new ArgumentException("Room Exist");
        }
        if(bookingRequest.StartTime >= bookingRequest.EndTime)
        {
            throw new ArgumentException("invalid time range");
        }
        bool overlaps = _bookings.Any(b => b.Room == bookingRequest.Room &&
        b.status == BookingStatus.Confirmed && bookingRequest.StartTime <b.EndTime && bookingRequest.EndTime > 
        b.StartTime);

        if(overlaps)
        {
            throw new BookingConflictException("Error occured");
        }
        Booking booking = new Booking(bookingRequest.Room, bookingRequest.StartTime, bookingRequest.EndTime);
        booking.Confirm();
        _bookings.Add(booking);
        return booking;
    }
}