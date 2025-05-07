using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace MobileAttendanceApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly AuthService _authService;

        private string username;
        private string password;
        private bool isBusy;
        private string errorMessage;

        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                errorMessage = value;
                OnPropertyChanged();
            }
        }

        public IAsyncRelayCommand LoginCommand { get; }

        public LoginViewModel(AuthService authService)
        {
            _authService = authService;
            LoginCommand = new AsyncRelayCommand(OnLogin);
        }

        private async Task OnLogin()
        {
            if (!ValidateInput())
                return;

            IsBusy = true;
            ErrorMessage = string.Empty;

            try
            {
                bool isValid = await _authService.ValidateCredentialsAsync(Username, Password);
                if (!isValid)
                {
                    ErrorMessage = "Username atau Password salah.";
                }
                else
                {
                    // Navigate to the next page
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Terjadi kesalahan: {ex.Message}";
            }
            finally
            {
                IsBusy = false;
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Username dan Password harus diisi.";
                return false;
            }
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}