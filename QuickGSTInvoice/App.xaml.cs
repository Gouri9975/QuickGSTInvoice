using Csla;
using Csla.Configuration;
using QuickGSTInvoice.Services;
using QuickGSTInvoice.Views;
using Application = Microsoft.Maui.Controls.Application;

namespace QuickGSTInvoice
{
    public partial class App : Application
    {
        public static ApplicationContext ApplicationContext { get; private set; }
        public static Csla.IDataPortalFactory DataPortalFactory { get; private set; }
        public App()
        {
            InitializeComponent();
            ConfigureServices();
            DependencyService.Register<MockDataStore>();
            DependencyService.Register<NavigationService>();
            Routing.RegisterRoute(typeof(ItemDetailPage).FullName, typeof(ItemDetailPage));
            Routing.RegisterRoute(typeof(NewItemPage).FullName, typeof(NewItemPage));
          
            MainPage = new MainPage();
        }
        private void ConfigureServices()
        {
            var services = new ServiceCollection();

            // The CSLA configuration here uses an ApplicationContextManager
            // copied from the Csla.Xaml.Shared project, so the same manager
            // used for WPF, UWP, etc.

            // use local data portal
            services.AddCsla(o => o
              .RegisterContextManager<Csla.Xaml.ApplicationContextManager>());
            services.AddTransient(typeof(DataAccess.IPersonDal), typeof(DataAccess.PersonSQLiteDal));

            // use remote data portal (requires an app server
            // that can be reached from your Android emulator)
            //
            //services.AddTransient<System.Net.Http.HttpClient>();
            //services.AddCsla(o => o
            //  .RegisterContextManager<Csla.Xaml.ApplicationContextManager>()
            //  .DataPortal(dpo => dpo
            //    .UseHttpProxy(hpo => hpo
            //      .DataPortalUrl = "http://myserver/api/dataportal")));

            var provider = services.BuildServiceProvider();
            ApplicationContext = provider.GetService<ApplicationContext>();
           var s= DataAccess.PersonSQLiteDal.GetConnection("d");

            //var proxy = provider.GetService<Csla.DataPortalClient.IDataPortalProxy>();
            //var dp = provider.GetService<IDataPortal<BusinessLibrary.PersonList>>();
            //var dp = Csla.Xaml.ApplicationContextManager.GetApplicationContext()
            //  .GetRequiredService<IDataPortal<BusinessLibrary.PersonList>>();
        }

    }
}