﻿using MathPractiseApplication.View.Theory.LinearEquationTheory;
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

namespace MathPractiseApplication.View.Theory.SystemOfEquationSolutionTheory
{
    /// <summary>
    /// Interaction logic for SystemOfEquationSolutionTheoryPage1.xaml
    /// </summary>
    public partial class SystemOfEquationSolutionTheoryPage1 : Page
    {
        public SystemOfEquationSolutionTheoryPage1()
        {
            InitializeComponent();
        }
        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SystemOfEquationSolutionTheoryPage2());
        }
    }
}
