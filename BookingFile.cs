using System.Text.Json;

namespace ConferenceRoomDomain;
public static class BookingFileService
{
    private const string FilePath = "bookings.json";

    public static async Task SaveBookingsAsync(IEnumerable<Booking> bookings)
    {
        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(bookings, options);
            await File.WriteAllTextAsync(FilePath, json);
        }
        catch (IOException ex)
        {
            // Bubble up with context
            throw new Exception("Failed to save booking data to disk.", ex);
        }
    }

    public static async Task<List<Booking>> LoadBookingsAsync()
    {
        if (!File.Exists(FilePath)) return new List<Booking>();

        try
        {
            string json = await File.ReadAllTextAsync(FilePath);
            return JsonSerializer.Deserialize<List<Booking>>(json) ?? new List<Booking>();
        }
        catch (JsonException)
        {
            Console.WriteLine("Warning: Booking file corrupted. Starting with empty list.");
            return new List<Booking>();
        }
    }
}


public class BookingFileStore
{
    private readonly string _filepath;
    public BookingFileStore(string file_path)
    {
        _filepath = file_path;
    }
    public async Task SaveAsynce(IEnumerable<Booking> bookings)
    {
        string json_ = JsonSerializer.Serialize(bookings);
        await File.WriteAllTextAsync(_filepath, json_);
    }
    public async Task<List<Booking>> LoadAsync()
    {
        if(!File.Exists(_filepath))
        {
            return new List<Booking>();
        }
        string json_ = await File.ReadAllTextAsync(_filepath);
        return JsonSerializer.Deserialize<List<Booking>>(json_) ?? new List<Booking>(); 
    }
}