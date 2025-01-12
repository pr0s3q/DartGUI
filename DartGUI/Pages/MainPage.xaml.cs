using DartGUI.Database;
using DartGUI.Games;
using DartGUI.Helpers;
using DartGUI.Managers;

namespace DartGUI.Pages
{
    public partial class MainPage
    {

        #region Constructors

        public MainPage()
        {
            InitializeComponent();

            Entry.BackgroundColor = DesignColors.ENTRY_BACKGROUND_COLOR;
            Entry.TextColor = DesignColors.ENTRY_TEXT_COLOR;

            ContentPage.BackgroundColor = DesignColors.BACKGROUND_COLOR;

            DescriptionLabel1.TextColor = DesignColors.LABEL_TEXT_COLOR;
            DescriptionLabel2.TextColor = DesignColors.LABEL_TEXT_COLOR;

            ApplyButton.BackgroundColor = DesignColors.BUTTON_BACKGROUND_COLOR;
            ApplyButton.TextColor = DesignColors.BUTTON_TEXT_COLOR;
            ApplyButton.Pressed += GlobalEvents.OnButton_Pressed;
            ApplyButton.Released += GlobalEvents.OnButton_Released;

            HelpButton.BackgroundColor = DesignColors.BUTTON_BACKGROUND_COLOR;
            HelpButton.TextColor = DesignColors.BUTTON_TEXT_COLOR;
            HelpButton.Pressed += GlobalEvents.OnButton_Pressed;
            HelpButton.Released += GlobalEvents.OnButton_Released;

            LoadGame.BackgroundColor = DesignColors.BUTTON_BACKGROUND_COLOR;
            LoadGame.TextColor = DesignColors.BUTTON_TEXT_COLOR;
            LoadGame.Pressed += GlobalEvents.OnButton_Pressed;
            LoadGame.Released += GlobalEvents.OnButton_Released;

            CopyrightLabel1.TextColor = DesignColors.LABEL_TEXT_COLOR;
            CopyrightLabel2.TextColor = DesignColors.LABEL_TEXT_COLOR;

            ScaleLayout();
        }

        #endregion

        #region Events

        private void ApplyButton_OnClicked(object sender, EventArgs e) => NextPage();

        private void HelpButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HelpPage());
        }

        private void Entry_OnCompleted(object? sender, EventArgs e) => NextPage();

        private void LoadGame_OnClicked(object? sender, EventArgs e)
        {
            if (MemoryDatabase.GetLastGameIfExist(out Game? game))
                Navigation.PushAsync(new MainCounterPage(game!));
        }

        #endregion

        #region Operations

        private void NextPage()
        {
            if (int.TryParse(Entry.Text, out int noOfPlayers) && noOfPlayers is > 0 and <= 5)
                //Navigation.PushAsync(new MainCounterPage(new List<string> { "player 1", "player 2", "player 3", "player 4", "player 5" }));
                Navigation.PushAsync(new PlayerNamesPage(noOfPlayers));
        }

        private void ScaleLayout()
        {
            if (ScaleManager.CurrentManager!.IsDefault)
            {
                MainVerticalStackLayout.Padding = new Thickness(100.0, 0.0);

                DescriptionLabel1.FontSize = 30.0;
                DescriptionLabel1.Margin = new Thickness(0.0, 25.0, 0.0, 0.0);

                DescriptionLabel2.FontSize = 30.0;
                DescriptionLabel2.Margin = new Thickness(0.0, 0.0, 0.0, 15.0);

                Entry.FontSize = 25.0;
                Entry.Margin = new Thickness(0.0, 10.0, 0.0, 15.0);
                Entry.WidthRequest = 300.0;

                ApplyButton.FontSize = 30.0;
                ApplyButton.Margin = new Thickness(0.0, 10.0, 0.0, 0.0);
                ApplyButton.WidthRequest = 200.0;

                HelpButton.FontSize = 30.0;
                HelpButton.Margin = new Thickness(0.0, 10.0, 0.0, 0.0);
                HelpButton.WidthRequest = 200.0;

                LoadGame.FontSize = 30.0;
                LoadGame.Margin = new Thickness(0.0, 10.0, 0.0, 25.0);
                LoadGame.WidthRequest = 200.0;

                CopyrightLabel1.Margin = new Thickness(0.0, 30.0, 0.0, 0.0);
            }
            else
            {
                var verticalScale = ScaleManager.CurrentManager.HeightScale;
                var horizontalScale = ScaleManager.CurrentManager.WidthScale;
                var smallestScale = ScaleManager.CurrentManager.SmallerScale;

                MainVerticalStackLayout.Padding = new Thickness(100.0 * verticalScale, 0.0);

                DescriptionLabel1.FontSize = 30.0 * smallestScale;
                DescriptionLabel1.Margin = new Thickness(0.0, 25.0 * verticalScale, 0.0, 0.0);

                DescriptionLabel2.FontSize = 30.0 * smallestScale;
                DescriptionLabel2.Margin = new Thickness(0.0, 0.0, 0.0, 15.0 * verticalScale);

                Entry.FontSize = 25.0 * smallestScale;
                Entry.Margin = new Thickness(0.0, 10.0 * verticalScale, 0.0, 15.0 * verticalScale);
                Entry.WidthRequest = 300.0 * horizontalScale;

                ApplyButton.FontSize = 30.0 * smallestScale;
                ApplyButton.Margin = new Thickness(0.0, 10.0 * verticalScale, 0.0, 0.0);
                ApplyButton.WidthRequest = 200.0 * horizontalScale;

                HelpButton.FontSize = 30.0 * smallestScale;
                HelpButton.Margin = new Thickness(0.0, 10.0 * verticalScale, 0.0, 0.0);
                HelpButton.WidthRequest = 200.0 * horizontalScale;

                LoadGame.FontSize = 30.0 * smallestScale;
                LoadGame.Margin = new Thickness(0.0, 10.0 * verticalScale, 0.0, 25.0 * verticalScale);
                LoadGame.WidthRequest = 200.0 * horizontalScale;

                CopyrightLabel1.Margin = new Thickness(0.0, 30.0 * verticalScale, 0.0, 0.0);
                CopyrightLabel1.FontSize *= smallestScale;

                CopyrightLabel2.FontSize *= smallestScale;
            }
        }

        #endregion
    }
}
