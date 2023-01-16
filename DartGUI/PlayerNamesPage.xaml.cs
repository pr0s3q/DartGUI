namespace DartGUI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerNamesPage
    {
        private readonly int _noOfPlayers;
        public PlayerNamesPage(int noOfPlayers)
        {
            _noOfPlayers = noOfPlayers;
            InitializeComponent();
            ContentPage.BackgroundColor = DesignColors.BACKGROUND_COLOR;
            Label.TextColor = DesignColors.LABEL_TEXT_COLOR;
            for (int i = 0; i < noOfPlayers; i++)
            {
                var entry = new Entry
                {
                    BackgroundColor = DesignColors.ENTRY_BACKGROUND_COLOR,
                    ClearButtonVisibility = ClearButtonVisibility.WhileEditing,
                    FontSize = 25.0,
                    Placeholder = $"Player {i+1}",
                    WidthRequest = 300.0,
                    TextColor = DesignColors.ENTRY_TEXT_COLOR
                };
                VerticalStackLayout.Add(entry);
            }

            var button = new Button
            {
                BackgroundColor = DesignColors.BUTTON_BACKGROUND_COLOR,
                FontSize = 30.0,
                WidthRequest = 200.0,
                Text = "Apply",
                TextColor = DesignColors.BUTTON_TEXT_COLOR
            };
            button.Clicked += Button_OnClicked;
            VerticalStackLayout.Add(button);
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            var playerNames = new List<string>(_noOfPlayers);
            var children = VerticalStackLayout.Children;
            foreach (var child in children)
            {
                if (child is Entry entryChild)
                {
                    playerNames.Add(entryChild.Text);
                }
            }

            Navigation.PushAsync(new MainCounterPage(playerNames));
        }
    }
}