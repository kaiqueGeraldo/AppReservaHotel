using AtividadeAvaliativa.ViewModels;

namespace AtividadeAvaliativa.Views;

public partial class LoginPage : ContentPage
{
    public readonly LoginViewModel _viewModel;
    public LoginPage()
    {
        InitializeComponent();
        _viewModel = new LoginViewModel();
        BindingContext = _viewModel;
    }
}