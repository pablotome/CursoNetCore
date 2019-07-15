using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Services
{
    public class FakeTodoService : ITodoItemService
    {
        public Task<TodoItem[]> GetIncompleteItemsAsync()
        {
            // Get to-do items from database
            var item1 = new TodoItem
            {
                Title = "Curso ASP.NET Core",
                DueAt = DateTimeOffset.Now.AddDays(1)
            };
            var item2 = new TodoItem
            {
                Title = "Curso React",
                DueAt = DateTimeOffset.Now.AddDays(2)
            };
            var item3 = new TodoItem
            {
                Title = "Curso ASP.NET Web API",
                DueAt = DateTimeOffset.Now.AddDays(3)
            };
            return Task.FromResult(new[] { item1, item2, item3 });
            // Put items into a model
        }
    }
}