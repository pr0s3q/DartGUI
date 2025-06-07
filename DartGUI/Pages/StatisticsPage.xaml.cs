using DartGUI.Games;
using DartGUI.Helpers;
using DartGUI.Helpers.Enums;
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

            var mostCommonFieldLabel = new Label
            {
                FontSize = 30.0 * SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = $"Most common field: {CreateString(player.Statistics.MostCommonField)}",
                TextColor = DesignColors.LABEL_TEXT_COLOR
            };
            verticalStackLayout.Add(mostCommonFieldLabel);

            var mostCommonDoubleEndLabel = new Label
            {
                FontSize = 30.0 * SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = $"Most common double end: {CreateString(player.Statistics.MostCommonDoubleEnd)}",
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

            var hundredFortyPlusTallyCounterLabel = new Label
            {
                FontSize = 30.0 * SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = $"140+: {player.Statistics.HundredFortyPlusTallyCounter}",
                TextColor = DesignColors.LABEL_TEXT_COLOR
            };
            verticalStackLayout.Add(hundredFortyPlusTallyCounterLabel);

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

    #region Helpers

    private static string CreateString(List<Dartboard> dartboardList)
    {
        int size = 0;
        foreach (var dartboard in dartboardList)
        {
            if (((int)dartboard >= 0 && (int)dartboard <= 8) ||
                ((int)dartboard >= 21 && (int)dartboard <= 29) ||
                ((int)dartboard >= 42 && (int)dartboard <= 50))
                size += 2;
            else
                size += 3;

            size += 3;
        }

        Span<char> result = stackalloc char[size];

        Span<char> emptyCharacter = stackalloc char[1];
        emptyCharacter[0] = ' ';

        Span<char> barCharacter = stackalloc char[1];
        barCharacter[0] = '|';

        barCharacter.CopyTo(result);

        int spanIndex = 1;

        foreach (var dartboard in dartboardList)
        {
            if (dartboard is Dartboard.None or Dartboard.X)
                continue;

            emptyCharacter.CopyTo(result.Slice(spanIndex));
            spanIndex++;
            dartboard.ToString().AsSpan().CopyTo(result.Slice(spanIndex));

            if (((int)dartboard >= 0 && (int)dartboard <= 8) ||
                ((int)dartboard >= 21 && (int)dartboard <= 29) ||
                ((int)dartboard >= 42 && (int)dartboard <= 50))
                spanIndex += 2;
            else
                spanIndex += 3;

            emptyCharacter.CopyTo(result.Slice(spanIndex));
            spanIndex++;
            barCharacter.CopyTo(result.Slice(spanIndex));
            spanIndex++;
        }

        return new string(result);
    }

    #endregion

    #region Properties

    private static double SmallerScale => ScaleManager.CurrentManager!.SmallerScale;

    #endregion
}
