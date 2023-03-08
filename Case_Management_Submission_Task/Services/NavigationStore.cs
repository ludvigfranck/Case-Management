using Case_Management_Submission_Task.MVVM.ViewModels;
using System;

namespace Case_Management_Submission_Task.Services
{
    internal class NavigationStore
    {
        public event Action? CurrentViewModelChanged;

        private ObservableObject? _currentViewModel;

        public ObservableObject CurrentViewModel
        {
            get => _currentViewModel!;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
