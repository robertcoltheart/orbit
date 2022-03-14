using System;
using System.Linq.Expressions;

namespace Orbit.Framework;

public static class ExpressionExtensions
{
    public static string GetPropertyName<T, TValue>(this Expression<Func<T, TValue>> expression)
    {
        if (expression.Body is not MemberExpression memberExpression)
        {
            throw new ArgumentException("Expression is not a property", nameof(expression));
        }

        return memberExpression.Member.Name;
    }
}
