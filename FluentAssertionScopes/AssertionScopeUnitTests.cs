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
        // (these multiple assertions will throw
        //  together, only when the scope is disposed)
        using (new AssertionScope())
        {
            result.Should().Contain("-");
            result.Should().NotContain("_");
            result.Should().Match("Result*");
            result.Should().NotEndWith("string");
        }
    }
}
