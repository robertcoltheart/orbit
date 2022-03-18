using System.Linq.Expressions;
using Xunit;

namespace Orbit.Framework.Tests;

public class ExpressionExtensionsTests
{
    [Fact]
    public void GetsPropertyNameFromType()
    {
        Expression<Func<TestClass, int>> func = x => x.Name;

        Assert.Equal("Name", func.GetPropertyName());
    }

    private class TestClass
    {
        public int Name { get; set; }
    }
}
