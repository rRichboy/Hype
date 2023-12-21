using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Controls.Primitives;
using Hype.Models;

namespace Hype.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public static ObservableCollection<Note> Notes { get; set; }
    
    
    public MainWindowViewModel()
    {
        Notes = new ObservableCollection<Note>();
    }

    //Метод сохранения заметки
    public void SaveNote(TextBox noteTextBox, DataGrid notesDataGrid)
    {
        Notes.Add(new Note { Dates = DateTime.Now, NoteText = noteTextBox.Text });
        noteTextBox.Text = string.Empty;

        // Обновляем DataGrid
        notesDataGrid.ItemsSource = null;
        notesDataGrid.ItemsSource = Notes;
    }
    
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

        // Поиск заметок по введенному слову
        var filteredNotes = new ObservableCollection<Note>(Notes.Where(note => note.NoteText.Contains(searchQuery)));

        return filteredNotes;
    }
}
