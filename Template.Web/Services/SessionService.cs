using System.Web;

namespace Template.Web.Services
{
    public class SessionService
    {
        public SessionService()
        {
        }
        public void SetSession(string key, object value)
        {
            HttpContext.Current.Session[key] = value;
        }
        public object GetSession(string key)
        {
            return HttpContext.Current.Session[key];
        }
        public void RemoveSession(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }
        public void ClearSession()
        {
            HttpContext.Current.Session.Clear();
        }
    }

}