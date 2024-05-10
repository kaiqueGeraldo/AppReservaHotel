using AtividadeAvaliativa.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeAvaliativa.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        [RelayCommand]
        public async Task ToGoToCheckInPage()
        {
            await Shell.Current.GoToAsync("CheckinPage");
        }
        
        [RelayCommand]
        public async Task ToGoToCheckOutPage()
        {
            await Shell.Current.GoToAsync("CheckOutPage");
        }
    }
}
