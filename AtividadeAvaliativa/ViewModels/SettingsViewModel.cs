using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeAvaliativa.ViewModels
{
    public partial class SettingsViewModel : ObservableObject
    {
        [ObservableProperty]
        private double _valorDiaria;

        [ObservableProperty]
        private double _taxaServico;

        [RelayCommand]
        public async Task DefinirValores()
        {
            Preferences.Set("valorDiaria", ValorDiaria);
            Preferences.Set("taxaServico", TaxaServico);
        }

        public void OnAppearing()
        {
            ValorDiaria = Preferences.Get("valorDiaria", 0.0);
            ValorDiaria = Preferences.Get("taxaServico", 0.0);
        }
    }
}
