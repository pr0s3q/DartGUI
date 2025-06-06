using DartGUI.Helpers.Enums;

namespace DartGUI.Helpers;

internal class Statistics
{
    #region Local Variables

    private int _totalPoints;
    private int _totalDartsThrown;
    private readonly int[] _dartboardTallyCounter = new int[63];
    private int _100plus;
    private int _140plus;
    private int _180;

    #endregion

    #region Operations

    internal void AddPoints(int points, int dartThrown, Dartboard[] dartboardShots, bool checkout)
    {
        _totalPoints += points;
        _totalDartsThrown += dartThrown;
        AveragePoints = (double)_totalPoints / _totalDartsThrown * 3;
        foreach (var dartboardShot in dartboardShots)
        {
            if (dartboardShot == Dartboard.None)
                continue;

            _dartboardTallyCounter[(int)dartboardShot]++;
        }

        if (checkout && points > HighestCheckout)
            HighestCheckout = points;

        switch (points)
        {
            case 180:
                _180++;
                break;
            case >= 140:
                _140plus++;
                break;
            case >= 100:
                _100plus++;
                break;
        }
    }

    #endregion

    #region Properties

    internal List<Dartboard> MostCommonField
    {
        get
        {
            var biggestValue = _dartboardTallyCounter.Max();
            if (biggestValue == 0)
                return new List<Dartboard>();

            return _dartboardTallyCounter
                .Select((value, index) => new { value, index })
                .Where(x => x.value == biggestValue)
                .Select(x => (Dartboard)x.index)
                .ToList();
        }
    }

    internal double AveragePoints { get; private set; }
    internal int HighestCheckout { get; private set; }
    internal int HundredEightyTallyCounter => _180;
    internal int HundredFortyPlusTallyCounter => _140plus;
    internal int HundredPlusTallyCounter => _100plus;

    #endregion
}
