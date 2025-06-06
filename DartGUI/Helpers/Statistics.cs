namespace DartGUI.Helpers;

internal class Statistics
{
    #region Local Variables

    private int _totalPoints;
    private int _totalDartsThrown;

    #endregion

    #region Operations

    internal void AddPoints(int points, int dartThrown)
    {
        _totalPoints += points;
        _totalDartsThrown += dartThrown;
        AveragePoints = (double)_totalPoints / _totalDartsThrown * 3;
    }

    #endregion

    #region Properties

    internal double AveragePoints { get; private set; }

    #endregion
}
