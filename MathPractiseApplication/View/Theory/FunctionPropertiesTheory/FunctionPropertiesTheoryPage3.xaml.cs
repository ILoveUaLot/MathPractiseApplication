using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MathPractiseApplication.View.Theory.FunctionPropertiesTheory
{
    /// <summary>
    /// Interaction logic for FunctionPropertiesTheoryPage3.xaml
    /// </summary>
    public partial class FunctionPropertiesTheoryPage3 : Page
    {
        public FunctionPropertiesTheoryPage3()
        {
            InitializeComponent();
        }
        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FunctionPropertiesTheoryPage4());
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FunctionPropertiesTheoryPage2());
        }
    }
}
