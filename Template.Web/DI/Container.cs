using Microsoft.AspNet.Identity;
using Microsoft.Practices.Unity;
using System;
using System.Web.Mvc;
using Template.Domain.Entities;
using Template.Web.Auth;
using Template.Web.Services;
using Unity.Mvc5;

namespace Template.Web.DI
{
    /// <summary>
    /// <para>要求単位でオブジェクトを管理するコンテナ</para>
    /// <para>基本的にはコンストラクタでInjectionされる為不要だと考えるが、念のため定義しておく</para>
    /// </summary>
    public static class Container
    {
        public static T Resolve<T>()
        {
            return DependencyResolver.Current.GetService<T>();
        }

        public static void Initialize()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        }

        private static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IAuthService, TemplateAuthService>();
            container.RegisterType<IUserStore<User, Guid>, TemplateUserStore>();
        }
    }
}