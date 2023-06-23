using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MathPractiseApplication.View
{
    /// <summary>
    /// Interaction logic for AuthorizationView.xaml
    /// </summary>
    public partial class AuthorizationView : Window
    {
        public AuthorizationView()
        {
            DependencyPropertyChangedEventHandler isVisibleChangedHandler = null;

            isVisibleChangedHandler = (s, ev) =>
            {
                if (this.IsVisible == false && this.IsLoaded)
                {
                    var mainView = new Main();
                    mainView.Show();
                    this.Close();
                }
            };

            this.IsVisibleChanged += isVisibleChangedHandler;

            InitializeComponent();

            this.Closing += (s, ev) =>
            {
                this.IsVisibleChanged -= isVisibleChangedHandler;
            };
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Minimazebtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState= WindowState.Minimized;
        }

        private void Closebtn_Click(object sender, RoutedEventArgs e)
        {
            
            Close();
        }
    }
}
