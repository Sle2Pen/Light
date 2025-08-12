using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Light.Commands
{
    public class AsyncRelayCommand : ICommand
    {
        private readonly Func<Task> _execute;
        private readonly Func<bool> _canExecute;
        private bool _isExecuting;

        public AsyncRelayCommand(Func<Task> execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !_isExecuting && (_canExecute?.Invoke() ?? true);
        }

        public async void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                _isExecuting = true;
                OnCanExecuteChanged();

                try
                {
                    await _execute();
                }
                finally
                {
                    _isExecuting = false;
                    OnCanExecuteChanged();
                }
            }
        }

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
