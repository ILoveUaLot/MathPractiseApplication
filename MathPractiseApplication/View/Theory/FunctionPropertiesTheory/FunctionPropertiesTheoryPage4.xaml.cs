using MathPractiseApplication.View.Theory.LinearEquationTheory;
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
    /// Interaction logic for FunctionPropertiesTheoryPage4.xaml
    /// </summary>
    public partial class FunctionPropertiesTheoryPage4 : Page
    {
        public FunctionPropertiesTheoryPage4()
        {
            InitializeComponent();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FunctionPropertiesTheoryPage3());
        }
    }
}
