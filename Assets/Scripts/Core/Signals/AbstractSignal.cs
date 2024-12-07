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
    public abstract class AbstractSignal<T,T1> where T : AbstractSignal<T,T1>
    {
        protected static event Action<T1> _onSignal;

        public static void Notify(T1 args) => _onSignal.Invoke(args);
    }

    //Two parameter Signal
    public abstract class AbstractSignal<T, T1,T2> where T : AbstractSignal<T,T1,T2>
    {
        protected static event Action<T1,T2> _onSignal;

        public static void Notify(T1 args,T2 args2) => _onSignal.Invoke(args,args2);
    }
}
