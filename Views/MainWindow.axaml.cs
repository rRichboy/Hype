using System;
using System.Collections.ObjectModel;
using System.Diagnostics.SymbolStore;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Styling;
using HarfBuzzSharp;
using Hype.Models;
using Hype.ViewModels;
using System.Linq;


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
        viewModel.SaveNote(noteTextBox, notesDataGrid);
    }

    //Изменить заметку
    private void ChangeNote_OnClick(object? sender, RoutedEventArgs e)
    {
        notesDataGrid.IsReadOnly = false;
    }

    //Сохранить измененную заметку
    private void SaveChangeNote_OnClick(object? sender, RoutedEventArgs e)
    {
        notesDataGrid.IsReadOnly = true;
    }

    //Удалить выбранную заметку
    private void DeleteNote_OnClick(object? sender, RoutedEventArgs e)
    {
        viewModel.DeleteNote(notesDataGrid);
    }
    
    //Найти заметку
    private void SearchTextBox_OnKeyUp(object sender, KeyEventArgs e)
    {
        var filteredNotes = viewModel.SearchTextBox(searchTextBox);
        notesDataGrid.ItemsSource = filteredNotes;
    }

    //Изменить цвет
    private void ChangeColorDG_Khaki_OnClick(object? sender, RoutedEventArgs e)
    { 
        viewModel.ChangeColorDGKhaki(notesDataGrid);
    }
    
    //Изменить цвет
    private void ChangeColorDG_Lavanda_OnClick(object? sender, RoutedEventArgs e)
    { 
        viewModel.ChangeColorDGLavanda(notesDataGrid);
    }
    
    //Изменить цвет
    private void ChangeColorDG_Coral_OnClick(object? sender, RoutedEventArgs e)
    { 
        viewModel.ChangeColorDGCoral(notesDataGrid);
    }
}