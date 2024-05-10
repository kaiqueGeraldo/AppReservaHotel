using AtividadeAvaliativa.Views;

namespace AtividadeAvaliativa
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CheckinPage), typeof(CheckinPage));
            Routing.RegisterRoute(nameof(CheckOutPage), typeof(CheckOutPage));
            Routing.RegisterRoute(nameof(CheckOutDetail), typeof(CheckOutDetail));
        }
    }
}
