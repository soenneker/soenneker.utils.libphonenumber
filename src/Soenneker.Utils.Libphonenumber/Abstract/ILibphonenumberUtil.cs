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
    /// <summary>
    /// Returns the lazily initialized libphonenumber parser instance.
    /// </summary>
    /// <param name="cancellationToken">Signals that the operation should stop.</param>
    /// <returns>The shared phone-number utility.</returns>
    ValueTask<PhoneNumberUtil> Get(CancellationToken cancellationToken = default);
}