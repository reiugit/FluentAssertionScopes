using FluentAssertions;
using FluentAssertions.Execution;

namespace FluentAssertionScopes;

public class AssertionScopeUnitTests
{
    [Fact]
    public void MultipleFails_ShouldBe_ListedAtOnce()
    {
        (int number, string error) = (0, "Custom error");

        // starting a scope for multiple assertions, so that
        // not only the first failure will be shown, but all of them.

        using (new AssertionScope())
        {
            number.Should().NotBe(0);
            error.Should().BeNullOrEmpty();
            // Both assertions will throw together, at the
            // moment this assertion-scope is disposed.
        }
    }
}
