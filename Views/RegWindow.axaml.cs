using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Hype.Models;

namespace Hype.Views;

public partial class RegWindow : Window
{
    public static List<User> users = new List<User>();
    public RegWindow()
    {
        InitializeComponent();
    }
    
    private void Reg_OnClick(object? sender, RoutedEventArgs e)
    {
        username1.Text = string.Empty;
        password1.Text = string.Empty;
        CheckBox1.Text = string.Empty;

        if (string.IsNullOrEmpty(username.Text))
        {
            username1.Text = "Обязательно к заполнению.";
        }

        if (string.IsNullOrEmpty(password.Text))
        {
            password1.Text = "Обязательно к заполнению.";
        }
        else if (password.Text.Length < 6)
        {
            password1.Text = "Слабый пароль.";
        }

        if (CheckBox.IsChecked == null || CheckBox.IsChecked == false)
        {
            CheckBox1.Text = "Обязательно к заполнению.";
        }
        
        if (!string.IsNullOrEmpty(username1.Text) || !string.IsNullOrEmpty(password1.Text) || !string.IsNullOrEmpty(CheckBox1.Text))
        {
            return;
        }

        User user = new(username.Text, password.Text);
        users.Add(user);
        
        LoginWindow loginWindow = new LoginWindow();
        loginWindow.Show();
        this.Close();
        
    }
    
    private void Login_OnClick(object? sender, RoutedEventArgs e)
    {
        LoginWindow loginWindow = new LoginWindow();
        loginWindow.Show();
        this.Close();
    }
}