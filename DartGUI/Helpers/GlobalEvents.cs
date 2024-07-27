namespace DartGUI.Helpers;

internal static class GlobalEvents
{
    internal static void OnButton_Pressed(object? sender, EventArgs e)
    {
        if (sender is Button button)
            button.BackgroundColor = DesignColors.BUTTON_PRESSED_BACKGROUND_COLOR;
    }

    internal static void OnButton_Released(object? sender, EventArgs e)
    {
        if (sender is Button button)
            button.BackgroundColor = DesignColors.BUTTON_BACKGROUND_COLOR; 
    }
}