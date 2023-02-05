using DartGUI.Enums;

namespace DartGUI
{
    internal static class Extensions
    {

        internal static void GetString(this Dartboard[] dartboard, out string result)
        {
            result = string.Empty;
            foreach (var d in dartboard)
            {
                if(d == Dartboard.None)
                    continue;

                result += $" {d} ";
            }
        }

    }
}
