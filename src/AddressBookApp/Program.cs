using AddressBookApp.Exceptions;
using AddressBookApp.Models;
using AddressBookApp.Services;
using AddressBookApp.Validation;

var addressBookMain = new AddressBookMain();
var addressBook = new AddressBook();
addressBookMain.AddAddressBook(addressBook);
bool running = true;

while (running)
{
    Console.WriteLine("\nAddress Book Menu");
    Console.WriteLine("1. Add Contact");
    Console.WriteLine("2. Edit Contact");
    Console.WriteLine("3. Delete Contact");
    Console.WriteLine("4. Show All Contacts");
    Console.WriteLine("5. Total Contact Count");
    Console.WriteLine("6. Sort Contacts");
    Console.WriteLine("7. Search by City");
    Console.WriteLine("8. Search by State");
    Console.WriteLine("9. View by City/State");
    Console.WriteLine("10. Count by City/State");
    Console.WriteLine("0. Exit");
    Console.Write("Enter your choice: ");
    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            AddNewContact();
            break;
        case "2":
            EditExistingContact();
            break;
        case "3":
            DeleteExistingContact();
            break;
        case "4":
            Console.WriteLine("\n--- All Contacts ---");
            addressBook.PrintAll();
            break;
        case "5":
            Console.WriteLine($"\nTotal contacts in all address books: {addressBookMain.GetTotalContactCount()}");
            break;
        case "6":
            addressBook.SortContacts();
            Console.WriteLine("\n--- Contacts sorted by name ---");
            addressBook.PrintAll();
            break;
        case "7":
            SearchByCity();
            break;
        case "8":
            SearchByState();
            break;
        case "9":
            addressBookMain.ViewByCityOrState();
            break;
        case "10":
            CountByCityOrState();
            break;
        case "0":
            running = false;
            Console.WriteLine("Exiting...");
            break;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}

void AddNewContact()
{
    try
    {
        Console.WriteLine("\n--- Add New Contact ---");
        Console.Write("First name: ");
        var firstName = Console.ReadLine() ?? "";
        Console.Write("Last name: ");
        var lastName = Console.ReadLine() ?? "";
        Console.Write("Address: ");
        var address = Console.ReadLine() ?? "";
        Console.Write("City: ");
        var city = Console.ReadLine() ?? "";
        Console.Write("State: ");
        var state = Console.ReadLine() ?? "";
        Console.Write("Zip: ");
        var zip = Console.ReadLine() ?? "";
        Console.Write("Phone number: ");
        var phoneNumber = Console.ReadLine() ?? "";
        Console.Write("Email: ");
        var email = Console.ReadLine() ?? "";

        var contact = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email);
        ContactValidator.Validate(contact);
        addressBook.AddContact(contact);
        Console.WriteLine("Contact added successfully.");
    }
    catch (InvalidContactException ex)
    {
        Console.WriteLine($"Validation error: {ex.Message}");
        Console.WriteLine("Contact was not added. Please try again.");
    }
}

void EditExistingContact()
{
    Console.WriteLine("\n--- Edit Contact ---");
    Console.Write("Enter first name to edit: ");
    var firstName = Console.ReadLine() ?? "";
    Console.Write("Enter last name to edit: ");
    var lastName = Console.ReadLine() ?? "";
    addressBook.EditContact(firstName, lastName);
}

void DeleteExistingContact()
{
    Console.WriteLine("\n--- Delete Contact ---");
    Console.Write("Enter first name to delete: ");
    var firstName = Console.ReadLine() ?? "";
    Console.Write("Enter last name to delete: ");
    var lastName = Console.ReadLine() ?? "";
    addressBook.DeleteContact(firstName, lastName);
}

void SearchByCity()
{
    Console.WriteLine("\n--- Search by City ---");
    Console.Write("Enter city to search: ");
    var city = Console.ReadLine() ?? "";
    var matches = addressBookMain.SearchByCity(city).ToList();
    if (matches.Count == 0)
    {
        Console.WriteLine("No contacts found.");
        return;
    }
    Console.WriteLine($"\nFound {matches.Count} contact(s):");
    foreach (var contact in matches)
    {
        Console.WriteLine(contact.ToString());
    }
}

void SearchByState()
{
    Console.WriteLine("\n--- Search by State ---");
    Console.Write("Enter state to search: ");
    var state = Console.ReadLine() ?? "";
    var matches = addressBookMain.SearchByState(state).ToList();
    if (matches.Count == 0)
    {
        Console.WriteLine("No contacts found.");
        return;
    }
    Console.WriteLine($"\nFound {matches.Count} contact(s):");
    foreach (var contact in matches)
    {
        Console.WriteLine(contact.ToString());
    }
}

void CountByCityOrState()
{
    Console.WriteLine("\n--- Count by City/State ---");
    Console.WriteLine("1. Count by City");
    Console.WriteLine("2. Count by State");
    Console.Write("Enter your choice: ");
    var subChoice = Console.ReadLine();

    switch (subChoice)
    {
        case "1":
            var cityCounts = addressBookMain.GetCountByCity();
            if (cityCounts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
                return;
            }
            Console.WriteLine("\nContact count by city:");
            foreach (var kvp in cityCounts)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            break;
        case "2":
            var stateCounts = addressBookMain.GetCountByState();
            if (stateCounts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
                return;
            }
            Console.WriteLine("\nContact count by state:");
            foreach (var kvp in stateCounts)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            break;
        default:
            Console.WriteLine("Invalid choice.");
            break;
    }
}
