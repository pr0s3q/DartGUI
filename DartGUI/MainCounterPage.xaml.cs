using System.Collections.ObjectModel;
using DartGUI.Enums;

namespace DartGUI
{
    public partial class MainCounterPage
    {

        #region Local Variables

        internal static readonly ReadOnlyCollection<Dictionary<Dartboard, int>> ROW_BUTTONS_DATA = new List<Dictionary<Dartboard, int>>
        {
            new()
            {
                { Dartboard.S1, 1 }, { Dartboard.S2, 2 }, { Dartboard.S3, 3 }, { Dartboard.S4, 4 }, { Dartboard.S5, 5 },
                { Dartboard.S6, 6 }, { Dartboard.S7, 7 }, { Dartboard.S8, 8 }, { Dartboard.S9, 9 }, { Dartboard.S10, 10 },
                { Dartboard.S11, 11 }, { Dartboard.S12, 12 }, { Dartboard.S13, 13 }, { Dartboard.S14, 14 }, { Dartboard.S15, 15 },
                { Dartboard.S16, 16 }, { Dartboard.S17, 17 }, { Dartboard.S18, 18 }, { Dartboard.S19, 19 }, { Dartboard.S20, 20 }, { Dartboard.S25, 25 }
            },
            new()
            {
                { Dartboard.D1, 2 }, { Dartboard.D2, 4 }, { Dartboard.D3, 6 }, { Dartboard.D4, 8 }, { Dartboard.D5, 10 },
                { Dartboard.D6, 12 }, { Dartboard.D7, 14 }, { Dartboard.D8, 16 }, { Dartboard.D9, 18 }, { Dartboard.D10, 20 },
                { Dartboard.D11, 22 }, { Dartboard.D12, 24 }, { Dartboard.D13, 26 }, { Dartboard.D14, 28 }, { Dartboard.D15, 30 },
                { Dartboard.D16, 32 }, { Dartboard.D17, 34 }, { Dartboard.D18, 36 }, { Dartboard.D19, 38 }, { Dartboard.D20, 40 }, { Dartboard.D25, 50 }
            },
            new()
            {
                { Dartboard.T1, 3 }, { Dartboard.T2, 6 }, { Dartboard.T3, 9 }, { Dartboard.T4, 12 }, { Dartboard.T5, 15 },
                { Dartboard.T6, 18 }, { Dartboard.T7, 21 }, { Dartboard.T8, 24 }, { Dartboard.T9, 27 }, { Dartboard.T10, 30 },
                { Dartboard.T11, 33 }, { Dartboard.T12, 36 }, { Dartboard.T13, 39 }, { Dartboard.T14, 42 }, { Dartboard.T15, 45 },
                { Dartboard.T16, 48 }, { Dartboard.T17, 51 }, { Dartboard.T18, 54 }, { Dartboard.T19, 57 }, { Dartboard.T20, 60 }, { Dartboard.X, 0 }
            }
        }.AsReadOnly();

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

        #endregion

        #region Events

        private void OnButton_Clicked(object? sender, EventArgs e)
        {
            if (sender is not Button button)
                return;

            if (Enum.TryParse(typeof(Dartboard), button.Text, out object? result) && result is Dartboard value)
                _game.AddPoints(value);
        }

        private void OnAcceptButton_Clicked(object? sender, EventArgs e) => _game.AcceptPoints();

        private void OnUndoButton_Clicked(object? sender, EventArgs e) => _game.Undo();

        #endregion

        #region Operations

