namespace GameStore.Frontend.Models;

public class GameSummary
{
    public int id { get; set; }
    public required string name { get; set; }
    public required string genre { get; set; }
    public decimal price { get; set; }
    public DateOnly releaseDate { get; set; }
}
