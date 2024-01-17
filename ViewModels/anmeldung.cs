using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ArbeitsstundenXML.ViewModels
{
    public partial class Anmeldung : MainViewModel
    {

        public Anmeldung() { }


        [RelayCommand]
        public void Anmelden()
        {
            try
            {

                XDocument data = XDocument.Load("C:\\Users\\arian\\git\\apr3\\Dienststunden\\ArbeitsstundenXML\\Resources\\files\\data.xml");

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
    }
}
