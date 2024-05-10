using AtividadeAvaliativa.ViewModels;

namespace AtividadeAvaliativa.Views;

public partial class CheckOutPage : ContentPage
{
	private readonly CheckoutViewModel _viewModel;
	public CheckOutPage()
	{
		InitializeComponent();
		_viewModel = new CheckoutViewModel();
		BindingContext = _viewModel;
	}
}