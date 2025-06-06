using DartGUI.Helpers.Enums;

namespace DartGUI.Helpers;

internal class Statistics
{
    #region Local Variables

    private int _totalPoints;
    private int _totalDartsThrown;
    private readonly int[] _dartboardTallyCounter = new int[63];

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
    }

    #endregion

    #region Properties

    internal double AveragePoints { get; private set; }

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

    internal int HighestCheckout { get; private set; }

    #endregion
}
