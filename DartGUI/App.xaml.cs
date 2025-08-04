using DartGUI.Helpers;
using DartGUI.Managers;
using DartGUI.Pages;

namespace DartGUI;

public partial class App
{
    public App()
    {
        InitializeComponent();

        var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
        // Since app is in Landscape mode, height and width may be swapped
        if (mainDisplayInfo.Width > mainDisplayInfo.Height)
        {
            var height = mainDisplayInfo.Height;
            var width = mainDisplayInfo.Width;
            ScaleManager.Create(width, height, mainDisplayInfo.Density);
        }
        else
        {
            var width = mainDisplayInfo.Height;
            var height = mainDisplayInfo.Width;
            ScaleManager.Create(width, height, mainDisplayInfo.Density);
        }
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new NavigationPage(new MainPage())
        {
            BarBackgroundColor = DesignColors.BAR_BACKGROUND_COLOR
        });
    }
}
