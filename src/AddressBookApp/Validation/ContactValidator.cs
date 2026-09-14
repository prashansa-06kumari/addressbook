using System.Text.RegularExpressions;
using AddressBookApp.Exceptions;
using AddressBookApp.Models;

namespace AddressBookApp.Validation;

public static class ContactValidator
{
    public static bool IsValidName(string name)
    {
        return Regex.IsMatch(name, @"^[A-Z][a-zA-Z]{2,}$");
    }

    public static bool IsValidAddressPart(string value)
    {
        return Regex.IsMatch(value, @"^.{4,}$");
    }

    public static bool IsValidZip(string zip)
    {
        return Regex.IsMatch(zip, @"^[0-9]{6}$");
    }

    public static bool IsValidPhone(string phone)
    {
        return Regex.IsMatch(phone, @"^[0-9]{10}$");
    }

    public static bool IsValidEmail(string email)
    {
        return Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
    }

    public static void Validate(Contact c)
    {
        if (!IsValidName(c.FirstName))
        {
            throw new InvalidContactException("First name must start with a capital letter and be at least 3 characters.");
        }

        if (!IsValidName(c.LastName))
        {
            throw new InvalidContactException("Last name must start with a capital letter and be at least 3 characters.");
        }

        if (!IsValidAddressPart(c.Address))
        {
            throw new InvalidContactException("Address must be at least 4 characters.");
        }

        if (!IsValidAddressPart(c.City))
        {
            throw new InvalidContactException("City must be at least 4 characters.");
        }

        if (!IsValidAddressPart(c.State))
        {
            throw new InvalidContactException("State must be at least 4 characters.");
        }

        if (!IsValidZip(c.Zip))
        {
            throw new InvalidContactException("Zip must contain exactly 6 digits.");
        }

        if (!IsValidPhone(c.PhoneNumber))
        {
            throw new InvalidContactException("Phone number must contain exactly 10 digits with no symbols.");
        }

        if (!IsValidEmail(c.Email))
        {
            throw new InvalidContactException("Email format is invalid.");
        }
    }
}
