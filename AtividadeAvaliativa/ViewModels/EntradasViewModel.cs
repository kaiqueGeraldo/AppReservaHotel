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
    public partial class EntradasViewModel : ObservableObject
    {
        private readonly CheckinRepositorio _clientesRepositorio;
        public EntradasViewModel()
        {
            _clientesRepositorio = new CheckinRepositorio();
        }

        [ObservableProperty]
        private List<Cliente> _clientes;

        public async Task OnAppearing()
        {
            Clientes = await _clientesRepositorio.GetClientes();
        }

        [RelayCommand]
        private async Task ClienteClicado(Cliente cliente)
        {
            await Shell.Current.GoToAsync($"CheckOutDetail?clienteCPF={cliente.CPF}");
        }
    }
}
