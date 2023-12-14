using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Hype.Models;

namespace Hype.Views;

public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();
    }

    private void RegWin_OnClick(object? sender, RoutedEventArgs e)
    {
        RegWindow regWindow = new RegWindow();
        regWindow.Show();
        this.Close();
    }

    private void Login_OnClick(object? sender, RoutedEventArgs e)
    {

        User user = RegWindow.users.FirstOrDefault(u => u.username == username.Text && u.password == password.Text);

        if (user is null)
        {
            BorderError.IsVisible = true;
        }
        else
        {
            new MainWindow().Show();
            this.Close();
        }
    }

    private void ShowPass_OnClick(object? sender, RoutedEventArgs e)
    {
        password.PasswordChar = password.PasswordChar == '*' ? '\0' : '*';
    }
}