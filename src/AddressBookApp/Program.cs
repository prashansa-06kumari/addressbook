using AddressBookApp.Exceptions;
using AddressBookApp.Models;
using AddressBookApp.Validation;

Console.WriteLine("=== UC2: Contact Validation Demo ===\n");

Console.WriteLine("--- Test 1: Valid Contact ---");
try
{
    var validContact = new Contact("John", "Doe", "12 MG Road", "Pune", "Maharashtra", "411001", "9876543210", "john.doe@mail.com");
    ContactValidator.Validate(validContact);
    Console.WriteLine($"SUCCESS: Contact accepted -> {validContact}");
}
catch (InvalidContactException ex)
{
    Console.WriteLine($"FAILURE: {ex.Message}");
}

Console.WriteLine("\n--- Test 2: Invalid First Name (lowercase start) ---");
try
{
    var badFirstName = new Contact("john", "Doe", "12 MG Road", "Pune", "Maharashtra", "411001", "9876543210", "john.doe@mail.com");
    ContactValidator.Validate(badFirstName);
    Console.WriteLine("FAILURE: Should have thrown InvalidContactException");
}
catch (InvalidContactException ex)
{
    Console.WriteLine($"SUCCESS: Caught exception -> {ex.Message}");
}

Console.WriteLine("\n--- Test 3: Invalid First Name (too short) ---");
try
{
    var shortFirstName = new Contact("Jo", "Doe", "12 MG Road", "Pune", "Maharashtra", "411001", "9876543210", "john.doe@mail.com");
    ContactValidator.Validate(shortFirstName);
    Console.WriteLine("FAILURE: Should have thrown InvalidContactException");
}
catch (InvalidContactException ex)
{
    Console.WriteLine($"SUCCESS: Caught exception -> {ex.Message}");
}

Console.WriteLine("\n--- Test 4: Invalid Last Name ---");
try
{
    var badLastName = new Contact("John", "doe", "12 MG Road", "Pune", "Maharashtra", "411001", "9876543210", "john.doe@mail.com");
    ContactValidator.Validate(badLastName);
    Console.WriteLine("FAILURE: Should have thrown InvalidContactException");
}
catch (InvalidContactException ex)
{
    Console.WriteLine($"SUCCESS: Caught exception -> {ex.Message}");
}

Console.WriteLine("\n--- Test 5: Invalid Address (too short) ---");
try
{
    var badAddress = new Contact("John", "Doe", "12", "Pune", "Maharashtra", "411001", "9876543210", "john.doe@mail.com");
    ContactValidator.Validate(badAddress);
    Console.WriteLine("FAILURE: Should have thrown InvalidContactException");
}
catch (InvalidContactException ex)
{
    Console.WriteLine($"SUCCESS: Caught exception -> {ex.Message}");
}

Console.WriteLine("\n--- Test 6: Invalid City (too short) ---");
try
{
    var badCity = new Contact("John", "Doe", "12 MG Road", "Pun", "Maharashtra", "411001", "9876543210", "john.doe@mail.com");
    ContactValidator.Validate(badCity);
    Console.WriteLine("FAILURE: Should have thrown InvalidContactException");
}
catch (InvalidContactException ex)
{
    Console.WriteLine($"SUCCESS: Caught exception -> {ex.Message}");
}

Console.WriteLine("\n--- Test 7: Invalid State (too short) ---");
try
{
    var badState = new Contact("John", "Doe", "12 MG Road", "Pune", "Mah", "411001", "9876543210", "john.doe@mail.com");
    ContactValidator.Validate(badState);
    Console.WriteLine("FAILURE: Should have thrown InvalidContactException");
}
catch (InvalidContactException ex)
{
    Console.WriteLine($"SUCCESS: Caught exception -> {ex.Message}");
}

Console.WriteLine("\n--- Test 8: Invalid Zip (not 6 digits) ---");
try
{
    var badZip = new Contact("John", "Doe", "12 MG Road", "Pune", "Maharashtra", "41100", "9876543210", "john.doe@mail.com");
    ContactValidator.Validate(badZip);
    Console.WriteLine("FAILURE: Should have thrown InvalidContactException");
}
catch (InvalidContactException ex)
{
    Console.WriteLine($"SUCCESS: Caught exception -> {ex.Message}");
}

Console.WriteLine("\n--- Test 9: Invalid Phone (not 10 digits) ---");
try
{
    var badPhone = new Contact("John", "Doe", "12 MG Road", "Pune", "Maharashtra", "411001", "987654321", "john.doe@mail.com");
    ContactValidator.Validate(badPhone);
    Console.WriteLine("FAILURE: Should have thrown InvalidContactException");
}
catch (InvalidContactException ex)
{
    Console.WriteLine($"SUCCESS: Caught exception -> {ex.Message}");
}

Console.WriteLine("\n--- Test 10: Invalid Email ---");
try
{
    var badEmail = new Contact("John", "Doe", "12 MG Road", "Pune", "Maharashtra", "411001", "9876543210", "john.doe(at)mail.com");
    ContactValidator.Validate(badEmail);
    Console.WriteLine("FAILURE: Should have thrown InvalidContactException");
}
catch (InvalidContactException ex)
{
    Console.WriteLine($"SUCCESS: Caught exception -> {ex.Message}");
}

Console.WriteLine("\n=== All UC2 Tests Completed ===");
