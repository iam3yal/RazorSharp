namespace RazorSharp.Dom.Input;

using System.ComponentModel;

public static class AutoComplete
{
    public static AutoCompleteAddress Address { get; } = new ();

    public static AutoCompleteAuth Authentication { get; } = new ();

    public static AutoCompleteValue Off { get; } = new ("off");

    public static AutoCompleteValue On { get; } = new ("on");

    public static AutoCompletePayment Payment { get; } = new ();

    public static AutoCompletePerson Person { get; } = new ();

    public static AutoCompletePhone Phone { get; } = new ();

    public static AutoCompleteWeb Web { get; } = new ();
}

[EditorBrowsable(EditorBrowsableState.Never)]
public sealed class AutoCompleteAddress
{
    public AutoCompleteValue AddressLevel1 { get; } = new ("address-level1");

    public AutoCompleteValue AddressLevel2 { get; } = new ("address-level2");

    public AutoCompleteValue AddressLevel3 { get; } = new ("address-level3");

    public AutoCompleteValue AddressLevel4 { get; } = new ("address-level4");

    public AutoCompleteValue AddressLine1 { get; } = new ("address-line1");

    public AutoCompleteValue AddressLine2 { get; } = new ("address-line2");

    public AutoCompleteValue AddressLine3 { get; } = new ("address-line3");

    public AutoCompleteValue Country { get; } = new ("country");

    public AutoCompleteValue CountryName { get; } = new ("country-name");

    public AutoCompleteValue PostalCode { get; } = new ("postal-code");

    public AutoCompleteValue StreetAddress { get; } = new ("street-address");
}

[EditorBrowsable(EditorBrowsableState.Never)]
public sealed class AutoCompleteAuth
{
    public AutoCompleteValue CurrentPassword { get; } = new ("current-password");

    public AutoCompleteValue NewPassword { get; } = new ("new-password");

    public AutoCompleteValue UserIdentityCode { get; } = new ("one-time-code");

    public AutoCompleteValue Username { get; } = new ("Username");
}

[EditorBrowsable(EditorBrowsableState.Never)]
public sealed class AutoCompleteBirthday
{
    public AutoCompleteValue Day { get; } = new ("bday-day");

    public AutoCompleteValue FullDate { get; } = new ("bday");

    public AutoCompleteValue Month { get; } = new ("bday-month");

    public AutoCompleteValue Year { get; } = new ("bday-year");
}

[EditorBrowsable(EditorBrowsableState.Never)]
public sealed class AutoCompleteCreditCard
{
    public AutoCompleteValue ExpirationDate { get; } = new ("cc-exp");

    public AutoCompleteValue ExpirationMonth { get; } = new ("cc-exp-month");

    public AutoCompleteValue ExpirationYear { get; } = new ("cc-exp-year");

    public AutoCompleteValue FirstName { get; } = new ("cc-given-name");

    public AutoCompleteValue FullName { get; } = new ("cc-name");

    public AutoCompleteValue LastName { get; } = new ("cc-family-name");

    public AutoCompleteValue MiddleName { get; } = new ("cc-additional-name");

    public AutoCompleteValue Number { get; } = new ("cc-number");

    public AutoCompleteValue SecurityCode { get; } = new ("cc-csc");

    public AutoCompleteValue Type { get; } = new ("cc-type");
}

[EditorBrowsable(EditorBrowsableState.Never)]
public sealed class AutoCompletePayment
{
    private AutoCompleteCreditCard? _creditCard;

    public AutoCompleteCreditCard CreditCard
        => _creditCard ??= new ();

    public AutoCompleteValue TransactionAmount { get; } = new ("transaction-amount");

    public AutoCompleteValue TransactionCurrency { get; } = new ("transaction-currency");
}

[EditorBrowsable(EditorBrowsableState.Never)]
public sealed class AutoCompletePerson
{
    private AutoCompleteBirthday? _birthday;

    public AutoCompleteBirthday Birthday
        => _birthday ??= new ();

    public AutoCompleteValue FirstName { get; } = new ("given-name");

    public AutoCompleteValue FullName { get; } = new ("name");

    public AutoCompleteValue HonorificPrefix { get; } = new ("honorific-prefix");

    public AutoCompleteValue HonorificSuffix { get; } = new ("honorific-suffix");

    public AutoCompleteValue Language { get; } = new ("language");

    public AutoCompleteValue LastName { get; } = new ("family-name");

    public AutoCompleteValue MiddleName { get; } = new ("additional-name");

    public AutoCompleteValue Nickname { get; } = new ("nickname");

    public AutoCompleteValue Organization { get; } = new ("organization");

    public AutoCompleteValue OrganizationTitle { get; } = new ("organization-title");

    public AutoCompleteValue Photo { get; } = new ("photo");
}

[EditorBrowsable(EditorBrowsableState.Never)]
public sealed class AutoCompletePhone
{
    public AutoCompleteValue AreaCode { get; } = new ("tel-area-code");

    public AutoCompleteValue CountryCode { get; } = new ("tel-country-code");

    public AutoCompleteValue Extension { get; } = new ("tel-extension");

    public AutoCompleteValue FullNumber { get; } = new ("tel");

    public AutoCompleteValue LocalNumber { get; } = new ("tel-local");

    public AutoCompleteValue NationalNumber { get; } = new ("tel-national");
}

[EditorBrowsable(EditorBrowsableState.Never)]
public sealed class AutoCompleteWeb
{
    public AutoCompleteValue Email { get; } = new ("email");

    public AutoCompleteValue InstantMessaging { get; } = new ("impp");

    public AutoCompleteValue Url { get; } = new ("url");
}