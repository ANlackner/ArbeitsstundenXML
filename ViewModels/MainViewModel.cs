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










        [RelayCommand]
        void Anmelden()
        {
            try
            {
                XmlDocument data = new XmlDocument();
                data.Load("C:\\Users\\arian\\git\\apr3\\Dienststunden\\ArbeitsstundenXML\\Resources\\files\\data.xml");

                // hat visual studio so geändert
                foreach (var (username, password) in from XmlElement userElement in data.DocumentElement.SelectNodes("user")
                                                     let username = userElement.SelectSingleNode("username")?.InnerText
                                                     let password = userElement.SelectSingleNode("password")?.InnerText
                                                     select (username, password))
                {
                    //Vergleich...
                    if (username == InputEntry && password == InputPassword)
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
            catch (Exception ex)
            {
                this.Fehler = ex.Message;
            }
        }

        [RelayCommand]
        void Reg()
        {
            try
            {
                XmlDocument data = new XmlDocument();
                string xmlFilePath = "C:\\Users\\arian\\git\\apr3\\Dienststunden\\ArbeitsstundenXML\\Resources\\files\\data.xml";
                data.Load(xmlFilePath);

                // Überprüfen, ob der Benutzer bereits existiert
                bool userExists = data.DocumentElement.SelectNodes($"user[username='{UserEntry}']").Count > 0;

                if (userExists)
                {
                    // Hier können Sie die Logik für den Fall implementieren, dass der Benutzer bereits existiert
                    OutputText = $"Benutzer '{UserEntry}' existiert bereits.";
                }
                else
                {
                    // Neues user-Element erstellen
                    var newUser = data.CreateElement("user");

                    var usernameElement = data.CreateElement("username");
                    usernameElement.InnerText = UserEntry;
                    newUser.AppendChild(usernameElement);

                    var passwordElement = data.CreateElement("password");
                    passwordElement.InnerText = Password;
                    newUser.AppendChild(passwordElement);

                    var hoursElement = data.CreateElement("hours");
                    hoursElement.InnerText = _Hours.ToString();
                    newUser.AppendChild(hoursElement);

                    // Hinzufügen des neuen user-Elements zum root-Element der XML-Datei
                    data.DocumentElement.AppendChild(newUser);

                    // Speichern der Änderungen
                    data.Save(xmlFilePath);

                    // Erfolgreiche Registrierung
                    OutputText = $"Benutzer '{UserEntry}' erfolgreich registriert.";
                }
            }
            catch (Exception ex)
            {
                this.Fehler = ex.Message;
            }

        }


        [RelayCommand]
            void Fertig()
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
