using System.Text.Json;

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
