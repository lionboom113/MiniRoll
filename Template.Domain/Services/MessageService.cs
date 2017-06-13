using Microsoft.Practices.Unity;
using System;
using System.Linq;
using Template.Domain.Orm;

namespace Template.Domain.Services
{
    public class MessageService
    {
        [Dependency]
        public TemplateDbContext DbContext { get; set; }

        public string GetMessage(Guid id, params string[] args)
        {
            var message = DbContext.Messages.FirstOrDefault(e => e.Id == id)?.Content;
            return !string.IsNullOrEmpty(message) ? string.Format(message, args) : null;
        }

        public string GetMessage(string code, params string[] args)
        {
            var message = DbContext.Messages.FirstOrDefault(e => e.Code == code)?.Content;
            return !string.IsNullOrEmpty(message) ? string.Format(message, args) : null;
        }
    }
}