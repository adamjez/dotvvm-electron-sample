using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;

namespace WebApp.ViewModels
{
    public class Page1ViewModel : DotvvmViewModelBase
    {
        public string Title { get; set; }


        public Page1ViewModel()
        {
            Title = "Hello from DotVVM: Page1ViewModel!";
        }

    }
}
