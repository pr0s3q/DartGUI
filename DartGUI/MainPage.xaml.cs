namespace DartGUI;

public partial class MainPage
{
    public MainPage()
    {
        InitializeComponent();
        Entry.BackgroundColor = DesignColors.ENTRY_BACKGROUND_COLOR;
        Entry.TextColor = DesignColors.ENTRY_TEXT_COLOR;
        ContentPage.BackgroundColor = DesignColors.BACKGROUND_COLOR;
        Label.TextColor = DesignColors.LABEL_TEXT_COLOR;
        Button.BackgroundColor = DesignColors.BUTTON_BACKGROUND_COLOR;
        Button.TextColor = DesignColors.BUTTON_TEXT_COLOR;
    }

    private void Button_OnClicked(object sender, EventArgs e)
    {
        if(int.TryParse(Entry.Text, out var noOfPlayers) && noOfPlayers is > 0 and <= 5)
            //Navigation.PushAsync(new MainCounterPage(new List<string> { "player 1", "player 2", "player 3", "player 4", "player 5" }));
            Navigation.PushAsync(new PlayerNamesPage(noOfPlayers));
    }
}

