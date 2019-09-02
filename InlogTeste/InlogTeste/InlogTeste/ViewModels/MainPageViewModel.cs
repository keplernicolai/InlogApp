using InlogTeste.Models;
using InlogTeste.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace InlogTeste.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {

        #region Properties

        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                OnPropertyChanged();

                if(searchText.Count() > 0)
                {
                    var list = ResultadoFilmes.Where(f => f.title.ToLower().Contains(searchText.ToLower())).ToList();
                    ResultadoFilmes = new ObservableCollection<Filme>(list);
                }
                else
                    ResultadoFilmes = new ObservableCollection<Filme>(respostaAPI.results);

            }
        }

        private RespostaAPI respostaAPI = new RespostaAPI();

        private ObservableCollection<Filme> resultadoFilmes;
        public ObservableCollection<Filme> ResultadoFilmes
        {
            get { return resultadoFilmes; }
            set { resultadoFilmes = value; OnPropertyChanged(); }
        }

        private Filme filmeSelecionado;
        public Filme FilmeSelecionado
        {
            get { return filmeSelecionado; }
            set { filmeSelecionado = value; OnPropertyChanged(); IrDetalhesFilme(filmeSelecionado.id); }
        }

        #endregion

        public MainPageViewModel()
        {
            BuscarFilmes();
        }

        private async void BuscarFilmes()
        {
            try
            {
                if (Utils.ConexaoInternetUtils.IsConnectInternet())
                {
                    Acr.UserDialogs.UserDialogs.Instance.ShowLoading("Aguarde...");
                    respostaAPI = await Utils.WebServiceBase<RespostaAPI>.RequestAsync(Utils.ConstURL.UrlFilmes, 0);
                    ResultadoFilmes = new ObservableCollection<Filme>(respostaAPI.results);
                    Acr.UserDialogs.UserDialogs.Instance.HideLoading();
                }
            }

            catch(Exception ex)
            {
                Acr.UserDialogs.UserDialogs.Instance.HideLoading();
                Acr.UserDialogs.UserDialogs.Instance.Alert(ex.Message);
            }
            
        }

        private async void IrDetalhesFilme(int idFilme)
        {
            if (Utils.ConexaoInternetUtils.IsConnectInternet())
                await Utils.NavigationService.PushAsync(new DetalhesFilmePage(idFilme));
        }
    }
}
