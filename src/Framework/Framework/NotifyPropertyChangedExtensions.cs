using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reactive;
using System.Reactive.Linq;

namespace Orbit.Framework;

public static class NotifyPropertyChangedExtensions
{
    public static IObservable<string> ToObservable(this INotifyPropertyChanged source)
    {
        return Observable
            .FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(x => source.PropertyChanged += x, x => source.PropertyChanged -= x)
            .Where(x => x.EventArgs.PropertyName != null)
            .Select(x => x.EventArgs.PropertyName!);
    }

    public static IObservable<Unit> ToObservable<T, TValue>(this T source, Expression<Func<T, TValue>> expression)
        where T : INotifyPropertyChanged
    {
        return ToObservable(source)
            .Where(x => x == expression.GetPropertyName())
            .Select(x => Unit.Default);
    }
}
