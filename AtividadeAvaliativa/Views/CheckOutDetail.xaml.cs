using AtividadeAvaliativa.ViewModels;

namespace AtividadeAvaliativa.Views;

public partial class CheckOutDetail : ContentPage
{
    private readonly CheckOutDetailViewModel _viewModel;
    public CheckOutDetail()
	{
		InitializeComponent();
        _viewModel = new CheckOutDetailViewModel();
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.OnAppearing();
    }
}