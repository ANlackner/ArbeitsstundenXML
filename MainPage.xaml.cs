﻿using ArbeitsstundenXML.ViewModels;

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
                
                inputEntry.IsReadOnly = true; //deaktiviert die mögliche Zweite eingeben
                inputPassword.IsReadOnly = true;
                inputSaved = true;
                inputSaved = true;
                
                // lässt den Button und die Eingabe nach dem Anmelden/Registrieren erscheinen
                hours.IsVisible = true;
                commit.IsVisible = true;
                
            }
        }



    }

}
