using ArbeitsstundenXML.ViewModels;

namespace ArbeitsstundenXML
{
    public partial class MainPage : ContentPage
    {
       
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }

       
    }

}
