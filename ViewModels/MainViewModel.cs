using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        public string inputEntry = string.Empty;


        [ObservableProperty]
        public string inputPassword = string.Empty;

        [ObservableProperty]
        public string userEntry = string.Empty;

        [ObservableProperty]
        public string password = string.Empty;

        [ObservableProperty]
        string _fehler = string.Empty;

        [ObservableProperty]
        string _OutputText = string.Empty;
        

        private bool inputSaved = false;





        /*
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
        */


        [RelayCommand]
        void Anmelden()
        {
            try
            {
                XmlDocument data = new XmlDocument();
                data.Load("C:\\Users\\arian\\git\\apr3\\Dienststunden\\ArbeitsstundenXML\\Resources\\files\\data.xml");

                foreach (XmlElement userElement in data.DocumentElement.SelectNodes("user"))
                {
                    var username = userElement.SelectSingleNode("username")?.InnerText;
                    var password = userElement.SelectSingleNode("password")?.InnerText;

                    //Vergleich...
                    if (username == InputEntry && password == inputPassword)
                    {
                        //erfolgreiches Ende
                        string OutputText = $"Angemeldet: {username}";

                        return;
                    }
                    else
                    {
                        string OutputText = "Anmeldung fehlgeschlagen";
                    }

                }

            }
            catch(Exception ex) 
            {
                this.Fehler = ex.Message;
            }

            [RelayCommand]
            void Registrieren()
            {
                try
                {
                    XmlDocument data = new XmlDocument();
                    string xmlFilePath = "C:\\Users\\arian\\git\\apr3\\Dienststunden\\ArbeitsstundenXML\\Resources\\files\\data.xml";
                    data.Load(xmlFilePath);

                    // Überprüfen, ob der Benutzer bereits existiert
                    bool userExists = data.DocumentElement.SelectNodes($"user[username='{userEntry}']").Count > 0;

                    if (userExists)
                    {
                        // Hier können Sie die Logik für den Fall implementieren, dass der Benutzer bereits existiert
                        _OutputText = $"Benutzer '{userEntry}' existiert bereits.";
                    }
                    else
                    {
                        // Neues user-Element erstellen
                        var newUser = data.CreateElement("user");

                        var usernameElement = data.CreateElement("username");
                        usernameElement.InnerText = userEntry;
                        newUser.AppendChild(usernameElement);

                        var passwordElement = data.CreateElement("password");
                        passwordElement.InnerText = password;
                        newUser.AppendChild(passwordElement);

                        var hoursElement = data.CreateElement("hours");
                        hoursElement.InnerText = _Hours.ToString();
                        newUser.AppendChild(hoursElement);

                        // Hinzufügen des neuen user-Elements zum root-Element der XML-Datei
                        data.DocumentElement.AppendChild(newUser);

                        // Speichern der Änderungen
                        data.Save(xmlFilePath);

                        // Erfolgreiche Registrierung
                        OutputText = $"Benutzer '{userEntry}' erfolgreich registriert.";
                    }
                }
                catch (Exception ex)
                {
                    this.Fehler = ex.Message;
                }
            }




        }
        
    }
}
