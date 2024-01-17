using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ArbeitsstundenXML.ViewModels
{
    public partial class Register : MainViewModel
    {
        public Register() { }


        
       public void registrieren()
        {
            try
            {
               
                XDocument data = XDocument.Load("C:\\Users\\arian\\git\\apr3\\Dienststunden\\ArbeitsstundenXML\\Resources\\files\\data.xml");

                // Überprüfung ob es den Benutzer bereits gibt
                bool userExists = data.Root.Elements("user")
                    .Any(u => u.Element("username")?.Value == InputEntry);

                if (userExists)
                {
                    OutputText = $"Benutzer '{InputEntry}' existiert bereits.";
                }
                else
                {
                    // Neues Benutzer-Element erstellen
                    XElement newUser = new XElement("user",
                        new XElement("username", InputEntry),
                        new XElement("password", InputPassword),
                        new XElement("hours", Hours.ToString())
                    );

                    // Hinzufügung
                    data.Root.Add(newUser);

                    // Speichern der Änderungen
                    data.Save("C:\\Users\\arian\\git\\apr3\\Dienststunden\\ArbeitsstundenXML\\Resources\\files\\data.xml");

                    OutputText = $"Benutzer '{InputEntry}' erfolgreich registriert.";
                }
            }
            catch (Exception ex)
            {
                Fehler = ex.Message;
            }

        }
    }
}
