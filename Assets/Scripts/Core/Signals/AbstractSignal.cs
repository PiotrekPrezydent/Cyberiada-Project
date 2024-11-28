using System;

namespace Core.Signals
{
    //No parameter signal
    public abstract class AbstractSignal<T> where T : AbstractSignal<T>
    {
        protected static event Action _onSignal;

        public static void Notify() => _onSignal.Invoke();
    }
    //One parameter Signal
    public abstract class AbstractSignal<T1,T2> where T1 : AbstractSignal<T1>
    {
        protected static event Action<T1> _onSignal;

        public static void Notify(T1 args) => _onSignal.Invoke(args);
    }
}
