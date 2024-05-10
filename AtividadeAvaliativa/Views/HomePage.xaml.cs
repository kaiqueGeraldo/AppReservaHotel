using AtividadeAvaliativa.ViewModels;

namespace AtividadeAvaliativa.Views;

public partial class HomePage : ContentPage
{
	private readonly HomeViewModel _viewModel;
	public HomePage()
	{
		InitializeComponent();
		_viewModel = new HomeViewModel();
		BindingContext = _viewModel;
	}
}