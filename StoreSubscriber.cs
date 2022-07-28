using UnityEngine;

namespace Reduxity
{
    /// <summary>
    /// Base component that subscribes to a store's changes.
    /// </summary>
    public abstract class StoreSubscriber<TState, TAction> : MonoBehaviour where TState : struct
    {
        protected abstract Store<TState, TAction> store { get; }

        protected virtual void OnDisable()
        {
            store.changed -= OnStateChanged;
        }

        protected virtual void OnEnable()
        {
            store.changed += OnStateChanged;
        }

        protected abstract void OnStateChanged();
    }
}
