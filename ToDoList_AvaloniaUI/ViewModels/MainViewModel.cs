using Avalonia.Controls;
using System.Linq;
using ToDoList_AvaloniaUI.ViewModels.CustomControlsViewModels;

namespace ToDoList_AvaloniaUI.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public MainPanelVM Context { get; set; } = null!;

    public MainViewModel(Window window)
    {
        Context = new(
            new(Enumerable.Range(1, 15)
                .Select(
                    x => new ToDoItemVM(x.ToString()))),
            window);

    }
}
