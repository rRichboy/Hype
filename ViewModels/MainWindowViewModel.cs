using System.Collections.Generic;
using Avalonia.Controls.Notifications;
using Hype.Models;

namespace Hype.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private List<User> Users { get; set; }
}
