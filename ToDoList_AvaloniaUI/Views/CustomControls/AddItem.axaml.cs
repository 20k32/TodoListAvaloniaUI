using Avalonia.Controls;
using Avalonia.Interactivity;

namespace ToDoList_AvaloniaUI.Views.CustomControls
{
    public partial class AddItem : Window
    {
        public AddItem()
        {
            InitializeComponent();

            NoteTextBox.AttachedToVisualTree +=
                (_, _) => NoteTextBox.Focus();
        }

        public void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Close(NoteTextBox.Text);
        }
    }
}
