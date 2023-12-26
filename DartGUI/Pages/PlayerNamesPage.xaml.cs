namespace DartGUI.Pages
{
    public partial class PlayerNamesPage
    {

        #region Local Variables

        private readonly int _noOfPlayers;

        #endregion

        #region Constructors

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
                    FontSize = 25.0 * ScaleManager.CurrentManager!.SmallerScale,
                    Placeholder = $"Player {i+1}",
                    ReturnType = ReturnType.Next,
                    TextColor = DesignColors.ENTRY_TEXT_COLOR,
                    WidthRequest = 300.0 * ScaleManager.CurrentManager.WidthScale
                };
                entry.MinimumHeightRequest *= ScaleManager.CurrentManager.HeightScale;
                entry.MinimumWidthRequest *= ScaleManager.CurrentManager.WidthScale;
                entry.Completed += Entry_Completed;
                VerticalStackLayout.Add(entry);
            }

            var button = new Button
            {
                BackgroundColor = DesignColors.BUTTON_BACKGROUND_COLOR,
                FontSize = 30.0 * ScaleManager.CurrentManager!.SmallerScale,
                Text = "Apply",
                TextColor = DesignColors.BUTTON_TEXT_COLOR,
                WidthRequest = 200.0 * ScaleManager.CurrentManager.WidthScale
            };
            button.MinimumHeightRequest *= ScaleManager.CurrentManager.HeightScale;
            button.MinimumWidthRequest *= ScaleManager.CurrentManager.WidthScale;
            button.Clicked += Button_OnClicked;
            VerticalStackLayout.Add(button);

            ScaleLayout();
        }

        #endregion

        #region Events

        private void Entry_Completed(object? sender, EventArgs e)
        {
            var children = VerticalStackLayout.Children;
            bool focusNextEntry = false;
            bool focused = false;
            foreach (var child in children)
            {
                if (child is not Entry entry)
                    continue;

                if (focusNextEntry)
                {
                    entry.Focus();
                    focused = true;
                    break;
                }

                if (entry == sender as Entry)
                {
                    focusNextEntry = true;
                }
            }

            if (!focused)
                NextPage();
        }

        private void Button_OnClicked(object? sender, EventArgs e) => NextPage();

        #endregion

        #region Operations

        private void NextPage()
        {
            var playerNames = new List<string>(_noOfPlayers);
            var children = VerticalStackLayout.Children;

            foreach (var child in children)
                if (child is Entry entryChild)
                    playerNames.Add(entryChild.Text);

            Navigation.PushAsync(new MainCounterPage(playerNames));
        }

        private void ScaleLayout()
        {
            if (ScaleManager.CurrentManager!.IsDefault)
            {
                VerticalStackLayout.Spacing = 25.0;
                VerticalStackLayout.Padding = new Thickness(100.0, 25.0);

                Label.FontSize = 30.0;
                Label.WidthRequest = 300.0;
            }
            else
            {
                var verticalScale = ScaleManager.CurrentManager.HeightScale;
                var horizontalScale = ScaleManager.CurrentManager.WidthScale;
                var smallestScale = ScaleManager.CurrentManager.SmallerScale;

                VerticalStackLayout.Spacing = 25.0 * verticalScale;
                VerticalStackLayout.Padding = new Thickness(100.0 * horizontalScale, 25.0 * verticalScale);

                Label.FontSize = 30.0 * smallestScale;
                Label.WidthRequest = 300.0 * horizontalScale;
            }
        }

        #endregion

    }
}