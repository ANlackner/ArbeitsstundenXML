using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbeitsstundenXML.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        public string _username = string.Empty;

        [ObservableProperty]
        public string _password = string.Empty;

        [ObservableProperty]
        int _stundenanzahl = 0;


      
      




    }
}
