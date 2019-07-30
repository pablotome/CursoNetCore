using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTodo.Data;
using AspNetCoreTodo.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreTodo.Services
{
    public class TodoItemService: ITodoItemService
    {
        private readonly ApplicationDbContext _context;

        public TodoItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddItemAsync(TodoItem item)
        {
            item.Id = Guid.NewGuid();
            item.IsDone = false;
            _context.Items.Add(item);

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }

        public async Task<TodoItem[]> GetIncompleteItemsAsync()
        {
            return await _context.Items
                .Where(x => !x.IsDone)
                .ToArrayAsync();
        }

        public async Task<bool> MarkDoneAsync(Guid id)
        {
            var item = await _context.Items
                .FirstOrDefaultAsync(x => x.Id == id);
            
            if (item == null) return false;
            
            item.IsDone = true;

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}
