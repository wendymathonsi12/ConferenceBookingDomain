namespace ConferenceRoomDomain
{
public record Booking
{
 //public Guid Id { get; init; }
 //public Guid RoomId { get; init; }
 public 
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
     set; 
  }
 public Booking(ConferenceRoom room, DateTime start, DateTime end)
 {  
    room = room;
    StartTime = start;
    EndTime = end;
    Status = BookingStatus.Pending;
}
 public void Confirm() => Status = BookingStatus.Confirmed;
 public void Cancel() => Status = BookingStatus.Cancelled;
}

}
