﻿using System;
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
    /// Interaction logic for LinearEquationTheoryPage2.xaml
    /// </summary>
    public partial class LinearEquationTheoryPage2 : Page
    {
        public LinearEquationTheoryPage2()
        {
            InitializeComponent();
        }
        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LinearEquationTheoryPage3());
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LinearEquationTheoryPage1());
        }
    }
}
