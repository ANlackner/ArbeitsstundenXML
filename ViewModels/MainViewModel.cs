using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace ArbeitsstundenXML.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {



        [RelayCommand]
       void Anmelden()
        {
            var rootElement = new XElement("root");
            var nodeData = new XElement("data");
            var valueAttribute = new XAttribute("user", "abcdefg");
            nodeData.Add(valueAttribute);
            nodeData.Add(new XAttribute("id", Guid.NewGuid().ToString()));
            rootElement.Add(nodeData);
           // rootElement.Save(hours);
        }

        [RelayCommand]
        void Registrieren()
        {

        }

    }
}
