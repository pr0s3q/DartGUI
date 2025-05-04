using DartGUI.Database;
using DartGUI.Games;
using DartGUI.Helpers;
using DartGUI.Helpers.Enums;
using DartGUI.Managers;

namespace DartGUI.Pages;

public partial class MainCounterPage
{
    #region Local Variables

    internal static readonly int[] RowButtonsData =
    [
        1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 25,
        2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40, 50,
        3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36, 39, 42, 45, 48, 51, 54, 57, 60, 0
    ];

    private readonly List<string> _playerNames;

    private readonly Game _game;

    #endregion

    #region Constructor

    public MainCounterPage(List<string> playerNames)
    {
        _playerNames = playerNames;
        InitializeComponent();
        ContentPage.BackgroundColor = DesignColors.BACKGROUND_COLOR;
        _game = new Game(_playerNames);
        InitializeLayout();
        _game.SetTableRowsColor(0);
    }

    internal MainCounterPage(GameBase game)
    {
        _playerNames = game.GetPlayerNames();
        InitializeComponent();
        ContentPage.BackgroundColor = DesignColors.BACKGROUND_COLOR;
        _game = new Game(game);
        InitializeLayout();
        PopulateData();
        _game.SetTableRowsColor();
    }

    #endregion

    #region Events

    private void OnButton_Clicked(object? sender, EventArgs e)
    {
        if (sender is not Button button)
            return;

        if (Enum.TryParse(typeof(Dartboard), button.Text, out var result) && result is Dartboard value)
            _game.AddPoints(value);
    }

    private void OnAcceptButton_Clicked(object? sender, EventArgs e) => _game.AcceptPoints();

    private void OnUndoButton_Clicked(object? sender, EventArgs e) => _game.Undo();

    private void OnSaveGameButton_Clicked(object? sender, EventArgs e) => MemoryDatabase.SaveLastGame(_game);

    private void OnStatisticsButton_Clicked(object? sender, EventArgs e)
    {
    }

    #endregion

    #region Operations

