using System;


namespace Lands.ViewModels
{
    using System.ComponentModel;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;

    public class LoginViewModel : BaseViewModel
    {

        #region Attributes
        public string email;
        public string password;
        public bool isRunning;
        public bool isEnabled;
       
        #endregion

        #region Properties
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }
        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }
        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }
        public bool IsRemembered
        {
            get;
            set;
        }
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }
        
        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
              
                await Application.Current.MainPage.DisplayAlert(
                    "Error", "You must enter an  email", "Accept");
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", "You must enter a password", "Accept");
                this.Password = string.Empty;
                return;
            }
            this.isRunning = true;
            this.isEnabled = false;

            if (this.Email != "a.rodriguez@gmail.com" || this.Password != "1234")
            {
                this.isRunning = false;
                this.isEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error", "Email or password incorrect", "Accept");
                return;
            }
            this.isRunning = true;
            this.isEnabled = false;
            this.Email = string.Empty;
            this.password = string.Empty;

            MainViewModel.GetInstance().Lands = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());

        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.IsEnabled = true;
            this.Email = "a.rodriguez@gmail.com";
            this.Password = "1234";
            // http://restcountries.eu/rest/v2/all
        }

        #endregion
    }
}
