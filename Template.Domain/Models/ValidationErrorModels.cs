using System.Collections;
using System.Collections.Generic;

namespace Template.Domain.Models
{
    public class ValidationErrors : IEnumerable<ValidationError>
    {
        private List<ValidationError> ValidationErrorList { get; set; }

        private ValidationErrors() { }

        public IEnumerator<ValidationError> GetEnumerator()
        {
            return ValidationErrorList.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public ValidationErrors Add(string message)
        {
            ValidationErrorList.Add(new ValidationError { Message = message });
            return this;
        }
        public ValidationErrors Add(string field, string message)
        {
            ValidationErrorList.Add(new ValidationError { Field = field, Message = message });
            return this;
        }

        public ValidationErrors Clear()
        {
            ValidationErrorList.Clear();
            return this;
        }

        public static ValidationErrors Create()
        {
            return new ValidationErrors();
        }
    }

    public class ValidationError
    {
        /// <summary>
        /// <para>検証エラーフィールド名.</para>
        /// </summary>
        public string Field { get; set; }
        /// <summary>
        /// <para>検証エラーメッセージ.</para>
        /// </summary>
        public string Message { get; set; }

    }

}