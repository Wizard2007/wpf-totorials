using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FirstApp.VML
{
    public class ViewModelLocator
    {
        public static bool GetAutoHookedUpViewModel(DependencyObject obj) => (bool)obj.GetValue(AutoHookedUpModelProperty);
        public static void SetAutoHookedUpViewModel(DependencyObject obj, bool value) => obj.SetValue(AutoHookedUpModelProperty, value);

        public static readonly DependencyProperty AutoHookedUpModelProperty = DependencyProperty.RegisterAttached("AutoHookedUpModel", typeof(bool), typeof(ViewModelLocator), new PropertyMetadata(false, AutoHookedUpViewModelChanged));

        // Using a DependencyProperty as the backing store for AutoHookedUpViewModel. 

        //This enables animation, styling, binding, etc...
        private static void AutoHookedUpViewModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(DesignerProperties.GetIsInDesignMode(d)) return;

            var viewType = d.GetType();
            var str = viewType.FullName;
            str = str?.Replace(".View.", ".ViewModel.");

            var viewTypeName = str;
            var viewModelTypeName = viewTypeName + "Model";
            var viewModelType = Type.GetType(viewModelTypeName);
            var viewModel = Activator.CreateInstance(viewModelType);
            ((FrameworkElement) d).DataContext = viewModel;
        }
    }
}
