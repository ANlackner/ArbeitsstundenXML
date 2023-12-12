using ArbeitsstundenXML.ViewModels;

namespace ArbeitsstundenXML
{
    public partial class MainPage : ContentPage
    {
       
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
            usernamesuccess = this.FindByName<usernamesuccess>("displayText");
        }

        

        private void Button_Clicked(object sender, EventArgs e)
        {
            usernamesuccess = Username;
            passwordsuccess = Password;
        }
    }

}
