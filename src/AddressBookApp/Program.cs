using AddressBookApp.Exceptions;
using AddressBookApp.Models;
using AddressBookApp.Services;
using AddressBookApp.Validation;

var addressBook = new AddressBook();
bool running = true;

while (running)
{
    Console.WriteLine("\nAddress Book Menu");
    Console.WriteLine("1. Add Contact");
    Console.WriteLine("2. Edit Contact");
    Console.WriteLine("3. Delete Contact");
    Console.WriteLine("4. Show All Contacts");
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
