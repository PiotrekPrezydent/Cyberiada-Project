using Core.Enums;

namespace Core
{
    public static class GameStateSystem
    {
        public static GameState CurrentState { get => _currentState; }
        static GameState _currentState;

        public static void ChangeGameState(GameState state)
        {

        }
    }
}
