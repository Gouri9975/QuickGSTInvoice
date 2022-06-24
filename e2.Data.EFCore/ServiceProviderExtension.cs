//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace e2.Data.EFCore
//{
//    public static class ServiceProviderCslaExtensions
//    {

//        public static void SetDefaultServiceProvider(this IServiceProvider serviceProvider)
//        {
//            global::Csla.ApplicationContext.GlobalContext.SetServiceProvider(serviceProvider);
//        }

//        public static void SetCurrentScopeServiceProvider(this IServiceProvider serviceProvider)
//        {
//            global::Csla.ApplicationContext.LocalContext.SetServiceProvider(serviceProvider);
//        }

//        /// <summary>
//        /// Returns the local csla service provider if available, but falls back to the global csla service provider if not. Also checks for an active HttpRequest
//        /// and uses HttpContext.RequestServices if found.
//        /// </summary>
//        /// <returns></returns>
//        public static IServiceProvider GetServiceProviderForCurrentScope()
//        {
//            // check local first, then fallback to global.
//            IServiceProvider sp = null;
//            sp = global::Csla.ApplicationContext.LocalContext.GetServiceProvider();
//            if (sp == null)
//            {
//                sp = global::Csla.ApplicationContext.GlobalContext.GetServiceProvider();
//            }
//            return sp;
//        }

//        /// <summary>
//        /// Anti pattern necessary to achieve DI in some places in CSLA framework.
//        /// </summary>
//        public static TService Locate<TService>()
//        {
//            var sp = GetServiceProviderForCurrentScope();
//            var implementation = sp.GetService<TService>();
//            return implementation;
//        }
//    }
//}
