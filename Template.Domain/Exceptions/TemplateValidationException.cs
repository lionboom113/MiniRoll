using System;
using System.Data.Entity.Validation;
using System.Text;
using Template.Domain.Models;

namespace Template.Domain.Exceptions
{
    /// <summary>
    /// <para>EntityFramework上で発生した検証エラーを表すクラス.</para>   
    /// </summary>
    public class TemplateValidationException : Exception
    {
        /// <summary>
        /// <para>検証エラー格納用.</para>
        /// </summary>
        public ValidationErrors ValidErrors { get; private set; } = ValidationErrors.Create();
        /// <summary>
        /// <para>検証エラーメッセージ.</para>
        /// </summary>
        public string Detail
        {
            get
            {
                StringBuilder buf = new StringBuilder();
                foreach (var warn in ValidErrors)
                {
                    buf.AppendLine($"{warn.Field}：{warn.Message}");
                }
                return buf.ToString();
            }
        }

        public TemplateValidationException() { }

        public TemplateValidationException(DbEntityValidationException e)
        {
            foreach (var eve in e.EntityValidationErrors)
            {
                foreach (var ve in eve.ValidationErrors)
                {
                    ValidErrors.Add(ve.PropertyName, ve.ErrorMessage);
                }
            }
        }
    }
}