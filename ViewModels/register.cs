using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ArbeitsstundenXML.ViewModels
{
    public partial class register : MainViewModel
    {
        public register() { }


        
       public void registrieren()
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
    }
}
