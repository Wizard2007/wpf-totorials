using System;
using System.Windows.Input;

namespace FirstApp.Commands
{
    public class MyCommand : ICommand
    {
        private readonly Action _TargetExecuteMethod;
        private readonly Func<bool> _TargetCanExecuteMethod;

        public MyCommand(Action executeMethod) => _TargetExecuteMethod = executeMethod;
        
        public MyCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            _TargetExecuteMethod = executeMethod;
            _TargetCanExecuteMethod = canExecuteMethod;
        }

        public event EventHandler CanExecuteChanged = delegate { };

        bool ICommand.CanExecute(object parameter)
        {
            if (_TargetCanExecuteMethod != null)
            {
                return _TargetCanExecuteMethod();
            }

            if (_TargetExecuteMethod != null)
            {
                return true;
            }

            return false;
        }

        void ICommand.Execute(object parameter) => _TargetExecuteMethod?.Invoke();

        public void RaiseCanExecuteChanged() => CanExecuteChanged(this, EventArgs.Empty);
    }
}
