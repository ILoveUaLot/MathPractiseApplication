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

namespace MathPractiseApplication.View.Theory.LinearEquationTheory
{
    /// <summary>
    /// Interaction logic for LinearEquationTheoryPage4.xaml
    /// </summary>
    public partial class LinearEquationTheoryPage4 : Page
    {
        public LinearEquationTheoryPage4()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LinearEquationTheoryPage3());
        }
    }
}
