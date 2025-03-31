using Soenneker.Utils.Libphonenumber.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Utils.Libphonenumber.Tests;

[Collection("Collection")]
public class LibphonenumberUtilTests : FixturedUnitTest
{
    private readonly ILibphonenumberUtil _util;

    public LibphonenumberUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<ILibphonenumberUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
