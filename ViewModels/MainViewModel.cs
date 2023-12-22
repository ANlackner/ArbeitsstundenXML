using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;


namespace ArbeitsstundenXML.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        public int _Hours = 0;

        [ObservableProperty]
        public string _InputEntry = string.Empty;


        [ObservableProperty]
        public string _InputPassword = string.Empty;

        [ObservableProperty]
        public string _UserEntry = string.Empty;

        [ObservableProperty]
        public string _Password = string.Empty;

        [ObservableProperty]
        string _Fehler = string.Empty;

        [ObservableProperty]
        string _OutputText = string.Empty;
        

        private bool inputSaved = false;



        private register _register = new register();

        [RelayCommand]
        void Reg()
        {
            _register.registrieren();
        }
        


        private anmeldung _anmeldung = new anmeldung();
        [RelayCommand]
        void Anm()
        {
            _anmeldung.Anmelden();
        }

        

        private hinzufuegen _hinzufuegen = new hinzufuegen();
        [RelayCommand]
        void Hinzufuegen()
        {
            _hinzufuegen.Fertig();
        }
            




        
        
    }
}
