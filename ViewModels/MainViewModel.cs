using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;


namespace ArbeitsstundenXML.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        public int Hours = 0;

        [ObservableProperty]
        public string userEntry = string.Empty;

        [ObservableProperty]
        public string password = string.Empty;

        [ObservableProperty]
        string _fehler = string.Empty;






        [RelayCommand]
        void Fertig(string userInput, int Hours)
        {
            bool user = userInput == user;

            if (user == true)
            {
                
                SaveUserData();
                return 
            }
            else
            {
                // Hier können Sie die Logik für den Fall implementieren, dass der Benutzer nicht gefunden wird
                Console.WriteLine($"Benutzer {userEntry} nicht gefunden.");
            }
        }
           

            [RelayCommand]
            void Anmelden(string userEntry, string userPassword)
            {
                foreach (var userElement in document.Root.Elements("user"))
                {
                    var username = userElement.Element("username")?.Value;
                    var password = userElement.Element("password")?.Value;

                    //Vergleich...
                    if (username == userEntry && password == userPassword)
                    {
                        //erfolgreiches Ende
                        Console.WriteLine("Anmeldung erfolgreich!");
                        return; 
                    }

                }



            }


        
    }
}
