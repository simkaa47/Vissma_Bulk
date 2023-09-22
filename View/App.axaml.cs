using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Core.ViewModels;
using System;
using View.Utilites;
using View.Windows;

namespace View
{
    public partial class App : Application
    {
        private readonly IServiceProvider? serviceCollection;

        public App(IServiceProvider serviceCollection)
        {
            this.serviceCollection = serviceCollection;
        }


        public App()
        {

        }

        public override void Initialize()
        {
            // To provide access to any controls to get to the services
            
            AvaloniaXamlLoader.Load(this);
            Resources[typeof(IServiceProvider)] = serviceCollection;

        }

        public override void OnFrameworkInitializationCompleted()
        {
            CreateMainWindow();

            base.OnFrameworkInitializationCompleted();
        }

        /// <summary>
        ///   Called when the launcher backend wants the GUI to be restarted
        /// </summary>
        public void ReSetupMainWindow()
        {
            CreateMainWindow();
        }

        private void CreateMainWindow()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                //desktop.MainWindow = new MainWindow
                //{
                //    DataContext = this.CreateInstance<MainViewModel>(),
                //};
                desktop.MainWindow = new ProbotbornikSettingsWindow()
                {
                    DataContext = this.CreateInstance<MainViewModel>(),
                };
            }
            else if (ApplicationLifetime is ISingleViewApplicationLifetime)
            {
                // TODO: implement
                // ReSharper disable once CommentTypo
                // https://docs.avaloniaui.net/docs/getting-started/application-lifetimes#isingleviewapplicationlifetime
                throw new NotImplementedException();

                // singleView.MainView = new MainView();
            }
        }
    }
}