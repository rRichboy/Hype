using System;
using System.Diagnostics.SymbolStore;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Styling;
using HarfBuzzSharp;
using Hype.ViewModels;

namespace Hype.Views;

public partial class MainWindow : Window
{
    private MainWindowViewModel viewModel;

    public MainWindow()
    {
        InitializeComponent();
        viewModel = new MainWindowViewModel();
        DataContext = viewModel;
    }

    //Смена темы
    private void ToggleButton_OnIsCheckedChanged(object? sender, RoutedEventArgs e)
    {
        RequestedThemeVariant = (bool)(sender as ToggleSwitch).IsChecked ? ThemeVariant.Dark : ThemeVariant.Light;
    }

    //Выход с проги, если слайдер = 100
    private void RangeBase_OnValueChanged(object? sender, RangeBaseValueChangedEventArgs e)
    {
        var slider = (Slider)sender;
        if (slider.Value == 100)
        {
            Environment.Exit(0);
        }
    }

    //Написать заметку на выбранное число
    private void WriteNote_OnClick(object? sender, RoutedEventArgs e)
    {
        Notes.IsVisible = true;
        Notes.IsSelected = true;
    }

    //Сохранить заметку
    public void SaveNote_OnClick(object? sender, RoutedEventArgs e)
    {
        viewModel.SaveNote(noteTextBox);
    }
}

