// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace System
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public delegate void EventHandler(Object sender, EventArgs e);

    public delegate void EventHandler<TEventArgs>(Object sender, TEventArgs e); // Removed TEventArgs constraint post-.NET 4
}
