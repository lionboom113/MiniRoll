using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Template.Domain.Entities;
using Template.Domain.Definitions;

namespace Template.Domain.Models
{
    public class TodoItemListModel
    {
        public List<TodoItemModel> TodoItems { get; set; } = new List<TodoItemModel>();

        public static TodoItemListModel Create(ICollection<TodoItem> todoItems)
        {
            return new TodoItemListModel
            {
                TodoItems = todoItems?.Select(e => TodoItemModel.Create(e)).ToList() ?? new List<TodoItemModel>(),
            };
        }
    }

    public class TodoItemModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public static TodoItemModel Create(TodoItem model)
        {
            return new TodoItemModel
            {
                Id = model.Id,
                Name = model.Name,
            };
        }
    }

    public class CreateTodoItemModel
    {
        [Required]
        public string Name { get; set; }

        public TodoItem CreateTodoItem()
        {
            return new TodoItem
            {
                Name = Name,
            };
        }
    }
    public class TodoItemCreateResultModel
    {
        public string Name { get; set; }
        public CreateResult Result { get; set; }
        public ValidationErrors ValidErrors { get; set; }

        public static TodoItemCreateResultModel Create(CreateTodoItemModel model, CreateResult result, ValidationErrors validErrors = null)
        {
            return new TodoItemCreateResultModel
            {
                Name = model.Name,
                Result = result,
                ValidErrors = validErrors ?? ValidationErrors.Create(),
            };
        }
    }

    public class UpdateTodoItemModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// <para>現在のインスタンスの状態をTodoItemに反映します.</para>
        /// </summary>
        /// <param name="todoItem"></param>
        /// <returns></returns>
        public TodoItem ReflectTodoItem(TodoItem todoItem)
        {
            todoItem.Name = Name;
            return todoItem;
        }
    }

    public class TodoItemUpdateResultModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public UpdateResult Result { get; set; }
        public ValidationErrors ValidErrors { get; set; }

        public static TodoItemUpdateResultModel Create(UpdateTodoItemModel model, UpdateResult result, ValidationErrors validErrors = null)
        {
            return new TodoItemUpdateResultModel
            {
                Id = model.Id,
                Name = model.Name,
                Result = result,
                ValidErrors = validErrors ?? ValidationErrors.Create(),
            };
        }
    }

    public class DeleteTodoItemModel
    {
        [Required]
        public Guid Id { get; set; }
    }

    public class TodoItemDeleteResultModel
    {
        public Guid Id { get; set; }

        public DeleteResult Result { get; set; }

        public static TodoItemDeleteResultModel Create(DeleteTodoItemModel model, DeleteResult result)
        {
            return new TodoItemDeleteResultModel
            {
                Id = model.Id,
                Result = result,
            };
        }
    }
}