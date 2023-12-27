using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using Hype.Models;

namespace Hype.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public static ObservableCollection<Note> Notes { get; set; }
    // public string OSInfo => $"Версия: {System.Environment.OSVersion}";
    // public string ProcessorArchitecture => $"Архитектура процессора: {(System.Environment.Is64BitOperatingSystem ? "64-битная" : "32-битная")}";
    // public string ProcessorCount => $"Количество процессоров: {System.Environment.ProcessorCount}";
    // public string MachineName => $"Имя устройства: {System.Environment.MachineName}";
    // public string UserName => $"Имя пользователя: {System.Environment.UserName}";
    
    public MainWindowViewModel()
    {
        Notes = new ObservableCollection<Note>();
    }

    //Метод сохранения заметки с выбранной дато или просто с нынешней
    public void SaveNote(TextBox noteTextBox, DataGrid notesDataGrid, DateTime selectedDate, TextBlock ErrorNotes)
    {
        if (string.IsNullOrEmpty(noteTextBox.Text))
        {
            ErrorNotes.Text = "Вы не написали заметку!";
        }
        else
        {
            ErrorNotes.Text = string.Empty;

            Notes.Add(new Note { Dates = selectedDate, NoteText = noteTextBox.Text });
            noteTextBox.Text = string.Empty;

            notesDataGrid.ItemsSource = null;
            notesDataGrid.ItemsSource = Notes;
        }
    }

    
    //Удалить заметку
    public void DeleteNote(DataGrid notesDataGrid)
    {
        var selectedNote = notesDataGrid.SelectedItem as Note;

        if (selectedNote != null)
        {
            Notes.Remove(selectedNote);
            
            notesDataGrid.ItemsSource = null;
            notesDataGrid.ItemsSource = Notes;
        }
    }
    
    //Метод поиска заметки
    public ObservableCollection<Note> SearchTextBox(TextBox searchTextBox)
    {
        string searchQuery = searchTextBox.Text;

        //Поиск заметки по введенному слову
        var filteredNotes = new ObservableCollection<Note>(Notes.Where(note => note.NoteText.Contains(searchQuery)));

        return filteredNotes;
    }
    
    //Изменение цвета Даты Грид
    public void ChangeColorDGCorall(DataGrid notesDataGrid)
    {
        notesDataGrid.RowBackground = Brushes.Coral;
    }
}
