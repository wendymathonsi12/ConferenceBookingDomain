 

public enum BookingStatus 
{ 
    Pending,
     Confirmed, 
     Cancelled,
      Completed 
} 
  
public enum RoomType
 { 
    FocusRoom,
    StandardMeet,
    Boardroom,
    LargeRoom
} 
     

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
                     { 
                        throw new InvalidOperationException("Room is already booked for this time slot."); 
                    } 
                    _bookings.Add(booking);
                    
                } 
         } 
 
                     
