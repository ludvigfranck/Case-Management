using Case_Management_Submission_Task.MVVM.ViewModels;
using Case_Management_Submission_Task.Services;
using System;

namespace Case_Management_Submission_Task.Helpers
{
    internal class NavigateCommand<T> : BaseCommand where T : ObservableObject
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<T> _createViewModel;

        public NavigateCommand(NavigationStore navigationStore, Func<T> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public override void Execute(object? parameter)
        {
            var viewModel = _createViewModel();
            _navigationStore.CurrentViewModel = viewModel;
        }
    }
}
