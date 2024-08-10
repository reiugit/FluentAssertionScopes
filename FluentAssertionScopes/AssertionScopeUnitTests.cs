using FluentAssertions;
using FluentAssertions.Execution;

namespace FluentAssertionScopes;

public class AssertionScopeUnitTests
{
    [Fact]
    public void MultipleFails_ShouldBe_ListedAtOnce()
    {
        const string result = "result_string";

        // scope for multiple assertions
        // so not only the first failure
        // will be shown, but all of them.
        using (new AssertionScope())
        {
            result.Should().Contain("-");
            result.Should().NotContain("_");
            result.Should().Match("Result*");
            result.Should().NotEndWith("string");
            // These multiple assertions will throw together,
            // at the moment the assertion-scope is disposed.
        }
    }
}
