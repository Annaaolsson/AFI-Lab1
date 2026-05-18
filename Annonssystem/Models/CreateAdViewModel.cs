using System.ComponentModel.DataAnnotations;

namespace AFI_Lab1.Models;

public class CreateAdViewModel
{
    public int SubscriptionNumber { get; set; }

    [Required(ErrorMessage = "First name is required.")]
    public string FirstName { get; set; } = "";

    [Required(ErrorMessage = "Last name is required.")]
    public string LastName { get; set; } = "";

    [Required(ErrorMessage = "Phone number is required.")]
    public string PhoneNumber { get; set; } = "";

    [Required(ErrorMessage = "Address is required.")]
    public string DeliveryAddress { get; set; } = "";

    [Required(ErrorMessage = "Postal code is required.")]
    public string PostalCode { get; set; } = "";

    [Required(ErrorMessage = "City is required.")]
    public string City { get; set; } = "";

    [Required(ErrorMessage = "Ad title is required.")]
    public string Title { get; set; } = "";

    [Required(ErrorMessage = "Ad content is required.")]
    public string Content { get; set; } = "";

    [Range(1, double.MaxValue, ErrorMessage = "Item price must be greater than 0.")]
    public decimal ItemPrice { get; set; }

    public decimal AdPrice { get; set; } = 0;
}