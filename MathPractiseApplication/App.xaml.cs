using MaterialDesignThemes.Wpf;
using MathPractiseApplication.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
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
            var AuthorizationView = new AuthorizationView();
            AuthorizationView.Show();
            AuthorizationView.IsVisibleChanged += (s, ev) =>
            {
                if (AuthorizationView.IsVisible == false && AuthorizationView.IsLoaded)
                {
                    var mainView = new Main();
                    mainView.Show();
                    AuthorizationView.Close();
                }
            };
        }
    }
}
