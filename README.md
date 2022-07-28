# Reduxity

Redux + Unity. Provides a bare-bones state management container inspired by
[Redux](https://redux.js.org).

Redux is heavily used in web development. Is this pattern a good fit for game
state? Probably not in most cases, but the experiment is ongoing.


## Using

Define a state object:

```csharp
struct GameState
{
    public Vector3Int playerPosition;
}
```

Add actions to affect the state:

```csharp
interface IGameAction {}

struct MoveAction : IGameAction
{
    public Vector3Int direction;
}
```

Create a reducer to update the state when an action is dispatched:

```csharp
static GameState Reducer(GameState state, IGameAction action)
{
    switch (action)
    {
        case MoveAction moveAction:
            state.playerPosition += moveAction.direction;
            return state;

        default:
            return state;
    }
}
```

Tie it all together with a store:

```csharp
Store<GameState, IGameAction> store = new(Reducer);
```

Dispatch changes:

```csharp
store.Dispatch(new MoveAction { direction = Vector3Int.up });
```

Subscribe to changes:

```csharp
store.changed += _ => Debug.Log($"New position: {store.state.playerPosition}");
```
