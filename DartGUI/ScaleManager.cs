namespace DartGUI
{
    internal class ScaleManager
    {

        #region Local Variables

        private readonly double DEFAULT_WIDTH = 2560.0;
        private readonly double DEFAULT_HEIGHT = 1600.0;
        private readonly double DEFAULT_DENSITY = 2.125;

        private readonly double TOLERANCE = 0.0001;

        private readonly double _width;
        private readonly double _height;
        private readonly double _density;

        #endregion

        #region Constructors

        private ScaleManager(double width, double height, double density)
        {
            _width = width;
            _height = height;
            _density = density;
            if (Math.Abs(_width - DEFAULT_WIDTH) < TOLERANCE &&
                Math.Abs(_height - DEFAULT_HEIGHT) < TOLERANCE &&
                Math.Abs(_density - DEFAULT_DENSITY) < TOLERANCE)
                IsDefault = true;
            else
                IsDefault = false;
        }

        #endregion

        #region Operations

        internal static void Create(double width, double height, double density)
        {
            CurrentManager ??= new ScaleManager(width, height, density);
        }

        #endregion

        #region Properties

        internal static ScaleManager? CurrentManager { get; private set; }

        internal bool IsDefault { get; init; }


        /// <summary>
        /// Horizontal Scale
        /// </summary>
        internal double WidthScale => (_width / DEFAULT_WIDTH) * DensityScale;

        /// <summary>
        /// Vertical Scale
        /// </summary>
        internal double HeightScale => (_height / DEFAULT_HEIGHT) * DensityScale;

        internal double SmallerScale => WidthScale < HeightScale ? WidthScale : HeightScale;

        private double DensityScale => DEFAULT_DENSITY / _density;

        #endregion
    }
}
