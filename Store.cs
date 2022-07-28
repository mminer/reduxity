using System;

namespace Reduxity
{
    /// <summary>
    /// Container to hold game state. Inspired by Redux.
    /// https://redux.js.org/api/store
    /// </summary>
    public sealed class Store<TState, TAction> where TState : struct
    {
        public event Action changed;

        public TState state { get; private set; }

        readonly Func<TState, TAction, TState> reducer;

        public Store(Func<TState, TAction, TState> reducer, TState? preloadedState = null)
        {
            this.reducer = reducer;
            this.state = preloadedState.GetValueOrDefault();
        }

        public void Dispatch(TAction action)
        {
            state = reducer(state, action);
            changed?.Invoke();
        }
    }
}
