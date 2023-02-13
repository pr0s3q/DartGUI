﻿namespace DartGUI
{
    public partial class MainPage
    {

        #region Constructors

        public MainPage()
        {
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            InitializeComponent();
            Entry.BackgroundColor = DesignColors.ENTRY_BACKGROUND_COLOR;
            Entry.TextColor = DesignColors.ENTRY_TEXT_COLOR;
            ContentPage.BackgroundColor = DesignColors.BACKGROUND_COLOR;
            DescriptionLabel1.TextColor = DesignColors.LABEL_TEXT_COLOR;
            DescriptionLabel2.TextColor = DesignColors.LABEL_TEXT_COLOR;
            ApplyButton.BackgroundColor = DesignColors.BUTTON_BACKGROUND_COLOR;
            ApplyButton.TextColor = DesignColors.BUTTON_TEXT_COLOR;
            HelpButton.BackgroundColor = DesignColors.BUTTON_BACKGROUND_COLOR;
            HelpButton.TextColor = DesignColors.BUTTON_TEXT_COLOR;
            CopyrightLabel1.TextColor = DesignColors.LABEL_TEXT_COLOR;
            CopyrightLabel2.TextColor = DesignColors.LABEL_TEXT_COLOR;
        }

        #endregion

        #region Events

        private void ApplyButton_OnClicked(object sender, EventArgs e) => NextPage();

        private void HelpButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HelpPage());
        }

        private void Entry_OnCompleted(object? sender, EventArgs e) => NextPage();

        #endregion

        #region Operations

        private void NextPage()
        {
            if (int.TryParse(Entry.Text, out int noOfPlayers) && noOfPlayers is > 0 and <= 5)
                //Navigation.PushAsync(new MainCounterPage(new List<string> { "player 1", "player 2", "player 3", "player 4", "player 5" }));
                Navigation.PushAsync(new PlayerNamesPage(noOfPlayers));
        }

        #endregion

    }
}