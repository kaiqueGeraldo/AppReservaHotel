using AtividadeAvaliativa.ViewModels;

namespace AtividadeAvaliativa.Views;

public partial class SettingsPage : ContentPage
{
	private readonly SettingsViewModel _viewModel;
	public SettingsPage()
	{
		InitializeComponent();
		_viewModel = new SettingsViewModel();
		BindingContext = _viewModel;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		_viewModel.OnAppearing();
	}
}