using AtividadeAvaliativa.Repositorios;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AtividadeAvaliativa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeAvaliativa.ViewModels
{
    public partial class CheckinViewModel : ObservableObject
    {
        private readonly CheckinRepositorio _checkinRepositorio;
        public CheckinViewModel()
        {
            _checkinRepositorio = new CheckinRepositorio();
            Entrada = DateTime.Now;
        }

        [ObservableProperty]
        private ImageSource _imagem;

        [RelayCommand]
        private async Task TirarFoto()
        {
            if (!MediaPicker.IsCaptureSupported)
            {
                await Shell
                        .Current
                        .DisplayAlert("Erro", "Câmera indisponível", "Sair");

                return;
            }

            var file = await MediaPicker.CapturePhotoAsync();

            //Usuário retornou a tela sem tirar a foto
            if (file == null)
            {
                return;
            }

            var imageStream = await file.OpenReadAsync();

            Imagem = ImageSource.FromStream(() => imageStream);
        }

        [RelayCommand]
        private async Task EscolherFoto()
        {
            var file = await MediaPicker.PickPhotoAsync();

            //Usuário retornou a tela escolher a foto
            if (file == null)
            {
                return;
            }


            var imageStream = await file.OpenReadAsync();

            Imagem = ImageSource.FromStream(() => imageStream);
        }

        [ObservableProperty]
        private string _nome;
        
        [ObservableProperty]
        private string _cpf;

        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private DateTime _entrada;

        [RelayCommand]
        private async Task Salvar()
        {
            var novoCliente = new Cliente
            {
                Nome = Nome,
                CPF = Cpf,
                Email = Email,
                Entrada = Entrada
            };

            await _checkinRepositorio.SaveCliente(novoCliente);

            await Shell
                    .Current
                        .DisplayAlert("Sucesso", "Cliente salvo", "OK");

            await Shell.Current.GoToAsync("..");
        }
    }
}
