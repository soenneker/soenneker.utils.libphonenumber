using PhoneNumbers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Utils.Libphonenumber.Abstract;

/// <summary>
/// An async thread-safe singleton for a libphonenumber-csharp instance
/// </summary>
public interface ILibphonenumberUtil : IAsyncDisposable, IDisposable
{
    ValueTask<PhoneNumberUtil> Get(CancellationToken cancellationToken = default);
}