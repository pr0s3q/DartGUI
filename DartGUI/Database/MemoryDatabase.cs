using DartGUI.Games;

namespace DartGUI.Database;

internal static class MemoryDatabase
{
    private static GameBase? _game = null;

    internal static bool GetLastGameIfExist(out GameBase? game)
    {
        game = null;
        if (_game is null)
            return false;

        game = _game;
        return true;
    }

    internal static void SaveLastGame(GameBase game) => _game = game;
}
