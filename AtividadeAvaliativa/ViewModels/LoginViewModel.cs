using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeAvaliativa.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _cpfEntry;

        [ObservableProperty]
        private string _passwordEntry;

        [ObservableProperty]
        private bool _isPasswordHiddenT = true;

        [ObservableProperty]
        private bool _passwordIsPasswordT = true;

        public string Cpf
        {
            get => _cpfEntry;
            set
            {
                if (SetProperty(ref _cpfEntry, value))
                {
                    // Remove qualquer caractere não numérico do CPF
                    string cleanedCpf = new string(Cpf.Where(char.IsDigit).ToArray());

                    // Se o CPF estiver completo, formata para XXX.XXX.XXX-XX
                    if (cleanedCpf.Length == 11)
                    {
                        cleanedCpf = $"{cleanedCpf.Substring(0, 3)}.{cleanedCpf.Substring(3, 3)}.{cleanedCpf.Substring(6, 3)}-{cleanedCpf.Substring(9)}";
                    }

                    _cpfEntry = cleanedCpf;
                    OnPropertyChanged(nameof(Cpf));
                }
            }
        }


        public string Password
        {
            get => _passwordEntry;
            set => SetProperty(ref _passwordEntry, value);
        }

        public bool IsPasswordHidden
        {
            get => _isPasswordHiddenT;
            set
            {
                SetProperty(ref _isPasswordHiddenT, value);
            }
        }
        public bool EyeIsVisible => IsPasswordHidden;
        public bool EyeSlashIsVisible => !IsPasswordHidden;

        public bool PasswordIsPassword
        {
            get => _passwordIsPasswordT;
            set => SetProperty(ref _passwordIsPasswordT, value);
        }

        [RelayCommand]
        public async Task ToGoToHomePage()
        {
            if (Cpf == "472.158.318-41" && Password == "123456789")
            {
                await Shell.Current.GoToAsync("//HomePage");
            }
            else if (string.IsNullOrWhiteSpace(Cpf) || string.IsNullOrWhiteSpace(Password))
            {
                await Shell.Current.DisplayAlert("Erro", "Por favor, preencha todos os campos.", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Erro", "CPF ou Senha inválidos! Tente Novamente.", "OK");
            }
        }

        [RelayCommand]
        public async Task ShowButtonClicked()
        {
            IsPasswordHidden = !IsPasswordHidden;
            PasswordIsPassword = IsPasswordHidden;
            OnPropertyChanged(nameof(EyeIsVisible));
            OnPropertyChanged(nameof(EyeSlashIsVisible));
        }
    }
}
