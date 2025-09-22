using Avalonia.Controls;
using Avalonia.Interactivity;
using MsBox.Avalonia;

namespace Staria.Views;

public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();
        FileManager.ChangeStariaDirectoryPath("/Users/yaroslav/IGuessTEMP/Staria/Profiles");
    }

    private void LetsStartButtonOnClick(object? sender, RoutedEventArgs e)
    {
        var name = NameTextBox.Text ?? "";
        var password = PasswordTextBox.Text ?? "";
        
        var isSigningIn = SignInButton.IsChecked ?? false;
        var isSigningUp = SignUpButton.IsChecked ?? false;

        if (isSigningIn)
        {
            FileManager.TryToLoadProfile(name, password);
            if (FileManager.IsLoaded)
            {
                Hide();
                new MainWindow().Show();
            }
            FileManager.IsLoaded = false;
        }
        if (isSigningUp)
        {
            FileManager.AddProfile(name, password);
        }
    }
}