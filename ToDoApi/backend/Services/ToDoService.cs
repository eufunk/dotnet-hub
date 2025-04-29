using ToDoApi.Models;

namespace ToDoApi.Services
{
    public class ToDoService
    {
        // Eine in-memory Liste für Demo-Zwecke (kann später durch eine Datenbank ersetzt werden)
        private static List<ToDoItem> _toDoItems =
        [
            new ToDoItem { Id = 1, Name = "Buy groceries", IsCompleted = false },
            new ToDoItem { Id = 2, Name = "Clean the house", IsCompleted = true },
            new ToDoItem { Id = 3, Name = "Finish homework", IsCompleted = false }
        ];

        public List<ToDoItem> GetAll() => _toDoItems;

        public ToDoItem GetById(int id)
        {
            var item = _toDoItems.FirstOrDefault(item => item.Id == id);
            if (item == null)
                throw new Exception("Item not found");
            return item;
        }


        public void Add(ToDoItem item)
        {
            item.Id = _toDoItems.Max(i => i.Id) + 1;
            _toDoItems.Add(item);
        }

        public void Update(int id, ToDoItem updatedItem)
        {
            var existingItem = _toDoItems.FirstOrDefault(item => item.Id == id);
            if (existingItem != null)
            {
                existingItem.Name = updatedItem.Name;
                existingItem.IsCompleted = updatedItem.IsCompleted;
            }
        }

        public void Delete(int id)
        {
            var item = _toDoItems.FirstOrDefault(t => t.Id == id);
            if (item != null)
            {
                _toDoItems.Remove(item);
            }
        }
    }
}
