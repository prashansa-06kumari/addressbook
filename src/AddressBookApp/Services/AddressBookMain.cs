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

    public Dictionary<string, int> GetCountByCity()
    {
        return books.SelectMany(b => b.Contacts)
                    .GroupBy(c => c.City)
                    .ToDictionary(g => g.Key, g => g.Count());
    }

    public Dictionary<string, int> GetCountByState()
    {
        return books.SelectMany(b => b.Contacts)
                    .GroupBy(c => c.State)
                    .ToDictionary(g => g.Key, g => g.Count());
    }

    public void ViewByCityOrState()
    {
        var allContacts = books.SelectMany(b => b.Contacts).ToList();

        Console.WriteLine("\n--- By City ---");
        foreach (var group in allContacts.GroupBy(c => c.City))
        {
            Console.WriteLine($"{group.Key}:");
            foreach (var contact in group)
            {
                Console.WriteLine($" {contact.FirstName} {contact.LastName}");
            }
            Console.WriteLine();
        }

        Console.WriteLine("--- By State ---");
        foreach (var group in allContacts.GroupBy(c => c.State))
        {
            Console.WriteLine($"{group.Key}:");
            foreach (var contact in group)
            {
                Console.WriteLine($" {contact.FirstName} {contact.LastName}");
            }
            Console.WriteLine();
        }
    }
}
