// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

// =+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
//
// INotifyCompletion.cs
//

//
// Interfaces used to represent instances that notify listeners of their completion via continuations.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

using System;
using System.Security;

namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// Represents an operation that will schedule continuations when the operation completes.
    /// </summary>
    public interface INotifyCompletion
    {
        /// <summary>Schedules the continuation action to be invoked when the instance completes.</summary>
        /// <param name="continuation">The action to invoke when the operation completes.</param>
        /// <exception cref="System.ArgumentNullException">The <paramref name="continuation"/> argument is null (Nothing in Visual Basic).</exception>
        void OnCompleted(Action continuation);
    }

    /// <summary>
    /// Represents an awaiter used to schedule continuations when an await operation completes.
    /// </summary>
    public interface ICriticalNotifyCompletion : INotifyCompletion
    {
        /// <summary>Schedules the continuation action to be invoked when the instance completes.</summary>
        /// <param name="continuation">The action to invoke when the operation completes.</param>
        /// <exception cref="System.ArgumentNullException">The <paramref name="continuation"/> argument is null (Nothing in Visual Basic).</exception>
        /// <remarks>Unlike OnCompleted, UnsafeOnCompleted need not propagate ExecutionContext information.</remarks>
        [SecurityCritical]
        void UnsafeOnCompleted(Action continuation);
    }
}
