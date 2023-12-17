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
        [ObservableProperty]
        int _hours = 0;

        [ObservableProperty]
        string _fehler = string.Empty;


        [RelayCommand]
       void Fertig()
        {
            try
            {
                var rootElement = new XElement("root");
                var nodeData = new XElement("data");
                var valueAttribute = new XAttribute("user", "abcdefg");
                nodeData.Add(valueAttribute);
                nodeData.Add(new XAttribute("id", Guid.NewGuid().ToString()));
                rootElement.Add(nodeData);
                rootElement.Save("Data.xml");



                var secondnodePwd = new XElement("data");
                secondnodePwd.Add(new XAttribute("user", Hours));
                secondnodePwd.Add(new XAttribute("id", Guid.NewGuid().ToString()));
                rootElement.Add(secondnodePwd);


                rootElement.Save("data.xml");


            }
            catch(Exception ex)
            {
                this.Fehler = ex.Message;
            }
            

            
        }


    }
}
