using System;

namespace Case_Management_Submission_Task.Helpers
{
    internal class ActionCommand : BaseCommand
    {
        private readonly Action<object> _action;
        private readonly Func<object, bool> _canExecute;

        public ActionCommand(Action<object> action, Func<object, bool> canExecute)
        {
            _action = action ?? throw new ArgumentNullException("action", "You must specify an Action<T>");
            _canExecute = canExecute;
        }

        public override void Execute(object? parameter)
        {
            _action(parameter!);
        }
    }
}
