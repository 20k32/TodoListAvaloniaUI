using System.Windows.Input;

namespace ToDoList_AvaloniaUI.ViewModels.CustomControlsViewModels
{
    public class ToDoItemVM : ViewModelBase
    {
        private string innerText = null!;

        public string InnerText
        {
            get => innerText;
            set
            {
                innerText = value;
                SetProperty(ref innerText, value);
            }
        }

        private bool isChecked;

        public bool IsChecked
        {
            get => isChecked;
            set
            {
                isChecked = value;
                SetProperty(ref isChecked, value);
            }
        }

        public ICommand DeleteCommand { get; set; } = null!;

        public ToDoItemVM() 
        { }

        public ToDoItemVM(string text, ICommand deleteCommand)
        {
            DeleteCommand = deleteCommand;
            InnerText = text;
        }

        public ToDoItemVM(string text) : this(text, null!)
        { }
    }
}
