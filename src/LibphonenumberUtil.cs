using Microsoft.Extensions.Logging;
using Soenneker.Utils.AsyncSingleton;
using Soenneker.Utils.Libphonenumber.Abstract;
using System.Threading;
using System.Threading.Tasks;
using PhoneNumbers;

namespace Soenneker.Utils.Libphonenumber;

/// <inheritdoc cref="ILibphonenumberUtil"/>
public sealed class LibphonenumberUtil : ILibphonenumberUtil
{
    private readonly AsyncSingleton<PhoneNumberUtil> _client;

    public LibphonenumberUtil(ILogger<LibphonenumberUtil> logger)
    {
        _client = new AsyncSingleton<PhoneNumberUtil>(() =>
        {
            logger.LogDebug("Instantiating libphonenumber (PhoneNumberUtil)...");

            return PhoneNumberUtil.GetInstance();
        });
    }

    public ValueTask<PhoneNumberUtil> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}