using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DartGUI.Games;
using DartGUI.Helpers;
using DartGUI.Managers;

namespace DartGUI.Pages;

public partial class StatisticsPage : ContentPage
{
    #region Local Variables

    private readonly Game _game;

    #endregion

    #region Constructors

    internal StatisticsPage(Game game)
    {
        _game = game;
        InitializeComponent();
        ContentPage.BackgroundColor = DesignColors.BACKGROUND_COLOR;
        InitializeLayout();
    }

    #endregion

    #region Operations

    private void InitializeLayout()
    {
        foreach (var player in _game.GetPlayers())
        {
            var playerNameLabel = new Label
            {
                FontSize = 30.0 * SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = $"Player: {player.Name}",
                TextColor = DesignColors.LABEL_TEXT_COLOR
            };
            var averagePointsLabel = new Label
            {
                FontSize = 30.0 * SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Margin = new Thickness(0.0, 0.0, 0.0, 35.0),
                Text = $"Average: {player.Statistics.AveragePoints:F2}",
                TextColor = DesignColors.LABEL_TEXT_COLOR
            };
            MainVerticalStackLayout.Add(playerNameLabel);
            MainVerticalStackLayout.Add(averagePointsLabel);
        }
    }

    #endregion

    #region Properties

    private static double HeightScale => ScaleManager.CurrentManager!.HeightScale;

    private static double WidthScale => ScaleManager.CurrentManager!.WidthScale;

    private static double SmallerScale => ScaleManager.CurrentManager!.SmallerScale;

    #endregion
}
