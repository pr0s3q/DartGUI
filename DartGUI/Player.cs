namespace DartGUI
{
    internal class Player
    {

        #region Constructor

        internal Player(string name)
        {
            Name = name;
        }

        #endregion

        #region Operations

        internal void AddWonLeg() => LegsWon++;

        internal void AddPointsBack(int points) => PointsLeft += points;

        internal void ResetPoints() => PointsLeft = 501;

        internal bool TrySubtractPoints(int points)
        {
            if (PointsLeft - points < 0 || PointsLeft == 1)
                return false;

            PointsLeft -= points;
            return true;
        }

        #endregion

        #region Properties

        internal int LegsWon { get; private set; }

        internal string Name { get; }

        internal int PointsLeft { get; private set; } = 501;

        #endregion

    }
}
