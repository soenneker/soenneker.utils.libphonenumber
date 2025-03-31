using Microsoft.Extensions.Logging;
using Soenneker.Utils.AsyncSingleton;
using Soenneker.Utils.Libphonenumber.Abstract;
using System;
using System.Threading;
using System.Threading.Tasks;
using PhoneNumbers;

namespace Soenneker.Utils.Libphonenumber;

/// <inheritdoc cref="ILibphonenumberUtil"/>
public class LibphonenumberUtil : ILibphonenumberUtil
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
        GC.SuppressFinalize(this);

        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);

        return _client.DisposeAsync();
    }
}