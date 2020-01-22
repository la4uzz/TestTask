using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Ninject;
using TestTask.App.Services;
using TestTask.Data.DataServices;
using TestTask.ViewModels.Services;
using TestTask.ViewModels.ViewModels;

namespace TestTask.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly StandardKernel _container = new StandardKernel();
        protected override void OnStartup(StartupEventArgs e)
        {
            _container.Bind<IDataService>().To<MemoryDataService>().InSingletonScope();
            _container.Bind<IBankNotifyService>().To<BankNotifyService>().InSingletonScope();
            _container.Bind<ObservableCollection<BankNotifyItemViewModel>>().ToSelf().InSingletonScope();

            Start();

            Current.DispatcherUnhandledException +=
                (s, ex) => MessageBox.Show(ex.Exception.ToString(), "Dispatcher Unhandled Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            AppDomain.CurrentDomain.UnhandledException +=
                (s, ex) => MessageBox.Show("AppDomain.CurrentDomain Exception", $"AppDomain.CurrentDomain Exception: {ex.ExceptionObject}", MessageBoxButton.OK, MessageBoxImage.Error);
            
        }

        private void Start()
        {
            MainWindow = _container.Get<MainWindow>();
            MainWindow.Show();
            MainWindow.Focus();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _container.Dispose();
            base.OnExit(e);
        }
    }
}
