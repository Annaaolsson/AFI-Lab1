namespace AFI_Lab1.Models;

public class Ad
{
    public int Id { get; set; }

    public string Title { get; set; } = "";
    public string Content { get; set; } = "";
    public decimal ItemPrice { get; set; }
    public decimal AdPrice { get; set; }

    public int AdvertiserId { get; set; }
    public Advertiser? Advertiser { get; set; }
}