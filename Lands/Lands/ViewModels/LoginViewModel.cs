using System;


namespace Lands.ViewModels
{
    using System.ComponentModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Attributes
        public string password;
        public bool isRunning;
        public bool isEnabled;
       
        #endregion

        #region Properties
        public string Email
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
        public bool IsRunning
        {
            get;
            set;
        }
        public bool IsRemembered
        {
            get;
            set;
        }
        public bool IsEnabled
        {
            get;
            set;
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return RelayCommand(Login);
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

            if (this.Email != "a.rodriguez@gmail.com" || this.Password != "1234")
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", "Email or password incorrect", "Accept");
                return;
            }
            await Application.Current.MainPage.DisplayAlert(
                   "Ok", "You are loged!!", "Accept");
            return;

        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.IsEnabled = true;
        }


        #endregion
    }
}
