using DartGUI.Games;

namespace DartGUI.Database;

internal static class MemoryDatabase
{
    private static Game? _game = null;

    internal static bool GetLastGameIfExist(out Game? game)
    {
        game = null;
        if (_game is null)
            return false;

        game = _game;
        return true;
    }

    internal static void SaveLastGame(Game game) => _game = game;
}
