namespace AFI_Lab1.Models;

public class Advertiser
{
    public int Id { get; set; }

    public string AdvertiserType { get; set; } = ""; // subscriber/company

    public int? SubscriptionNumber { get; set; }

    public string Name { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public string DeliveryAddress { get; set; } = "";
    public string PostalCode { get; set; } = "";
    public string City { get; set; } = "";

    public List<Ad> Ads { get; set; } = new();
}