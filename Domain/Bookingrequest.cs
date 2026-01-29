using ConferenceRoomDomain;

public record BookingRequest
 {
    private ConferenceRoom conferenceRoom;

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
    public object Room { get; internal set; }

    public BookingRequest(Guid roomId, DateTime start, DateTime end)
      { 
        if (end <= start) throw new ArgumentException("End time must be after start time.");
          StartTime = start; 
          EndTime = end; 
          Status = BookingStatus.Pending; 
    }

    public BookingRequest(ConferenceRoom conferenceRoom)
    {
        this.conferenceRoom = conferenceRoom;
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
