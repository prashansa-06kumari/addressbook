using AddressBookApp.Models;

namespace AddressBookApp.Services;

public class AddressBook
{
    private List<Contact> contacts = new();

    public IReadOnlyList<Contact> Contacts => contacts;

    public void AddContact(Contact contact)
    {
        contacts.Add(contact);
    }

    public void PrintAll()
    {
        foreach (var contact in contacts)
        {
            Console.WriteLine(contact.ToString());
        }
    }
}
