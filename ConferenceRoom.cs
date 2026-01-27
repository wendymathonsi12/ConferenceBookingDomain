Domain namespace ConferenceBooking.Domain; 
// Choice: Enum for clear, type-safe status management. 
public enum BookingStatus 
{ 
    Pending,
     Confirmed, 
     Cancelled,
      Completed 
} // Choice: Additional Business Rule Enum. // Represents the purpose of the room to enforce booking constraints later.
//  
public enum RoomType
 { 
    FocusRoom, 
    // Small, 1-2 people StandardMeet, // Mid-sized, 4-10 people Boardroom 
    // // Large, 10+ people, premium equipment } // Choice: Record for Booking. 
    // // Bookings are often treated as data snapshots of a transaction. 
public record Booking
 { 
    public Guid Id 
    { 
        get;
         init; 
        } 
    public Guid RoomId 
    {
         get;
          init;
    } 
    public DateTime StartTime 
    { 
        get; 
        init;
   } 
   public DateTime EndTime 
   {
     get;
      init;
       }
    public BookingStatus Status
     {
         get;
          private set; }
     public Booking(Guid roomId, DateTime start, DateTime end)
      { 
        if (end <= start) throw new ArgumentException("End time must be after start time.");
         Id = Guid.NewGuid();
          RoomId = roomId; 
          StartTime = start; 
          EndTime = end; 
          Status = BookingStatus.Pending; 
    }
     public void UpdateStatus(BookingStatus newStatus) 
    { 
        // Example of internal business logic: Can't cancel a completed booking if
        //  (Status == BookingStatus.Completed && newStatus == BookingStatus.Cancelled) throw new InvalidOperationException("Cannot cancel a completed booking."); 
        // Status = newStatus; } } // Choice: Class for ConferenceRoom. 
        // // Rooms are Entities: they have a continuous identity and internal state (availability). 
    public class ConferenceRoom
    { 
        public Guid Id
         { 
            get;
             } 
             public string Name
              { get;
               private set;
                } public int Capacity 
                { get; 
                private set; }
                 public RoomType Type 
                 { get;
                  init; 
                }
                 // Encapsulation: Field is private, access is controlled. 
                private readonly List<Booking> _bookings = new(); 
                public IReadOnlyCollection<Booking> Bookings => _bookings.AsReadOnly(); 
                public ConferenceRoom(string name, int capacity, RoomType type)
                 {
                     if (string.IsNullOrWhiteSpace(name)) 
                     throw new ArgumentException("Name required."); 
                     if (capacity <= 0) throw new ArgumentException("Capacity must be positive."); 
                     Id = Guid.NewGuid(); Name = name; Capacity = capacity; Type = type; 
                     } 
                     public void AddBooking(Booking booking) 
                     { // Business Rule: Prevent double booking (Simplistic check) 
                       if (_bookings.Any(b => b.StartTime < booking.EndTime && booking.StartTime < b.EndTime))
                     { throw new InvalidOperationException("Room is already booked for this time slot."); } _bookings.Add(booking); } } 
                     
