using MaterialDesignThemes.Wpf;
using MathPractiseApplication.Services;
using MathPractiseApplication.View;
using MathPractiseApplication.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows;

namespace MathPractiseApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void ApplicationStart(object sender, EventArgs e)
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<IPractiseService, PractiseModelService>();
            serviceCollection.AddTransient<PractiseViewModel>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            ServiceLocator.Initialize(serviceProvider);


            var AuthorizationView = new AuthorizationView();
            AuthorizationView.Show();
            
        }
    }
}
