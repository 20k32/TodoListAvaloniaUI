using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ToDoList_AvaloniaUI.ViewModels.CustomControlsViewModels;

namespace ToDoList_AvaloniaUI
{
    public record TodoItemDTO(string Text);

    internal static class SerializationHelper
    {
        private const string FILE_NAME = "YourNotes.json";

        public static async Task SaveItemsAsync(IEnumerable<ToDoItemVM> item)
        {
            var items = item.Select(x => new TodoItemDTO(x.InnerText));
            
            var result = JsonSerializer.Serialize(items, options: new()
            {
                WriteIndented = true,
            });

            await File.WriteAllTextAsync(FILE_NAME, result);
        }

        public static ObservableCollection<ToDoItemVM> LoadItems()
        {
            var text = File.ReadAllText(FILE_NAME);

            if(text != string.Empty)
            {
                var collection =
                JsonSerializer.Deserialize<IEnumerable<TodoItemDTO>>(text);

                if (collection is not null)
                {
                    var list = collection
                        .Select(x => new ToDoItemVM(x.Text))
                        .ToList();

                    return new ObservableCollection<ToDoItemVM>(list);
                }
            }
            
            return new ObservableCollection<ToDoItemVM>();
        }
    }
}
