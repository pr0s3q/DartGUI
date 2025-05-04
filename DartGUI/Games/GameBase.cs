using DartGUI.Helpers;
using DartGUI.Helpers.Enums;

namespace DartGUI.Games;

internal class GameBase
{
    #region Local Variables

    protected readonly List<Player> _players;

    protected readonly Dartboard[] _pointsEnumList = [Dartboard.None, Dartboard.None, Dartboard.None];

    protected readonly int[] _pointsList = [0, 0, 0];

    protected int _currentPlayer;

    protected int _startingPlayer;

    #endregion

    #region Constructor

    internal GameBase(List<string> playerNames)
    {
        _players = new List<Player>(playerNames.Count);

        foreach (var name in playerNames)
            _players.Add(new Player(name));
    }

    internal GameBase(GameBase gameBase)
    {
        _players = gameBase._players;
        _pointsEnumList = gameBase._pointsEnumList;
        _pointsList = gameBase._pointsList;
        _currentPlayer = gameBase._currentPlayer;
        _startingPlayer = gameBase._startingPlayer;
        ShotsLeft = gameBase.ShotsLeft;
    }

    #endregion

    #region Operations

    internal List<string> GetPlayerNames() => _players.Select(p => p.Name).ToList();

    internal int GetPlayerLegsWon(int playerIndex) => _players[playerIndex].LegsWon;

    #endregion

    #region Properties

    public int ShotsLeft { get; protected set; } = 3;

    #endregion
}
