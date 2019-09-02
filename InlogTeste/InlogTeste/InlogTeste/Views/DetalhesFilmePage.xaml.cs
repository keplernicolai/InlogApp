using InlogTeste.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InlogTeste.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalhesFilmePage : ContentPage
    {
        public DetalhesFilmePage(int idFilme)
        {
            InitializeComponent();
            BindingContext = new DetalhesFilmePageViewModel(idFilme);
        }
    }
}