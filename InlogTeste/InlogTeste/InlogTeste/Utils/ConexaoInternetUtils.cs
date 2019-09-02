using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace InlogTeste.Utils
{
    public static class ConexaoInternetUtils
    {
        public static bool IsConnectInternet()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                Acr.UserDialogs.UserDialogs.Instance.Alert("A conexão com a internet é necessária!");
                return false;
            }

            return true;
        }
    }
}
