using DartGUI.Games;
using DartGUI.Helpers;
using DartGUI.Managers;

namespace DartGUI.Pages;

public partial class StatisticsPage
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
            var playerStaticticsBorder = new Border
            {
                Margin = new Thickness(0.0, 0.0, 0.0, 45.0),
                Stroke = DesignColors.BORDER_COLOR,
                StrokeThickness = 2.0 * SmallerScale
            };
            var verticalStackLayout = new VerticalStackLayout();

            var playerNameLabel = new Label
            {
                FontSize = 30.0 * SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = $"Player: {player.Name}",
                TextColor = DesignColors.LABEL_TEXT_COLOR
            };
            verticalStackLayout.Add(playerNameLabel);

            var averagePointsLabel = new Label
            {
                FontSize = 30.0 * SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = $"Average: {player.Statistics.AveragePoints:F2}",
                TextColor = DesignColors.LABEL_TEXT_COLOR
            };
            verticalStackLayout.Add(averagePointsLabel);

            // TODO: Fix performance for creating string
            var mostCommonFieldText = "|";
            player.Statistics.MostCommonField.ForEach(point => mostCommonFieldText = $"{mostCommonFieldText} {point.ToString()} |");
            var mostCommonFieldLabel = new Label
            {
                FontSize = 30.0 * SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = $"Most common field: {mostCommonFieldText}",
                TextColor = DesignColors.LABEL_TEXT_COLOR
            };
            verticalStackLayout.Add(mostCommonFieldLabel);

            // TODO: Fix performance for creating string
            var mostCommonDoubleEndText = "|";
            player.Statistics.MostCommonDoubleEnd.ForEach(point => mostCommonDoubleEndText = $"{mostCommonDoubleEndText} {point.ToString()} |");
            var mostCommonDoubleEndLabel = new Label
            {
                FontSize = 30.0 * SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = $"Most common double end: {mostCommonDoubleEndText}",
                TextColor = DesignColors.LABEL_TEXT_COLOR
            };
            verticalStackLayout.Add(mostCommonDoubleEndLabel);

            var highestCheckoutLabel = new Label
            {
                FontSize = 30.0 * SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = $"Highest checkout: {player.Statistics.HighestCheckout}",
                TextColor = DesignColors.LABEL_TEXT_COLOR
            };
            verticalStackLayout.Add(highestCheckoutLabel);

            var hundredEightyTallyCounterLabel = new Label
            {
                FontSize = 30.0 * SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = $"180: {player.Statistics.HundredEightyTallyCounter}",
                TextColor = DesignColors.LABEL_TEXT_COLOR
            };
            verticalStackLayout.Add(hundredEightyTallyCounterLabel);

            var hundredfortyPlusTallyCounterLabel = new Label
            {
                FontSize = 30.0 * SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = $"140+: {player.Statistics.HundredFortyPlusTallyCounter}",
                TextColor = DesignColors.LABEL_TEXT_COLOR
            };
            verticalStackLayout.Add(hundredfortyPlusTallyCounterLabel);

            var hundredPlusTallyCounterLabel = new Label
            {
                FontSize = 30.0 * SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = $"100+: {player.Statistics.HundredPlusTallyCounter}",
                TextColor = DesignColors.LABEL_TEXT_COLOR
            };
            verticalStackLayout.Add(hundredPlusTallyCounterLabel);

            playerStaticticsBorder.Content = verticalStackLayout;
            MainVerticalStackLayout.Add(playerStaticticsBorder);
        }
    }

    #endregion

    #region Properties

    private static double SmallerScale => ScaleManager.CurrentManager!.SmallerScale;

    #endregion
}
