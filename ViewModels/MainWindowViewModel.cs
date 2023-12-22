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
    
    public MainWindowViewModel()
    {
        Notes = new ObservableCollection<Note>();
    }

    //Метод сохранения заметки
    public void SaveNote(TextBox noteTextBox, DataGrid notesDataGrid)
    {
        Notes.Add(new Note { Dates = DateTime.Now, NoteText = noteTextBox.Text });
        noteTextBox.Text = string.Empty;
        
        notesDataGrid.ItemsSource = null;
        notesDataGrid.ItemsSource = Notes;
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
    public void ChangeColorDGKhaki(DataGrid notesDataGrid)
    {
        notesDataGrid.RowBackground = Brushes.Khaki;
    }
    
    //Изменение цвета Даты Грид
    public void ChangeColorDGLavanda(DataGrid notesDataGrid)
    {
        notesDataGrid.RowBackground = Brushes.LavenderBlush;
    }
    
    //Изменение цвета Даты Грид
    public void ChangeColorDGCoral(DataGrid notesDataGrid)
    {
        notesDataGrid.RowBackground = Brushes.Coral;
    }
}