    private void InitializeLayout()
    {
        var topHsl = new HorizontalStackLayout
        {
            HorizontalOptions = LayoutOptions.Center
        };
        var topGrid = new Grid
        {
            ColumnDefinitions = new ColumnDefinitionCollection(
                new ColumnDefinition(new GridLength(130.0 * WidthScale)),
                new ColumnDefinition(new GridLength(840.0 * WidthScale)),
                new ColumnDefinition(new GridLength(130.0 * WidthScale))),
            RowDefinitions = new RowDefinitionCollection(
                new RowDefinition(new GridLength(50.0 * HeightScale))),
            VerticalOptions = LayoutOptions.Center
        };
        var saveGameButton = new Button
        {
            BackgroundColor = DesignColors.BUTTON_BACKGROUND_COLOR,
            FontSize = 25.0 * SmallerScale,
            Margin = new Thickness(1.0 * SmallerScale, 0.0, 1.0 * SmallerScale, 0.0),
            Padding = new Thickness(0.0, 10.0 * HeightScale, 0.0, 10.0 * HeightScale),
            WidthRequest = 120.0 * WidthScale,
            HeightRequest = 50.0 * HeightScale,
            Text = "Save",
            TextColor = DesignColors.BUTTON_TEXT_COLOR
        };
        saveGameButton.MinimumHeightRequest *= HeightScale;
        saveGameButton.MinimumWidthRequest *= WidthScale;
        saveGameButton.Clicked += OnSaveGameButton_Clicked;
        saveGameButton.Pressed += GlobalEvents.OnButton_Pressed;
        saveGameButton.Released += GlobalEvents.OnButton_Released;
        topGrid.Add(saveGameButton, 0);

        var lastThreeShotsLabel = new Label
        {
            FontSize = 30.0 * SmallerScale,
            HorizontalTextAlignment = TextAlignment.Center,
            Text = string.Empty,
            TextColor = DesignColors.LABEL_TEXT_COLOR
        };
        topGrid.Add(lastThreeShotsLabel, 1);

        _game.AddLastThreeShotsLabel(lastThreeShotsLabel);

        var statisticsButton = new Button
        {
            BackgroundColor = DesignColors.BUTTON_BACKGROUND_COLOR,
            FontSize = 25.0 * SmallerScale,
            Margin = new Thickness(1.0 * SmallerScale, 0.0, 1.0 * SmallerScale, 0.0),
            Padding = new Thickness(0.0, 10.0 * HeightScale, 0.0, 10.0 * HeightScale),
            WidthRequest = 120.0 * WidthScale,
            HeightRequest = 50.0 * HeightScale,
            Text = "Statistics",
            TextColor = DesignColors.BUTTON_TEXT_COLOR
        };
        statisticsButton.MinimumHeightRequest *= HeightScale;
        statisticsButton.MinimumWidthRequest *= WidthScale;
        statisticsButton.Clicked += OnStatisticsButton_Clicked;
        statisticsButton.Pressed += GlobalEvents.OnButton_Pressed;
        statisticsButton.Released += GlobalEvents.OnButton_Released;
        topGrid.Add(statisticsButton, 2);
        topHsl.Add(topGrid);
        VerticalStackLayout.Add(topHsl);

        for (var i = 0; i < 3; i++)
        {
            var hsl = new HorizontalStackLayout
            {
                HorizontalOptions = LayoutOptions.Center
            };
            for (var j = 0; j < 21; j++)
            {
                var button = new Button
                {
                    BackgroundColor = DesignColors.BUTTON_BACKGROUND_COLOR,
                    FontSize = 25.0 * SmallerScale,
                    Margin = new Thickness(1.0 * SmallerScale, 0.0, 1.0 * SmallerScale, 0.0),
                    Padding = new Thickness(0.0, 10.0 * HeightScale, 0.0, 10.0 * HeightScale),
                    WidthRequest = 50.0 * WidthScale,
                    HeightRequest = 50.0 * HeightScale,
                    Text = ((Dartboard)(j + 21 * i)).ToString(),
                    TextColor = DesignColors.BUTTON_TEXT_COLOR
                };
                button.MinimumHeightRequest *= HeightScale;
                button.MinimumWidthRequest *= WidthScale;
                button.Clicked += OnButton_Clicked;
                button.Pressed += GlobalEvents.OnButton_Pressed;
                button.Released += GlobalEvents.OnButton_Released;
                hsl.Add(button);
            }

            VerticalStackLayout.Add(hsl);
        }

        var middleHsl = new HorizontalStackLayout
        {
            HorizontalOptions = LayoutOptions.Center
        };
        var undoButton = new Button
        {
            BackgroundColor = DesignColors.BUTTON_BACKGROUND_COLOR,
            FontSize = 25.0 * SmallerScale,
            Margin = new Thickness(5.0 * WidthScale, 0.0, 5.0 * WidthScale, 0.0),
            Padding = new Thickness(0.0, 5.0 * HeightScale, 0.0, 5.0 * HeightScale),
            WidthRequest = 120.0 * WidthScale,
            Text = "Undo",
            TextColor = DesignColors.BUTTON_TEXT_COLOR
        };
        undoButton.MinimumHeightRequest *= HeightScale;
        undoButton.MinimumWidthRequest *= WidthScale;
        undoButton.Clicked += OnUndoButton_Clicked;
        undoButton.Pressed += GlobalEvents.OnButton_Pressed;
        undoButton.Released += GlobalEvents.OnButton_Released;
        middleHsl.Add(undoButton);
        var acceptButton = new Button
        {
            BackgroundColor = DesignColors.BUTTON_BACKGROUND_COLOR,
            FontSize = 25.0 * SmallerScale,
            Margin = new Thickness(5.0 * WidthScale, 0.0, 5.0 * WidthScale, 0.0),
            Padding = new Thickness(0.0, 5.0 * HeightScale, 0.0, 5.0 * HeightScale),
            WidthRequest = 120.0 * WidthScale,
            Text = "Accept",
            TextColor = DesignColors.BUTTON_TEXT_COLOR
        };
        acceptButton.MinimumHeightRequest *= HeightScale;
        acceptButton.MinimumWidthRequest *= WidthScale;
        acceptButton.Clicked += OnAcceptButton_Clicked;
        acceptButton.Pressed += GlobalEvents.OnButton_Pressed;
        acceptButton.Released += GlobalEvents.OnButton_Released;
        middleHsl.Add(acceptButton);
        VerticalStackLayout.Add(middleHsl);

        var currentDataLabel = new Label
        {
            FontSize = 30.0 * SmallerScale,
            HorizontalTextAlignment = TextAlignment.Center,
            Text = $"Possible checkout: No possible checkouts - Shots left: {_game.ShotsLeft}",
            TextColor = DesignColors.LABEL_TEXT_COLOR
        };
        VerticalStackLayout.Add(currentDataLabel);
        _game.AddCurrentDataLabel(currentDataLabel);

        var bottomHsl = new HorizontalStackLayout
        {
            HorizontalOptions = LayoutOptions.Center
        };
        var grid = new Grid
        {
            ColumnDefinitions = new ColumnDefinitionCollection(
                new ColumnDefinition(new GridLength(50.0 * WidthScale)),
                new ColumnDefinition(new GridLength(250.0 * WidthScale)),
                new ColumnDefinition(new GridLength(75.0 * WidthScale)),
                new ColumnDefinition(new GridLength(125.0 * WidthScale))),
            RowDefinitions = new RowDefinitionCollection(
                new RowDefinition(new GridLength(50.0 * HeightScale)),
                new RowDefinition(new GridLength(50.0 * HeightScale)),
                new RowDefinition(new GridLength(50.0 * HeightScale)),
                new RowDefinition(new GridLength(50.0 * HeightScale)),
                new RowDefinition(new GridLength(50.0 * HeightScale))),
            VerticalOptions = LayoutOptions.Center
        };

        for (var i = 0; i < _playerNames.Count; i++)
        {
            // Player ID
            var playerIdBorder = new Border
            {
                Stroke = DesignColors.BORDER_COLOR,
                StrokeThickness = 2.0 * SmallerScale
            };
            var playerIdLabel = new Label
            {
                FontSize = 30.0 * SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = (i + 1).ToString(),
                TextColor = DesignColors.LABEL_TEXT_COLOR
            };
            playerIdBorder.Content = playerIdLabel;
            grid.Add(playerIdBorder, 0, i);

            // Player Name
            var playerNameBorder = new Border
            {
                Stroke = DesignColors.BORDER_COLOR,
                StrokeThickness = 2.0 * SmallerScale
            };
            var playerNameLabel = new Label
            {
                FontSize = 30.0 * SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = _game.GetPlayerName(i),
                TextColor = DesignColors.LABEL_TEXT_COLOR
            };
            playerNameBorder.Content = playerNameLabel;
            grid.Add(playerNameBorder, 1, i);

            // Legs won
            var legsWonBorder = new Border
            {
                Stroke = DesignColors.BORDER_COLOR,
                StrokeThickness = 2.0 * SmallerScale
            };
            var legsWonLabel = new Label
            {
                FontSize = 30.0 * SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = _game.GetPlayerLegsWon(i).ToString(),
                TextColor = DesignColors.LABEL_TEXT_COLOR
            };
            legsWonBorder.Content = legsWonLabel;
            grid.Add(legsWonBorder, 2, i);

            // Points left
            var pointsLeftBorder = new Border
            {
                Stroke = DesignColors.BORDER_COLOR,
                StrokeThickness = 2.0 * SmallerScale
            };
            var pointsLeftLabel = new Label
            {
                FontSize = 30.0 * SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = _game.GetPlayerPointsLeft(i).ToString(),
                TextColor = DesignColors.LABEL_TEXT_COLOR
            };
            pointsLeftBorder.Content = pointsLeftLabel;
            grid.Add(pointsLeftBorder, 3, i);

            _game.AddRowData(playerIdBorder, playerIdLabel,
                playerNameBorder, playerNameLabel,
                legsWonBorder, legsWonLabel,
                pointsLeftBorder, pointsLeftLabel);
        }

        bottomHsl.Add(grid);
        VerticalStackLayout.Add(bottomHsl);

        VerticalStackLayout.Spacing *= HeightScale;
    }

    private void PopulateData() => _game.PopulateData();

    #endregion

    #region Properties

    private static double HeightScale => ScaleManager.CurrentManager!.HeightScale;

    private static double WidthScale => ScaleManager.CurrentManager!.WidthScale;

    private static double SmallerScale => ScaleManager.CurrentManager!.SmallerScale;

    #endregion
}
