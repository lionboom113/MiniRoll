using Template.Domain.Exceptions;
using Template.Domain.Services;
using Template.Web.Exceptions;

namespace Template.Web.Models
{
    public class ErrorModel
    {
        /// <summary>
        /// エラーコード
        /// </summary>
        public string ErrorCode { get; set; }
        /// <summary>
        /// エラーメッセージ
        /// </summary>
        public string ErrorMessage { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; } = "Index";

        public static ErrorModel Create(MessageService messageSvc, TemplateValidationException ex)
        {
            ErrorModel model = null;
            if (ex != null)
            {
                model = new ErrorModel
                {
                    ErrorCode = Definitions.Error.DB_VALID_ERROR_CODE,
                    ErrorMessage = ex.Detail,
                };
            }
            return model;
        }

        public static ErrorModel Create(MessageService messageSvc, TemplateAuthorizeException ex)
        {
            ErrorModel model = null;
            var message = messageSvc.GetMessage(Definitions.Error.AUTHORIZE_ERROR_CODE);
            if (ex != null)
            {
                model = new ErrorModel
                {
                    ErrorCode = Definitions.Error.AUTHORIZE_ERROR_CODE,
                    ErrorMessage = message,
                    Controller = Definitions.Auth.AUTH_CONTROLLER,
                    Action = Definitions.Auth.LOGIN_ACTION,
                };
            }
            return model;
        }
    }
}