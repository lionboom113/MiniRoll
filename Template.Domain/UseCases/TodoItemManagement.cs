using Microsoft.Practices.Unity;
using System.Linq;
using Template.Domain.Orm;
using Template.Domain.Definitions;
using Template.Domain.Exceptions;
using Template.Domain.Models;

namespace Template.Domain.UseCases
{
    /// <summary>
    /// <para>TodoItemの管理を表すユースケース.</para>
    /// </summary>
    public class TodoItemManagement
    {
        public TemplateDbContext DbContext { get; set; }

        public TodoItemManagement(TemplateDbContext dbContext)
        {
            DbContext = dbContext;
        }

        /// <summary>
        /// 全データ取得処理
        /// </summary>
        /// <returns></returns>
        public TodoItemListModel GetTodoItemList()
        {
            return TodoItemListModel.Create(DbContext.TodoItems.ToList());
        }

        /// <summary>
        /// <para>TodoItemの新規データを作成します.</para>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TodoItemCreateResultModel CreateTodoItem(CreateTodoItemModel model)
        {
            CreateResult result = CreateResult.Success;
            ValidationErrors validErrors = ValidationErrors.Create();
            try
            {
                var todoItem = model.CreateTodoItem();
                DbContext.TodoItems.Add(todoItem);
                DbContext.SaveChanges();
            }
            catch(TemplateValidationException e)
            {
                result = CreateResult.ValidError;
                validErrors = e.ValidErrors;
            }
            catch
            {
                result = CreateResult.Failed;
            }
            return TodoItemCreateResultModel.Create(model, result, validErrors);
        }

        /// <summary>
        /// <para>TodoItemのデータを更新します.</para>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TodoItemUpdateResultModel UpdateTodoItem(UpdateTodoItemModel model)
        {
            UpdateResult result = UpdateResult.Success;
            ValidationErrors validErrors = ValidationErrors.Create();
            try
            {
                var todoItem = DbContext.TodoItems.FirstOrDefault(e => e.Id == model.Id);
                if (todoItem == null)
                {
                    result = UpdateResult.NotExist;
                }
                else
                {
                    model.ReflectTodoItem(todoItem);
                    DbContext.SaveChanges();
                }
            }
            catch (TemplateValidationException e)
            {
                result = UpdateResult.ValidError;
                validErrors = e.ValidErrors;
            }
            catch
            {
                result = UpdateResult.Failed;
            }
            return TodoItemUpdateResultModel.Create(model, result, validErrors);
        }

        /// <summary>
        /// <para>TodoItemのデータを削除します.</para>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TodoItemDeleteResultModel DeleteTodoItem(DeleteTodoItemModel model)
        {
            DeleteResult result = DeleteResult.Success;
            try
            {
                var todoItem = DbContext.TodoItems.FirstOrDefault(e => e.Id == model.Id);
                if (todoItem == null)
                {
                    result = DeleteResult.NotExist;
                }
                else
                {
                    DbContext.TodoItems.Remove(todoItem);
                    DbContext.SaveChanges();
                }
            }
            catch
            {
                result = DeleteResult.Failed;
            }
            return TodoItemDeleteResultModel.Create(model, result);
        }
    }
}
