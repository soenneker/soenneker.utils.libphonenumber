[![](https://img.shields.io/nuget/v/soenneker.utils.libphonenumber.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.utils.libphonenumber/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.libphonenumber/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.utils.libphonenumber/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.utils.libphonenumber.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.utils.libphonenumber/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.libphonenumber/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.utils.libphonenumber/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Utils.Libphonenumber
Lazily provides libphonenumber-csharp's `PhoneNumberUtil` for parsing, validating, and formatting international phone numbers.

## Installation

```bash
dotnet add package Soenneker.Utils.Libphonenumber
```

## Quick start

```csharp
using Soenneker.Utils.Libphonenumber.Registrars;

services.AddLibphonenumberUtilAsSingleton();
```

Then inject `ILibphonenumberUtil` wherever you need it.

## Parse, validate, and format

```csharp
using PhoneNumbers;

PhoneNumberUtil phoneNumbers = await libphonenumberUtil.Get(cancellationToken);

try
{
    PhoneNumber number = phoneNumbers.Parse("(212) 555-0100", "US");

    if (phoneNumbers.IsValidNumber(number))
    {
        string e164 = phoneNumbers.Format(number, PhoneNumberFormat.E164);
        // +12125550100
    }
}
catch (NumberParseException)
{
    // The input could not be interpreted as a phone number.
}
```

Pass an ISO 3166-1 alpha-2 region such as `"US"` when parsing a national number. For an input
already beginning with `+` and a country calling code, the region can be `null`. Parsing only
interprets the text; call `IsPossibleNumber` or `IsValidNumber` when validity matters.

`Get` lazily returns the shared `PhoneNumberUtil` supplied by libphonenumber-csharp. Cache the
returned reference within an operation if you need it repeatedly. The cancellation token applies
while obtaining the lazy value; it does not affect later synchronous parsing or formatting calls.

The scoped registrar is available when the wrapper must follow a scope, but the underlying
libphonenumber instance remains shared. Let dependency injection dispose the wrapper; callers do
not own the returned `PhoneNumberUtil`.
