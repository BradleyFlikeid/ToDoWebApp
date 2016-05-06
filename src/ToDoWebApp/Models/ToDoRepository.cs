using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ToDoWebApp.Models
{
    public class ToDoRepository : IToDoRepository
    {
        static ConcurrentDictionary<string, ToDo> _toDo = new ConcurrentDictionary<string, ToDo>();

        public ToDoRepository()
        {
            Add(new ToDo { Name = "Be like Rausch." });
        }

        public IEnumerable<ToDo> GetAll()
        {
            return _toDo.Values;
        }

        public void Add(ToDo item)
        {
            item.Key = Guid.NewGuid().ToString();
            _toDo[item.Key] = item;
        }

        public ToDo Find(string key)
        {
            ToDo item;
            _toDo.TryGetValue(key, out item);
            return item;
        }

        public ToDo Remove(string key)
        {
            ToDo item;
            _toDo.TryGetValue(key, out item);
            _toDo.TryRemove(key, out item);
            return item;
        }

        public void Update(ToDo item)
        {
            _toDo[item.Key] = item;
        }
    }
}
