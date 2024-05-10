using AtividadeAvaliativa.ViewModels;

namespace AtividadeAvaliativa.Views;

public partial class CheckinPage : ContentPage
{
	private readonly CheckinViewModel _viewModel; 
	public CheckinPage()
	{
		InitializeComponent();
		_viewModel = new CheckinViewModel();
		BindingContext = _viewModel;
	}
}