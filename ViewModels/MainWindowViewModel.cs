using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Controls.Primitives;
using Hype.Models;

namespace Hype.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public TextBox NoteTextBox;
    public static ObservableCollection<Note> Notes { get; set; }
    
    
    public MainWindowViewModel()
    {
        Notes = new ObservableCollection<Note>();
    }

    //Метод сохранения заметки
    public void SaveNote(TextBox noteTextBox)
    {
        Notes.Add(new Note { Dates = DateTime.Today, NoteText = noteTextBox.Text });
        noteTextBox.Text = string.Empty;
    }
}
