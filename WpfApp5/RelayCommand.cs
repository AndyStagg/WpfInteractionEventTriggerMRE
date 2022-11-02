﻿using System;
using System.Windows.Input;

namespace WpfApp5
{
    public class RelayCommand : ICommand
    {
        private Predicate<object> _canExecuteMethod;
        private Action<object> _executeMethod;

        public RelayCommand(Action<object> executeMethod, Predicate<object> canExecuteMethod = null)
        {
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecuteMethod == null)
            {
                return true;
            }
            else
            {
                return _canExecuteMethod(parameter);
            }
        }

        public void Execute(object parameter)
        {
            _executeMethod(parameter);
        }
    }
}
