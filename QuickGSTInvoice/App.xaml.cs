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

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<NavigationService>();
            Routing.RegisterRoute(typeof(ItemDetailPage).FullName, typeof(ItemDetailPage));
            Routing.RegisterRoute(typeof(NewItemPage).FullName, typeof(NewItemPage));
            var services = new ServiceCollection();
            services.AddTransient<HttpClient>();
            services.AddCsla(o => o
              .DataPortal(dp => dp
                .UseHttpProxy(hp => hp
                  .DataPortalUrl = "https://localhost:44332/api/dataportal")));
            var provider = services.BuildServiceProvider();
            ApplicationContext = provider.GetService<ApplicationContext>();
            App.DataPortalFactory = provider.GetRequiredService<IDataPortalFactory>();
           // e2.CDM.Lib.OdataCsla.DataPortalFactory = App.DataPortalFactory;
           // e2.CDM.Lib.RouteEvent.Portal = e2.CDM.Lib.OdataCsla.DataPortalFactory.GetPortal<e2.CDM.Lib.RouteEvent>();

          //  var s = e2.CDM.Lib.RouteEvent.GetRouteEventAsync(new Guid());
            //  e2.CDM.Lib.RouteEvent.Portal = provider.GetRequiredService<IDataPortalFactory>();
            MainPage = new MainPage();
        }
    }
}