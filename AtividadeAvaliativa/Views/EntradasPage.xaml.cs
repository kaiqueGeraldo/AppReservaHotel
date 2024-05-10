using AtividadeAvaliativa.ViewModels;

namespace AtividadeAvaliativa.Views;

public partial class EntradasPage : ContentPage
{
	private readonly EntradasViewModel _viewModel;
	public EntradasPage()
	{
		InitializeComponent();
		_viewModel = new EntradasViewModel();
		BindingContext = _viewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
		await _viewModel.OnAppearing();
    }
}