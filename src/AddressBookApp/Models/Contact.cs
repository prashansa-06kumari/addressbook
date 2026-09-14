namespace AddressBookApp.Models;

public class Contact
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public Contact(string firstName, string lastName, string address, string city, string state, string zip, string phoneNumber, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        City = city;
        State = state;
        Zip = zip;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName} | {Address}, {City}, {State} {Zip} | {PhoneNumber} | {Email}";
    }
}
