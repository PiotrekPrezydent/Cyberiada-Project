using Core.Enums;
using Core.Signals;

namespace Core
{
    public class GameStateChanged : AbstractSignal<GameStateChanged,GameState,GameState> { };
}