        private void InitializeLayout()
        {
            var lastThreeShotsLabel = new Label
            {
                FontSize = 30.0 * ScaleManager.CurrentManager!.SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = string.Empty,
                TextColor = DesignColors.LABEL_TEXT_COLOR
            };
            VerticalStackLayout.Add(lastThreeShotsLabel);
            _game.AddLastThreeShotsLabel(lastThreeShotsLabel);

            foreach (var dict in ROW_BUTTONS_DATA)
            {
                var hsl = new HorizontalStackLayout
                {
                    HorizontalOptions = LayoutOptions.Center
                };
                foreach (var point in dict)
                {
                    var button = new Button
                    {
                        BackgroundColor = DesignColors.BUTTON_BACKGROUND_COLOR,
                        FontSize = 25.0 * ScaleManager.CurrentManager.SmallerScale,
                        Margin = new Thickness(1.0 * ScaleManager.CurrentManager.SmallerScale, 0.0, 1.0 * ScaleManager.CurrentManager.SmallerScale, 0.0),
                        Padding = new Thickness(0.0, 10.0 * ScaleManager.CurrentManager.HeightScale, 0.0, 10.0 * ScaleManager.CurrentManager.HeightScale),
                        WidthRequest = 50.0 * ScaleManager.CurrentManager.WidthScale,
                        HeightRequest = 50.0 * ScaleManager.CurrentManager.HeightScale,
                        Text = point.Key.ToString(),
                        TextColor = DesignColors.BUTTON_TEXT_COLOR
                    };
                    button.MinimumHeightRequest *= ScaleManager.CurrentManager.HeightScale;
                    button.MinimumWidthRequest *= ScaleManager.CurrentManager.WidthScale;
                    button.Clicked += OnButton_Clicked;
                    hsl.Add(button);
                }

                VerticalStackLayout.Add(hsl);
            }

            {
                var hsl = new HorizontalStackLayout
                {
                    HorizontalOptions = LayoutOptions.Center
                };
                var button = new Button
                {
                    BackgroundColor = DesignColors.BUTTON_BACKGROUND_COLOR,
                    FontSize = 25.0 * ScaleManager.CurrentManager.SmallerScale,
                    Margin = new Thickness(5.0 * ScaleManager.CurrentManager.WidthScale, 0.0, 5.0 * ScaleManager.CurrentManager.WidthScale, 0.0),
                    Padding = new Thickness(0.0, 5.0 * ScaleManager.CurrentManager.HeightScale, 0.0, 5.0 * ScaleManager.CurrentManager.HeightScale),
                    WidthRequest = 120.0 * ScaleManager.CurrentManager.WidthScale,
                    Text = "Undo",
                    TextColor = DesignColors.BUTTON_TEXT_COLOR
                };
                button.MinimumHeightRequest *= ScaleManager.CurrentManager.HeightScale;
                button.MinimumWidthRequest *= ScaleManager.CurrentManager.WidthScale;
                button.Clicked += OnUndoButton_Clicked;
                hsl.Add(button);
                button = new Button
                {
                    BackgroundColor = DesignColors.BUTTON_BACKGROUND_COLOR,
                    FontSize = 25.0 * ScaleManager.CurrentManager.SmallerScale,
                    Margin = new Thickness(5.0 * ScaleManager.CurrentManager.WidthScale, 0.0, 5.0 * ScaleManager.CurrentManager.WidthScale, 0.0),
                    Padding = new Thickness(0.0, 5.0 * ScaleManager.CurrentManager.HeightScale, 0.0, 5.0 * ScaleManager.CurrentManager.HeightScale),
                    WidthRequest = 120.0 * ScaleManager.CurrentManager.WidthScale,
                    Text = "Accept",
                    TextColor = DesignColors.BUTTON_TEXT_COLOR
                };
                button.MinimumHeightRequest *= ScaleManager.CurrentManager.HeightScale;
                button.MinimumWidthRequest *= ScaleManager.CurrentManager.WidthScale;
                button.Clicked += OnAcceptButton_Clicked;
                hsl.Add(button);
                VerticalStackLayout.Add(hsl);
            }

            var currentDataLabel = new Label
            {
                FontSize = 30.0 * ScaleManager.CurrentManager.SmallerScale,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = $"Possible checkout: No possible checkouts - Shots left: {_game.ShotsLeft}",
                TextColor = DesignColors.LABEL_TEXT_COLOR
            };
            VerticalStackLayout.Add(currentDataLabel);
            _game.AddCurrentDataLabel(currentDataLabel);
            var hsl2 = new HorizontalStackLayout
            {
                HorizontalOptions = LayoutOptions.Center
            };
            var grid = new Grid
            {
                ColumnDefinitions = new ColumnDefinitionCollection(
                    new ColumnDefinition(new GridLength(50.0 * ScaleManager.CurrentManager.WidthScale)),
                    new ColumnDefinition(new GridLength(250.0 * ScaleManager.CurrentManager.WidthScale)),
                    new ColumnDefinition(new GridLength(75.0 * ScaleManager.CurrentManager.WidthScale)),
                    new ColumnDefinition(new GridLength(125.0 * ScaleManager.CurrentManager.WidthScale))),
                RowDefinitions = new RowDefinitionCollection(
                    new RowDefinition(new GridLength(50.0 * ScaleManager.CurrentManager.HeightScale)),
                    new RowDefinition(new GridLength(50.0 * ScaleManager.CurrentManager.HeightScale)),
                    new RowDefinition(new GridLength(50.0 * ScaleManager.CurrentManager.HeightScale)),
                    new RowDefinition(new GridLength(50.0 * ScaleManager.CurrentManager.HeightScale)),
                    new RowDefinition(new GridLength(50.0 * ScaleManager.CurrentManager.HeightScale))),
                VerticalOptions = LayoutOptions.Center
            };
            for (int i = 0; i < _playerNames.Count; i++)
            {
                // Player ID
                var playerIdBorder = new Border
                {
                    Stroke = new SolidColorBrush(DesignColors.BORDER_COLOR),
                    StrokeThickness = 2.0 * ScaleManager.CurrentManager.SmallerScale,
                };
                var playerIdLabel = new Label
                {
                    FontSize = 30.0 * ScaleManager.CurrentManager.SmallerScale,
                    HorizontalTextAlignment = TextAlignment.Center,
                    Text = (i + 1).ToString(),
                    TextColor = DesignColors.LABEL_TEXT_COLOR,
                };
                playerIdBorder.Content = playerIdLabel;
                grid.Add(playerIdBorder, 0, i);

                // Player Name
                var playerNameBorder = new Border
                {
                    Stroke = new SolidColorBrush(DesignColors.BORDER_COLOR),
                    StrokeThickness = 2.0 * ScaleManager.CurrentManager.SmallerScale,
                };
                var playerNameLabel = new Label
                {
                    FontSize = 30.0 * ScaleManager.CurrentManager.SmallerScale,
                    HorizontalTextAlignment = TextAlignment.Center,
                    Text = _game.GetPlayerName(i),
                    TextColor = DesignColors.LABEL_TEXT_COLOR
                };
                playerNameBorder.Content = playerNameLabel;
                grid.Add(playerNameBorder, 1, i);

                // Legs won
                var legsWonBorder = new Border
                {
                    Stroke = new SolidColorBrush(DesignColors.BORDER_COLOR),
                    StrokeThickness = 2.0 * ScaleManager.CurrentManager.SmallerScale,
                };
                var legsWonLabel = new Label
                {
                    FontSize = 30.0 * ScaleManager.CurrentManager.SmallerScale,
                    HorizontalTextAlignment = TextAlignment.Center,
                    Text = _game.GetPlayerLegsWon(i).ToString(),
                    TextColor = DesignColors.LABEL_TEXT_COLOR
                };
                legsWonBorder.Content = legsWonLabel;
                grid.Add(legsWonBorder, 2, i);

                // Points left
                var pointsLeftBorder = new Border
                {
                    Stroke = new SolidColorBrush(DesignColors.BORDER_COLOR),
                    StrokeThickness = 2.0 * ScaleManager.CurrentManager.SmallerScale,
                };
                var pointsLeftLabel = new Label
                {
                    FontSize = 30.0 * ScaleManager.CurrentManager.SmallerScale,
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
            hsl2.Add(grid);
            VerticalStackLayout.Add(hsl2);

            VerticalStackLayout.Spacing *= ScaleManager.CurrentManager.HeightScale;
        }

        #endregion

    }
}