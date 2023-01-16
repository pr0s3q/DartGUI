using System.Collections.ObjectModel;

namespace DartGUI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainCounterPage
    {
        private readonly ReadOnlyCollection<Dictionary<string, int>> _rowButtonsData = new List<Dictionary<string, int>>
        {
            new()
            {
                { "S1", 1 }, { "S2", 2 }, { "S3", 3 }, { "S4", 4 }, { "S5", 5 },
                { "S6", 6 }, { "S7", 7 }, { "S8", 8 }, { "S9", 9 }, { "S10", 10 },
                { "S11", 11 }, { "S12", 12 }, { "S13", 13 }, { "S14", 14 }, { "S15", 15 },
                { "S16", 16 }, { "S17", 17 }, { "S18", 18 }, { "S19", 19 }, { "S20", 20 }, { "S25", 25 }
            },
            new()
            {
                { "D1", 1 }, { "D2", 2 }, { "D3", 3 }, { "D4", 4 }, { "D5", 5 },
                { "D6", 6 }, { "D7", 7 }, { "D8", 8 }, { "D9", 9 }, { "D10", 10 },
                { "D11", 11 }, { "D12", 12 }, { "D13", 13 }, { "D14", 14 }, { "D15", 15 },
                { "D16", 16 }, { "D17", 17 }, { "D18", 18 }, { "D19", 19 }, { "D20", 20 }, { "D25", 25 }
            },
            new()
            {
                { "T1", 1 }, { "T2", 2 }, { "T3", 3 }, { "T4", 4 }, { "T5", 5 },
                { "T6", 6 }, { "T7", 7 }, { "T8", 8 }, { "T9", 9 }, { "T10", 10 },
                { "T11", 11 }, { "T12", 12 }, { "T13", 13 }, { "T14", 14 }, { "T15", 15 },
                { "T16", 16 }, { "T17", 17 }, { "T18", 18 }, { "T19", 19 }, { "T20", 20 }, { "X", 0 }
            }
        }.AsReadOnly();

        public MainCounterPage(IReadOnlyList<string> playerNames)
        {
            InitializeComponent();
            ContentPage.BackgroundColor = DesignColors.BACKGROUND_COLOR;
            foreach (var dict in _rowButtonsData)
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
                        FontSize = 25.0,
                        Margin = new Thickness(1, 0, 1, 0),
                        Padding = new Thickness(0, 10, 0, 10),
                        WidthRequest = 50,
                        Text = point.Key,
                        TextColor = DesignColors.BUTTON_TEXT_COLOR
                    };
                    hsl.Add(button);
                }

                VerticalStackLayout.Add(hsl);
            }

            var currentDataLabel = new Label
            {
                FontSize = 30.0,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "Possible checkout: T20 | T19 | D12 - Shots left: 3",
                TextColor = DesignColors.LABEL_TEXT_COLOR
            };
            VerticalStackLayout.Add(currentDataLabel);
            var hsl2 = new HorizontalStackLayout
            {
                HorizontalOptions = LayoutOptions.Center
            };
            var grid = new Grid
            {
                ColumnDefinitions = new ColumnDefinitionCollection(new ColumnDefinition(50), new ColumnDefinition(150),
                    new ColumnDefinition(75), new ColumnDefinition(75), new ColumnDefinition(125)),
                RowDefinitions = new RowDefinitionCollection(new RowDefinition(50), new RowDefinition(50),
                    new RowDefinition(50), new RowDefinition(50), new RowDefinition(50)),
                VerticalOptions = LayoutOptions.Center,
            };
            for(int i = 0; i < playerNames.Count; i++)
            {
                var border = new Border
                {
                    Stroke = new SolidColorBrush(DesignColors.BORDER_COLOR),
                    StrokeThickness = 2.0,
                };
                var label = new Label
                {
                    FontSize = 30.0,
                    HorizontalTextAlignment = TextAlignment.Center,
                    Text = (i+1).ToString(),
                    TextColor = DesignColors.LABEL_TEXT_COLOR,
                };
                border.Content = label;
                grid.Add(border, 0, i);

                border = new Border
                {
                    Stroke = new SolidColorBrush(DesignColors.BORDER_COLOR),
                    StrokeThickness = 2.0,
                };
                label = new Label
                {
                    FontSize = 30.0,
                    HorizontalTextAlignment = TextAlignment.Center,
                    Text = playerNames[i],
                    TextColor = DesignColors.LABEL_TEXT_COLOR
                };
                border.Content = label;
                grid.Add(border, 1, i);

                border = new Border
                {
                    Stroke = new SolidColorBrush(DesignColors.BORDER_COLOR),
                    StrokeThickness = 2.0,
                };
                label = new Label
                {
                    FontSize = 30.0,
                    HorizontalTextAlignment = TextAlignment.Center,
                    Text = "0",
                    TextColor = DesignColors.LABEL_TEXT_COLOR
                };
                border.Content = label;
                grid.Add(border, 2, i);
                border = new Border
                {
                    Stroke = new SolidColorBrush(DesignColors.BORDER_COLOR),
                    StrokeThickness = 2.0,
                };
                label = new Label
                {
                    FontSize = 30.0,
                    HorizontalTextAlignment = TextAlignment.Center,
                    Text = "0",
                    TextColor = DesignColors.LABEL_TEXT_COLOR
                };
                border.Content = label;
                grid.Add(border, 3, i);
                border = new Border
                {
                    Stroke = new SolidColorBrush(DesignColors.BORDER_COLOR),
                    StrokeThickness = 2.0,
                };
                label = new Label
                {
                    FontSize = 30.0,
                    HorizontalTextAlignment = TextAlignment.Center,
                    Text = "501",
                    TextColor = DesignColors.LABEL_TEXT_COLOR
                };
                border.Content = label;
                grid.Add(border, 4, i);
            }
            hsl2.Add(grid);
            VerticalStackLayout.Add(hsl2);
        }
    }
}