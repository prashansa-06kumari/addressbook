using AddressBookApp.Models;

namespace AddressBookApp.Services;

public class AddressBookMain
{
    private List<AddressBook> books = new();

    public void AddAddressBook(AddressBook book)
    {
        books.Add(book);
    }

    public int GetTotalContactCount()
    {
        return books.Sum(b => b.Contacts.Count);
    }

    public IEnumerable<Contact> SearchByCity(string city)
    {
        return books.SelectMany(b => b.SearchByCity(city));
    }

    public IEnumerable<Contact> SearchByState(string state)
    {
        return books.SelectMany(b => b.SearchByState(state));
    }
}
