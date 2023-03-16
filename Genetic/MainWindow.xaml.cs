using System;
using System.Windows;
using System.Windows.Controls;

namespace Genetic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            DataPopulation dataPopulation = new(X1Left.Text, X1Right.Text, X2Left.Text, X2Right.Text,
                SizePopulation.Text, NumberOfPopulation.Text, MutationProbability.Text, Func.Text);
            var population = dataPopulation.Create();
            var r1 = new CalculateIndividual();
            var newPopulation = r1.CalculateValues(population, dataPopulation.function);
            Individual MinimumOfFunction = newPopulation[0];
            Individual Min = MinimumOfFunction;
            if ((bool)Real.IsChecked && !(bool)Bin.IsChecked)
            {
                var a = new AlghoritmReal();
                Min = a.CalculateReal(MinimumOfFunction, dataPopulation, newPopulation);
            }
            if (!(bool)Real.IsChecked && (bool)Bin.IsChecked)
            {
                var a = new AlghoritmReal();
                Min = a.CalculateBinary(MinimumOfFunction, dataPopulation, newPopulation);
            }
            MinFunc.Text = Min.funcValue.ToString();
            X1Min.Text = Min.x1Value.ToString();
            X2Min.Text = Min.x2Value.ToString();
        }
    }
}
