﻿using System;
using System.Reactive.Disposables;

namespace Orbit.Framework;

public static class DisposableExtensions
{
    public static void DisposeWith(this IDisposable disposable, CompositeDisposable container)
    {
        container.Add(disposable);
    }
}
