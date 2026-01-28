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
        
        if (Status == BookingStatus.Cancelled || Status == BookingStatus.Completed) 
        { 
            throw new InvalidOperationException("Cannot change status of a cancelled or completed booking."); 
        } 
        Status = newStatus; 
    }  
 }
