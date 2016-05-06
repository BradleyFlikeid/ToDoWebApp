using Common.Models;
using System.Collections.Generic;

namespace ToDoWebApp.Models
{
    public interface IToDoRepository
    {
        void Add(ToDo item);
        IEnumerable<ToDo> GetAll();
        ToDo Find(string key);
        ToDo Remove(string key);
        void Update(ToDo item);
    }
}
