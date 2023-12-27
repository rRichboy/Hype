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
    
    private DateTime selectedDate = DateTime.Now;

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

    //Сохранить заметку с выбранным числом на календаре
    private void SaveNote_OnClick(object? sender, RoutedEventArgs e)
    {
        if (calendar.SelectedDates.Count > 0)
        {
            selectedDate = calendar.SelectedDates[0];
        }
        else
        {
            selectedDate = DateTime.Now;
        }

        viewModel.SaveNote(noteTextBox, notesDataGrid, selectedDate, ErrorNotes);
        
        calendar.SelectedDates.Clear(); 
        selectedDate = DateTime.Now;
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
    
    //Изменить цвет Дата Грид на Кораловый
    private void ChangeColorDG_Coral_OnClick(object? sender, RoutedEventArgs e)
    { 
        viewModel.ChangeColorDGCoral(notesDataGrid);
        notesDataGrid.SelectedItem = null;
    }
}