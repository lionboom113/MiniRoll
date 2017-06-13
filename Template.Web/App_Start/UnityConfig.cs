using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Template.Web.DI;

namespace Template.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            DI.Container.Initialize();
        }
    }
}