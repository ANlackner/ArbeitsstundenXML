using ArbeitsstundenXML.ViewModels;

namespace ArbeitsstundenXML
{
    public partial class MainPage : ContentPage
    {
        private bool inputSaved = false;
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
            
        }
        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (!inputSaved)
            {
                string userInput = inputEntry.Text;
                string userPassword = inputPassword.Text;
                outputLabel.Text = "User: " + userInput;
                inputEntry.IsReadOnly = true; //deaktiviert das mögliche Zweite eingeben
                inputSaved = true;
            }
        }



    }

}
