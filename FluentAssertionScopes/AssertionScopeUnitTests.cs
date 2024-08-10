using FluentAssertions;
using FluentAssertions.Execution;

namespace FluentAssertionScopes;

public class AssertionScopeUnitTests
{
    [Fact]
    public void MultipleFails_ShouldBe_ListedAtOnce()
    {
        var result = new Result(0, "Custom error");

        // starting a scope for multiple assertions, so that
        // not only the first failure will be shown, but all of them.

        using (new AssertionScope())
        {
            result.Value.Should().NotBe(0);
            result.Error.Should().BeNullOrEmpty();
            // Both assertions will throw together, just at
            // the moment the assertion-scope is disposed.
        }
    }
}

internal record Result(int Value, string Error);
