using CommunityToolkit.Mvvm.ComponentModel;
using AtividadeAvaliativa.Models;
using System;
using CommunityToolkit.Mvvm;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtividadeAvaliativa.Repositorios;

namespace AtividadeAvaliativa.ViewModels
{
    [QueryProperty(nameof(Cpf), "clienteCPF")]
    public partial class CheckOutDetailViewModel : ObservableObject
    {
        private readonly CheckinRepositorio _checkinRepositorio;
        public CheckOutDetailViewModel()
        {
            _checkinRepositorio = new CheckinRepositorio();
        }

        public string Cpf { get; set; }

        [ObservableProperty]
        private Cliente _cliente;

        public async Task OnAppearing()
        {
            Cliente = await _checkinRepositorio.GetCliente(Cpf);
        }
    }
}
