using AddressBookApp.Exceptions;
using AddressBookApp.Models;
using AddressBookApp.Validation;

namespace AddressBookApp.Services;

public class AddressBook
{
    private List<Contact> contacts = new();

    public IReadOnlyList<Contact> Contacts => contacts;

    public void AddContact(Contact contact)
    {
        contacts.Add(contact);
    }

    public void SortContacts()
    {
        contacts.Sort((a, b) =>
        {
            int result = string.Compare(a.FirstName, b.FirstName, StringComparison.OrdinalIgnoreCase);
            if (result == 0)
            {
                result = string.Compare(a.LastName, b.LastName, StringComparison.OrdinalIgnoreCase);
            }
            return result;
        });
    }

    public IEnumerable<Contact> SearchByCity(string city)
    {
        return contacts.Where(c => c.City.Equals(city, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Contact> SearchByState(string state)
    {
        return contacts.Where(c => c.State.Equals(state, StringComparison.OrdinalIgnoreCase));
    }

    public void PrintAll()
    {
        foreach (var contact in contacts)
        {
            Console.WriteLine(contact.ToString());
        }
    }

    public void EditContact(string firstName, string lastName)
    {
        var contact = contacts.FirstOrDefault(
            c => c.FirstName == firstName && c.LastName == lastName
        );

        if (contact == null)
        {
            Console.WriteLine("Contact not found.");
            return;
        }

        Console.WriteLine($"Editing: {contact}");

        contact.FirstName = PromptAndValidateName("first name", contact.FirstName);
        contact.LastName = PromptAndValidateName("last name", contact.LastName);
        contact.Address = PromptAndValidateAddressPart("address", contact.Address);
        contact.City = PromptAndValidateAddressPart("city", contact.City);
        contact.State = PromptAndValidateAddressPart("state", contact.State);
        contact.Zip = PromptAndValidateZip(contact.Zip);
        contact.PhoneNumber = PromptAndValidatePhone(contact.PhoneNumber);
        contact.Email = PromptAndValidateEmail(contact.Email);

        Console.WriteLine("Contact updated.");
    }

    public void DeleteContact(string firstName, string lastName)
    {
        var contact = contacts.FirstOrDefault(
            c => c.FirstName == firstName && c.LastName == lastName
        );

        if (contact == null)
        {
            Console.WriteLine("Contact not found.");
            return;
        }

        contacts.Remove(contact);
        Console.WriteLine("Contact deleted successfully.");
    }

    private static string PromptAndValidateName(string label, string currentValue)
    {
        while (true)
        {
            Console.Write($"Enter new {label} (or press Enter to keep): ");
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                return currentValue;
            }
            try
            {
                if (!ContactValidator.IsValidName(input))
                {
                    throw new InvalidContactException($"{char.ToUpper(label[0]) + label.Substring(1)} must start with a capital letter and be at least 3 characters.");
                }
                return input;
            }
            catch (InvalidContactException ex)
            {
                Console.WriteLine($"Validation error: {ex.Message}");
            }
        }
    }

    private static string PromptAndValidateAddressPart(string label, string currentValue)
    {
        while (true)
        {
            Console.Write($"Enter new {label} (or press Enter to keep): ");
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                return currentValue;
            }
            try
            {
                if (!ContactValidator.IsValidAddressPart(input))
                {
                    throw new InvalidContactException($"{char.ToUpper(label[0]) + label.Substring(1)} must be at least 4 characters.");
                }
                return input;
            }
            catch (InvalidContactException ex)
            {
                Console.WriteLine($"Validation error: {ex.Message}");
            }
        }
    }

    private static string PromptAndValidateZip(string currentValue)
    {
        while (true)
        {
            Console.Write("Enter new zip (or press Enter to keep): ");
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                return currentValue;
            }
            try
            {
                if (!ContactValidator.IsValidZip(input))
                {
                    throw new InvalidContactException("Zip must contain exactly 6 digits.");
                }
                return input;
            }
            catch (InvalidContactException ex)
            {
                Console.WriteLine($"Validation error: {ex.Message}");
            }
        }
    }

    private static string PromptAndValidatePhone(string currentValue)
    {
        while (true)
        {
            Console.Write("Enter new phone number (or press Enter to keep): ");
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                return currentValue;
            }
            try
            {
                if (!ContactValidator.IsValidPhone(input))
                {
                    throw new InvalidContactException("Phone number must contain exactly 10 digits with no symbols.");
                }
                return input;
            }
            catch (InvalidContactException ex)
            {
                Console.WriteLine($"Validation error: {ex.Message}");
            }
        }
    }

    private static string PromptAndValidateEmail(string currentValue)
    {
        while (true)
        {
            Console.Write("Enter new email (or press Enter to keep): ");
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                return currentValue;
            }
            try
            {
                if (!ContactValidator.IsValidEmail(input))
                {
                    throw new InvalidContactException("Email format is invalid.");
                }
                return input;
            }
            catch (InvalidContactException ex)
            {
                Console.WriteLine($"Validation error: {ex.Message}");
            }
        }
    }
}
