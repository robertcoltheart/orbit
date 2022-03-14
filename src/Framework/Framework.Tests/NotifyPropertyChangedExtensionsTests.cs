using System.Reactive;
using System.Reactive.Concurrency;
using Microsoft.Reactive.Testing;
using Prism.Mvvm;
using Xunit;

namespace Orbit.Framework.Tests;

public class NotifyPropertyChangedExtensionsTests
{
    [Fact]
    public void CanObservePropertyChanged()
    {
        var scheduler = new TestScheduler();
        var observer = scheduler.CreateObserver<string>();

        var testClass = new TestClass();

        testClass.ToObservable()
            .Subscribe(observer);

        scheduler.Schedule(() => testClass.Name = "value");
        scheduler.AdvanceBy(1);

        Assert.Equal(1, observer.Messages.Count);
    }

    [Fact]
    public void CanObservePropertyChangedExpression()
    {
        var scheduler = new TestScheduler();
        var observer = scheduler.CreateObserver<Unit>();

        var testClass = new TestClass();

        testClass.ToObservable(x => x.Name)
            .Subscribe(observer);

        scheduler.Schedule(() => testClass.Name = "value");
        scheduler.AdvanceBy(1);

        Assert.Equal(1, observer.Messages.Count);
    }

    private class TestClass : BindableBase
    {
        private string? name;

        public string? Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
    }
}
