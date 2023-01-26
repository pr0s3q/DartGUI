namespace DartGUI
{
    internal class Checkout
    {

        #region Constructor

        internal Checkout(int shootsNeed, string ending)
        {
            ShootsNeed = shootsNeed;
            Ending = ending;
        }

        #endregion

        #region Properties

        internal int ShootsNeed { get; }

        internal string Ending { get; }

        #endregion

    }
}
