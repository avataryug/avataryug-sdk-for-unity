using System;
using Com.Avataryug.Client;

namespace Com.Avataryug.Handler
{
    /// <summary>
    /// The abstracted base class is designed to simplify API calling by providing a reusable foundation that can be utilized in various programming contexts.
    /// </summary>
    public abstract class Base
    {
        public abstract void CallApi(Action<object> result, Action<ApiException> error);
    }
}
