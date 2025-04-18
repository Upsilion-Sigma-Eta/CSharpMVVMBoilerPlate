using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Dialog
{
    public class DialogService : IDialogService
    {
        public void ShowDialog<TViewModel>(TViewModel viewModel) where TViewModel : class
        {

        }

        public TResult ShowDialog<TViewModel, TResult>(TViewModel viewModel) where TViewModel : class
        {
            throw new NotImplementedException();
        }
    }
}
