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

        [ObservableProperty]
        int _AllHours = 0;
        

        private bool inputSaved = false;



        private Register _register = new Register();

        [RelayCommand]
        void Reg()
        {
            _register.registrieren();
        }
        


        private Anmeldung _anmeldung = new Anmeldung();
        [RelayCommand]
        void Anm()
        {
            _anmeldung.Anmelden();
        }

        

        private Hinzufuegen _hinzufuegen = new();
        [RelayCommand]
        void Hinzufuegen()
        {
            _hinzufuegen.Fertig();
        }



        [RelayCommand]
        void BerechneUndZeigeGesamteStunden()
        {
            

            // Instanz der Summe-Klasse erstellen
            Summe summe = new Summe();

            // Gesamte Stunden berechnen
            int gesamteStunden = summe.BerechneGesamteStunden(UserEntry);

            // Ausgabe der gesamten Stunden
            AllHours = gesamteStunden;
        }










    }
}
