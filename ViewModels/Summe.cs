using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ArbeitsstundenXML.ViewModels
{
    public partial class Summe : MainViewModel
    {
        public Summe()
        {
        }
        public int BerechneGesamteStunden(string UserEntry)
        {
            try
            {
                
                XDocument doc = XDocument.Load("C:\\Users\\arian\\git\\apr3\\Dienststunden\\ArbeitsstundenXML\\Resources\\files\\data.xml");

                // Linq um die Stunden summiert auszugeben
                int gesamteStunden = doc.Root.Elements("user")
                    .Where(u => (string)u.Element("username") == UserEntry)
                    .Elements("hours")
                    .Sum(h => Convert.ToInt32(h.Value));

                return gesamteStunden;
            }
            catch (Exception ex)
            {
                // Fehlerbehandlung hier...
                this.Fehler = ex.Message;
                return 0;
            }
        }
    }
}
