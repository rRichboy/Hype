using System;
using System.Diagnostics.SymbolStore;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Styling;
using HarfBuzzSharp;

namespace Hype.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ToggleButton_OnIsCheckedChanged(object? sender, RoutedEventArgs e)
    {
        RequestedThemeVariant = (bool)(sender as ToggleSwitch).IsChecked ? ThemeVariant.Dark : ThemeVariant.Light;
    }

    private void RangeBase_OnValueChanged(object? sender, RangeBaseValueChangedEventArgs e)
    {
        
        var slider = (Slider)sender;
        
        if (slider.Value == 100)
        {
            Environment.Exit(0);
        }

    }
}
