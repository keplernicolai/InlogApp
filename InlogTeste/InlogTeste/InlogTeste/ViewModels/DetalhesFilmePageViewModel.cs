using InlogTeste.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace InlogTeste.ViewModels
{
    public class DetalhesFilmePageViewModel : BaseViewModel
    {

        #region Properties

        private string generos;
        public string Generos
        {
            get { return generos; }
            set { generos = value; OnPropertyChanged(); }
        }

        private DetalheFilmeModel detalheFilme;
        public DetalheFilmeModel DetalheFilme
        {
            get { return detalheFilme; }
            set { detalheFilme = value; OnPropertyChanged(); }
        }

        #endregion
        public DetalhesFilmePageViewModel(int idFilme)
        {
            BuscarFilme(idFilme);
        }

        private async void BuscarFilme(int idFilme)
        {
            try
            {
                if (Utils.ConexaoInternetUtils.IsConnectInternet())
                {
                    Acr.UserDialogs.UserDialogs.Instance.ShowLoading("Aguarde...");
                    DetalheFilme = await Utils.WebServiceBase<DetalheFilmeModel>.RequestAsync(Utils.ConstURL.UrlDetalheFilme, idFilme);

                    foreach (var genero in DetalheFilme.genres)
                    {
                        Generos += genero.name + ", ";
                    }

                    Acr.UserDialogs.UserDialogs.Instance.HideLoading();
                }                    
            }

            catch (Exception ex)
            {
                Acr.UserDialogs.UserDialogs.Instance.HideLoading();
                Acr.UserDialogs.UserDialogs.Instance.Alert(ex.Message);
            }
        }
    }
}
