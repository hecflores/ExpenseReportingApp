using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpenseReportingApp.Helpers
{
    public interface IChangedCommand : ICommand
    {
        void RaiseCanExecuteChanged();
    }
    public class DelegateCommand : ICommand
    {
        private Action _action;
        private Func<bool> _canexecute;

        public DelegateCommand(Action execute, Func<bool> canexecute = null)
        {
            _action = execute;
            _canexecute = canexecute;
        }

        public event EventHandler CanExecuteChanged;

        [DebuggerStepThrough]
        public bool CanExecute(object p = null)
        {
            return _canexecute.Invoke();
        }
        public void Execute(object p = null)
        {
            _action.Invoke();
        }
    }
}
