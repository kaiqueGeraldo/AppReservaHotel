using AtividadeAvaliativa.Models;
using AtividadeAvaliativa.Repositorios;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeAvaliativa.ViewModels
{
    public partial class CheckoutViewModel : ObservableObject
    {
        private readonly CheckinRepositorio _checkinRepositorio;

        public CheckoutViewModel()
        {
            _checkinRepositorio = new CheckinRepositorio();
        }

        [ObservableProperty]
        private Cliente _cliente;

        [ObservableProperty]
        private string _cpf;

        [ObservableProperty]
        private int _dias;

        [ObservableProperty]
        private int _totalDiarias;

        [ObservableProperty]
        private DateTime _saida;

        [ObservableProperty]
        private double _totalPagar;

        [ObservableProperty]
        private double _taxaServico;


        [RelayCommand]
        public async Task BucarInfo()
        {
            
            Cliente = await _checkinRepositorio.GetCliente(Cpf);

            if (Cliente != null)
            {
                Saida = Cliente.Entrada.AddDays(6);
                var duracao = Saida - Cliente.Entrada;
                Dias = duracao.Days;
                var valorDiaria = Preferences.Get("valorDiaria", 0.0);
                var taxaservico = Preferences.Get("taxaServico", 0.0);

                TotalDiarias = (int)(valorDiaria * Dias);

                TaxaServico = TotalDiarias * (taxaservico / 100);

                TotalPagar = TotalDiarias + TaxaServico;
            }

            else
            {
                await Shell.Current.DisplayAlert("Aviso", "Cliente Não Encontrado!", "Sair");

                return;
            }

        }

        [RelayCommand]
        public async Task Confirmar()
        {
            await _checkinRepositorio.DeleteCliente(Cliente);

            await Shell.Current.DisplayAlert("Sucesso", "Pago com sucesso", "OK");

            await Shell.Current.GoToAsync("..");
        }

    }
}
