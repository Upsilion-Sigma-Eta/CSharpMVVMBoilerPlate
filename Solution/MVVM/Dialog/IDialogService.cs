using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Dialog
{
    interface IDialogService
    {
        /// <summary>
        /// Show a dialog with the specified view model.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="viewModel">The view model to show.</param>
        void ShowDialog<TViewModel>(TViewModel viewModel) where TViewModel : class;
        /// <summary>
        /// Show a dialog with the specified view model and return a result.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="viewModel">The view model to show.</param>
        /// <returns>The result of the dialog.</returns>
        TResult ShowDialog<TViewModel, TResult>(TViewModel viewModel) where TViewModel : class;
    }
}
