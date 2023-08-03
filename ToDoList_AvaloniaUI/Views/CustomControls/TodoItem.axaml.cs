using Avalonia;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using ToDoList_AvaloniaUI.ViewModels.CustomControlsViewModels;

namespace ToDoList_AvaloniaUI.Views.CustomControls
{
    public partial class TodoItem : UserControl
    {
        public ToDoItemVM dataContext = null!;

        public TodoItem()
        {
            InitializeComponent();
            DataContext = dataContext;
        }
    }
}
