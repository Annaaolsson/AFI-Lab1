namespace Annonssystem.Models;

public class Subscriber
{
    public int Id { get; set; }
    public int SubscriptionNumber { get; set; }
    public string PersonalNumber { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string DeliveryAddress { get; set; } = "";
    public string PostalCode { get; set; } = "";
    public string City { get; set; } = "";
}