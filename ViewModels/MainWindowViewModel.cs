using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Controls.Notifications;
using Hype.Models;

namespace Hype.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public static ObservableCollection<Note> Notes { get; set; }
    
    
    public MainWindowViewModel()
    {
        Notes = new ObservableCollection<Note>();

        Notes.Add(new Note { Dates = DateTime.Now, NoteText = "Ваш текст заметки" });

    }
    
}
