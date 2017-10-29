using System;
using System.Reactive.Disposables;
using NSubstitute;
using Xunit;

namespace Orbit.Framework
{
    public class DisposableExtensionsTests
    {
        [Fact]
        public void AddsToCompositeDisposable()
        {
            var disposable = Substitute.For<IDisposable>();

            var compositeDisposable = new CompositeDisposable();
            disposable.DisposeWith(compositeDisposable);

            Assert.Contains(disposable, compositeDisposable);
        }
    }
}
