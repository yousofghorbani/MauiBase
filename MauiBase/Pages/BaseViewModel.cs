using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiBase.Pages
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}