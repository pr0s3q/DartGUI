using DartGUI.Games;
using DartGUI.Helpers;
using DartGUI.Helpers.Enums;
using DartGUI.Managers;
using Microsoft.Maui.Controls.Shapes;

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
            var verticalStackLayout = new VerticalStackLayout
            {
                Spacing = 10
            };

            var playerNameLabel = new Label
            {
                FontSize = 30.0 * SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Padding = new Thickness(30.0, 25.0),
                Text = player.Name,
                TextColor = DesignColors.LABEL_TEXT_COLOR
            };
            var playerNameBorder = new Border
            {
                BackgroundColor = DesignColors.LIGHT_BACKGROUND_COLOR,
                Content = playerNameLabel,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0.0, 0.0, 0.0, 10.0),
                StrokeShape = new RoundRectangle() {CornerRadius = 10},
                StrokeThickness = 0
            };
            verticalStackLayout.Add(playerNameBorder);

            var horizontalStackLayoutRow1 = new HorizontalStackLayout
            {
                Spacing = 10,
                HorizontalOptions = LayoutOptions.Center
            };

            var averagePointsVsl = new VerticalStackLayout
            {
                Padding = new Thickness(30.0, 25.0)
            };
            var averagePointsLabel = new Label
            {
                FontSize = 30.0 * SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = $"{player.Statistics.AveragePoints:F2}",
                TextColor = DesignColors.LABEL_TEXT_COLOR
            };
            var averagePointsTextLabel = new Label
            {
                FontSize = 15.0 * SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "Average",
                TextColor = DesignColors.LABEL_LIGHT_TEXT_COLOR
            };
            averagePointsVsl.Add(averagePointsLabel);
            averagePointsVsl.Add(averagePointsTextLabel);
            var averagePointsBorder = new Border
            {
                BackgroundColor = DesignColors.LIGHT_BACKGROUND_COLOR,
                Content = averagePointsVsl,
                StrokeShape = new RoundRectangle() {CornerRadius = 10},
                StrokeThickness = 0
            };
            horizontalStackLayoutRow1.Add(averagePointsBorder);

            var mostCommonFieldVsl = new VerticalStackLayout
            {
                Padding = new Thickness(30.0, 25.0)
            };
            var mostCommonFieldLabel = new Label
            {
                FontSize = 30.0 * SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = CreateString(player.Statistics.MostCommonField),
                TextColor = DesignColors.LABEL_TEXT_COLOR
            };
            var mostCommonFieldTextLabel = new Label
            {
                FontSize = 15.0 * SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "Most common field",
                TextColor = DesignColors.LABEL_LIGHT_TEXT_COLOR
            };
            mostCommonFieldVsl.Add(mostCommonFieldLabel);
            mostCommonFieldVsl.Add(mostCommonFieldTextLabel);
            var mostCommonFieldBorder = new Border
            {
                BackgroundColor = DesignColors.LIGHT_BACKGROUND_COLOR,
                Content = mostCommonFieldVsl,
                StrokeShape = new RoundRectangle() {CornerRadius = 10},
                StrokeThickness = 0
            };
            horizontalStackLayoutRow1.Add(mostCommonFieldBorder);

            var mostCommonDoubleEndVsl = new VerticalStackLayout
            {
                Padding = new Thickness(30.0, 25.0)
            };
            var mostCommonDoubleEndLabel = new Label
            {
                FontSize = 30.0 * SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = CreateString(player.Statistics.MostCommonDoubleEnd),
                TextColor = DesignColors.LABEL_TEXT_COLOR
            };
            var mostCommonDoubleEndTextLabel = new Label
            {
                FontSize = 15.0 * SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "Most common double end",
                TextColor = DesignColors.LABEL_LIGHT_TEXT_COLOR
            };
            mostCommonDoubleEndVsl.Add(mostCommonDoubleEndLabel);
            mostCommonDoubleEndVsl.Add(mostCommonDoubleEndTextLabel);
            var mostCommonDoubleEndBorder = new Border
            {
                BackgroundColor = DesignColors.LIGHT_BACKGROUND_COLOR,
                Content = mostCommonDoubleEndVsl,
                StrokeShape = new RoundRectangle() {CornerRadius = 10},
                StrokeThickness = 0
            };
            horizontalStackLayoutRow1.Add(mostCommonDoubleEndBorder);

            verticalStackLayout.Add(horizontalStackLayoutRow1);

            var horizontalStackLayoutRow2 = new HorizontalStackLayout
            {
                Spacing = 10,
                HorizontalOptions = LayoutOptions.Center
            };

            var highestCheckoutVsl = new VerticalStackLayout
            {
                Padding = new Thickness(30.0, 25.0)
            };
            var highestCheckoutLabel = new Label
            {
                FontSize = 30.0 * SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = player.Statistics.HighestCheckout.ToString(),
                TextColor = DesignColors.LABEL_TEXT_COLOR
            };
            var highestCheckoutTextLabel = new Label
            {
                FontSize = 15.0 * SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "Highest checkout",
                TextColor = DesignColors.LABEL_LIGHT_TEXT_COLOR
            };
            highestCheckoutVsl.Add(highestCheckoutLabel);
            highestCheckoutVsl.Add(highestCheckoutTextLabel);
            var highestCheckoutBorder = new Border
            {
                BackgroundColor = DesignColors.LIGHT_BACKGROUND_COLOR,
                Content = highestCheckoutVsl,
                StrokeShape = new RoundRectangle() {CornerRadius = 10},
                StrokeThickness = 0
            };
            horizontalStackLayoutRow2.Add(highestCheckoutBorder);

            var highestCheckoutDartsThrownVsl = new VerticalStackLayout
            {
                Padding = new Thickness(30.0, 25.0)
            };
            var highestCheckoutDartsThrownLabel = new Label
            {
                FontSize = 30.0 * SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = CreateString(player.Statistics.HighestCheckoutDartsThrown),
                TextColor = DesignColors.LABEL_TEXT_COLOR
            };
            var highestCheckoutDartsThrownTextLabel = new Label
            {
                FontSize = 15.0 * SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "Highest checkout darts",
                TextColor = DesignColors.LABEL_LIGHT_TEXT_COLOR
            };
            highestCheckoutDartsThrownVsl.Add(highestCheckoutDartsThrownLabel);
            highestCheckoutDartsThrownVsl.Add(highestCheckoutDartsThrownTextLabel);
            var highestCheckoutDartsThrownBorder = new Border
            {
                BackgroundColor = DesignColors.LIGHT_BACKGROUND_COLOR,
                Content = highestCheckoutDartsThrownVsl,
                StrokeShape = new RoundRectangle() {CornerRadius = 10},
                StrokeThickness = 0
            };
            horizontalStackLayoutRow2.Add(highestCheckoutDartsThrownBorder);

            verticalStackLayout.Add(horizontalStackLayoutRow2);

            var horizontalStackLayoutRow3 = new HorizontalStackLayout
            {
                Spacing = 10,
                HorizontalOptions = LayoutOptions.Center
            };

            var hundredEightyTallyCounterVsl = new VerticalStackLayout
            {
                Padding = new Thickness(30.0, 25.0)
            };
            var hundredEightyTallyCounterLabel = new Label
            {
                FontSize = 30.0 * SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = player.Statistics.HundredEightyTallyCounter.ToString(),
                TextColor = DesignColors.LABEL_TEXT_COLOR
            };
            var hundredEightyTallyCounterTextLabel = new Label
            {
                FontSize = 15.0 * SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "180",
                TextColor = DesignColors.LABEL_LIGHT_TEXT_COLOR
            };
            hundredEightyTallyCounterVsl.Add(hundredEightyTallyCounterLabel);
            hundredEightyTallyCounterVsl.Add(hundredEightyTallyCounterTextLabel);
            var hundredEightyTallyCounterBorder = new Border
            {
                BackgroundColor = DesignColors.LIGHT_BACKGROUND_COLOR,
                Content = hundredEightyTallyCounterVsl,
                StrokeShape = new RoundRectangle() {CornerRadius = 10},
                StrokeThickness = 0
            };
            horizontalStackLayoutRow3.Add(hundredEightyTallyCounterBorder);

            var hundredFortyPlusTallyCounterVsl = new VerticalStackLayout
            {
                Padding = new Thickness(30.0, 25.0)
            };
            var hundredFortyPlusTallyCounterLabel = new Label
            {
                FontSize = 30.0 * SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = player.Statistics.HundredFortyPlusTallyCounter.ToString(),
                TextColor = DesignColors.LABEL_TEXT_COLOR
            };
            var hundredFortyPlusTallyCounterTextLabel = new Label
            {
                FontSize = 15.0 * SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "140+",
                TextColor = DesignColors.LABEL_LIGHT_TEXT_COLOR
            };
            hundredFortyPlusTallyCounterVsl.Add(hundredFortyPlusTallyCounterLabel);
            hundredFortyPlusTallyCounterVsl.Add(hundredFortyPlusTallyCounterTextLabel);
            var hundredFortyPlusTallyCounterBorder = new Border
            {
                BackgroundColor = DesignColors.LIGHT_BACKGROUND_COLOR,
                Content = hundredFortyPlusTallyCounterVsl,
                StrokeShape = new RoundRectangle() {CornerRadius = 10},
                StrokeThickness = 0
            };
            horizontalStackLayoutRow3.Add(hundredFortyPlusTallyCounterBorder);

            var hundredPlusTallyCounterVsl = new VerticalStackLayout
            {
                Padding = new Thickness(30.0, 25.0)
            };
            var hundredPlusTallyCounterLabel = new Label
            {
                FontSize = 30.0 * SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = player.Statistics.HundredPlusTallyCounter.ToString(),
                TextColor = DesignColors.LABEL_TEXT_COLOR
            };
            var hundredPlusTallyCounterTextLabel = new Label
            {
                FontSize = 15.0 * SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "100+",
                TextColor = DesignColors.LABEL_LIGHT_TEXT_COLOR
            };
            hundredPlusTallyCounterVsl.Add(hundredPlusTallyCounterLabel);
            hundredPlusTallyCounterVsl.Add(hundredPlusTallyCounterTextLabel);
            var hundredPlusTallyCounterBorder = new Border
            {
                BackgroundColor = DesignColors.LIGHT_BACKGROUND_COLOR,
                Content = hundredPlusTallyCounterVsl,
                StrokeShape = new RoundRectangle() {CornerRadius = 10},
                StrokeThickness = 0
            };
            horizontalStackLayoutRow3.Add(hundredPlusTallyCounterBorder);

            verticalStackLayout.Add(horizontalStackLayoutRow3);

            MainVerticalStackLayout.Add(verticalStackLayout);
        }
    }

    #endregion

    #region Helpers

    private static string CreateString(List<Dartboard> dartboardList)
    {
        int size = 1;
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
