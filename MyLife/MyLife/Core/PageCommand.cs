using MyLife.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MyLife.Core
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class PageCommand : ICommand
    {
        private BaseViewModel _viewModel;
        private readonly bool _isCanBlocked;
        private readonly Func _func;

        public delegate void FuncAction();
        public delegate void Func(object obj);
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Комманда которая аттачится к ViewModel
        /// </summary>
        /// <param name="vm">ViewModel которая будет блокироваться после нажатия</param>
        /// <param name="act">Действие которое будет выполнено</param>
        /// <param name="canBlocked">Будет ли комманда перед выполнением блокировать ViewModel?</param>
        public PageCommand(BaseViewModel vm, FuncAction act, bool canBlocked = true)
        {
            _viewModel = vm ?? throw new Exception("ViewModel не должна быть null");
            _isCanBlocked = canBlocked;

            _func = (arg) => act();
        }

        public PageCommand(BaseViewModel vm, Func f, bool canBlocked = true)
        {
            _viewModel = vm ?? throw new Exception("ViewModel не должна быть null");
            _isCanBlocked = canBlocked;

            _func = (arg) => f(arg);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_viewModel.IsActivity == false)
                return;

            if (_isCanBlocked)
                _viewModel.IsActivity = false;

            _func(parameter);
        }
    }

}
