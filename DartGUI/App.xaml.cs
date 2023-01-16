namespace DartGUI;

public partial class App : Application
{
   public App()
   {
      InitializeComponent();

      MainPage = new AppShell();
   }
}
