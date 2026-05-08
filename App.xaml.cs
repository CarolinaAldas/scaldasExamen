using scaldasExamen.Views;

namespace scaldasExamen;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new NavigationPage(new LoginPage())
        {
            BarBackgroundColor = Color.FromArgb("#5C2D91"),
            BarTextColor = Colors.White
        };
    }
}