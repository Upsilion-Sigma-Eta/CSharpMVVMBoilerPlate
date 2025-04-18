using System.Windows.Input;

namespace MVVM.Command
{
    /// <summary>
    ///     <para>Command 패턴 지원을 위한 ICommand 구현 클래스</para>
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// <para>Command를 실행할 메서드</para>
        /// </summary>
        private Action<object> executeFunc;
        /// <summary>
        /// <para>Command의 실행 가능 여부를 판단할 메서드</para>
        /// </summary>
        private Func<object, bool> canExecuteFunc;

        /// <summary>
        /// <para>Command의 실행 가능 여부가 변경될 때 발생하는 이벤트 핸들러</para>
        /// </summary>
        public event EventHandler? CanExecuteChanged;

        /// <summary>
        /// <para>Command가 실행되면 수행되는 함수를 반환하는 프로퍼티</para>
        /// </summary>
        public Action<object> ExecuteFunction
        {
            get => executeFunc;
            set
            {
                executeFunc = value;
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// <para>Command의 실행 가능 여부를 판단하는 함수를 반환하는 프로퍼티</para>
        /// </summary>
        public Func<object, bool> CanExecuteFunction
        {
            get => canExecuteFunc;
            set
            {
                canExecuteFunc = value;
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// <para>Command를 생성하는 생성자</para>
        /// </summary>
        /// <param name="executeFunc">
        ///     <para>커맨드가 내려오면 실행될 함수. Command Parameter인 object 변수를 가지고 있음.</para>
        /// </param>
        /// <param name="canExecuteFunc">
        ///     <para>커맨드가 내려오면 함수를 실행할 수 있는지를 판단하는 함수. Command Parameter인 object 변수를 가지며, 반드시 bool 값을 반환해야 함.</para>
        /// </param>
        public RelayCommand(Action<object> executeFunc = null, Func<object, bool> canExecuteFunc = null)
        {
            this.executeFunc = executeFunc;
            this.canExecuteFunc = canExecuteFunc;
        }

        /// <summary>
        /// <para>Command의 실행 가능 여부를 판단하는 메서드</para>
        /// </summary>
        /// <param name="parameter">
        ///     <para>Command 파라미터.</para>
        /// </param>
        /// <returns>
        ///     <para>커맨드에 할당된 함수를 실행할 수 있는지 여부를 반환함</para>
        /// </returns>
        public bool CanExecute(object? parameter)
        {
            return canExecuteFunc == null || canExecuteFunc.Invoke(parameter);
        }

        /// <summary>
        /// <para>Command를 실행하는 함수. 내부적으로 CanExecute 함수를 통해서 실행 가능 여부 판단</para>
        /// </summary>
        /// <param name="parameter">
        ///     <para>Command 파라미터.</para>
        /// </param>
        public void Execute(object? parameter)
        {
            if (CanExecute(parameter))
            {
                executeFunc.Invoke(parameter);
            }
        }
    }
}
