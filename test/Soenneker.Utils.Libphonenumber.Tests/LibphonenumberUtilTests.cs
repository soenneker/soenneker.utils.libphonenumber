using Soenneker.Utils.Libphonenumber.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Utils.Libphonenumber.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class LibphonenumberUtilTests : HostedUnitTest
{
    private readonly ILibphonenumberUtil _util;

    public LibphonenumberUtilTests(Host host) : base(host)
    {
        _util = Resolve<ILibphonenumberUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
