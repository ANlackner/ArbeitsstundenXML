using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbeitsstundenXML.ViewModels
{
    public partial class Hinzufuegen : MainViewModel
    {

        public Hinzufuegen() { }


        [RelayCommand]
        public void Fertig()
        {
            bool user = InputEntry == UserEntry;

            if (user == true)
            {

                // SaveUserData();
                return;
            }
            else
            {
                OutputText = "Es ist ein Fehler aufgetreten.";
            }
        }
    }
}
