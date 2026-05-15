namespace Prenumerantsystem.Models;

public class Prenumerant
{
    public int Id { get; set; }
    public int Prenumerationsnummer { get; set; }
    public string Personnummer { get; set; } = "";
    public string Fornamn { get; set; } = "";
    public string Efternamn { get; set; } = "";
    public string Utdelningsadress { get; set; } = "";
    public string Postnummer { get; set; } = "";
    public string Ort { get; set; } = "";
}