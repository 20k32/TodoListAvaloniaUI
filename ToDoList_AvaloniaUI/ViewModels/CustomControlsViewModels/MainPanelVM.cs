using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoList_AvaloniaUI.Views.CustomControls;

namespace ToDoList_AvaloniaUI.ViewModels.CustomControlsViewModels
{
    public class MainPanelVM : ViewModelBase
    {
        private Window ownerWindow = null!;

        public ObservableCollection<ToDoItemVM> ToDoItems { get; set; } = null!;

        private ICommand addToItems = null!;

        public ICommand AddToItems => 
            addToItems ??= new RelayCommand(
                execute: Add!,
                canExecute: () => ToDoItems != null);

        private async void Add()
        {
            var result = await new AddItem().ShowDialog<string>(ownerWindow);
            
            if (string.IsNullOrWhiteSpace(result))
            {
                return;
            }
            
            result = Regex.Replace(result, @"(\s\s)+", " ");

            var item = new ToDoItemVM(result, removeItem);

            ToDoItems.Add(item);
        }

        private ICommand removeItem = null!;

        public ICommand RemoveItem 
            => removeItem ??= new RelayCommand<ToDoItemVM>(MarkForDeletion!);

        private async void MarkForDeletion(ToDoItemVM item)
        {
            if (!item.IsChecked)
            {
                return;
            }

            await Task.Delay(2000);

            if (item.IsChecked) 
            {
                ToDoItems.Remove(item);
            }
        }

        public MainPanelVM(ObservableCollection<ToDoItemVM> items, Window Owner)
        {
            foreach (var item in items)
            {
                if (item.DeleteCommand is null)
                {
                    item.DeleteCommand = RemoveItem;
                }
            }

            ToDoItems = items;
            ownerWindow = Owner;
        }
    }
}
