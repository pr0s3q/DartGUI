using DartGUI.Helpers.Enums;

namespace DartGUI.Helpers;

internal class Statistics
{
    #region Local Variables

    private int _totalPoints;
    private int _totalDartsThrown;
    private int _100Plus;
    private int _140Plus;
    private int _180;
    private readonly int[] _dartboardTallyCounter = new int[63];
    private readonly int[] _doubleEndTallyCounter = new int[21];

    #endregion

    #region Operations

    internal void AddPoints(int points, int dartsThrown, Dartboard[] dartboardShots, bool checkout)
    {
        _totalPoints += points;
        _totalDartsThrown += dartsThrown;
        AveragePoints = (double)_totalPoints / _totalDartsThrown * 3;
        foreach (var dartboardShot in dartboardShots)
        {
            if (dartboardShot == Dartboard.None)
                continue;

            _dartboardTallyCounter[(int)dartboardShot]++;
        }

        if (checkout && points > HighestCheckout)
            HighestCheckout = points;

        if (checkout)
        {
            // Determine the last dart thrown in the leg
            // Each double is represented by its score divided by 2 (e.g., D20 → 40 / 2 = 20)
            // dartboardShots contains the actual dart scores (e.g., 40, 50 for D20 or D25)
            // If the last shot was D25 (bullseye, value 50), increment the final index (20)
            // Otherwise, map the double value to index [0–19] by subtracting 1
            var lastShot = (int)dartboardShots[dartsThrown - 1];
            if (lastShot == 41)
                _doubleEndTallyCounter[20]++;  // Special case for bullseye (D25)
            else
                _doubleEndTallyCounter[lastShot - 21]++;  // Increment count for the corresponding double (D1–D20)
        }

        switch (points)
        {
            case 180:
                _180++;
                break;
            case >= 140:
                _140Plus++;
                break;
            case >= 100:
                _100Plus++;
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
                return [];

            return _dartboardTallyCounter
                .Select((value, index) => new { value, index })
                .Where(x => x.value == biggestValue)
                .Select(x => (Dartboard)x.index)
                .Where(x => x != Dartboard.None)
                .ToList();
        }
    }

    internal List<Dartboard> MostCommonDoubleEnd
    {
        get
        {
            var biggestValue = _doubleEndTallyCounter.Max();
            if (biggestValue == 0)
                return [];

            return _doubleEndTallyCounter
                .Select((value, index) => new { value, index })
                .Where(x => x.value == biggestValue)
                .Select(x =>
                {
                    if (x.index == 20)
                        return Dartboard.D25;

                    return (Dartboard)(x.index + 21);
                })
                .ToList();
        }
    }

    internal double AveragePoints { get; private set; }
    internal int HighestCheckout { get; private set; }
    internal int HundredEightyTallyCounter => _180;
    internal int HundredFortyPlusTallyCounter => _140Plus;
    internal int HundredPlusTallyCounter => _100Plus;

    #endregion
}
