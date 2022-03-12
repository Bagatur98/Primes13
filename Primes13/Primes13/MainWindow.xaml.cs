using System;
using System.Collections.Generic;
using System.Diagnostics;
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


namespace Primes13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static char[] digits = new char[] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C'};
        public MainWindow()
        {
            InitializeComponent();
        }
        public static string ConvertBase10ToBase13(int input)
        {
            string result = string.Empty;
            do
            {
                char remainChar = digits[input % 13];
                result = remainChar + result;
                input /= 13;
            }
            while (input != 0);
            return result;
        }
        public static int ConvertBase13ToBase10(string input)
        {
            int result = 0;
            for(int i = 0; i < input.Length; i++)
            {
                int pow = input.Length - i - 1;
                if (Array.IndexOf(digits, input[i]) == -1)
                {
                    throw new ArgumentException("Invalid input!");
                }
                result += (int)(Array.IndexOf(digits, input[i]) * Math.Pow(13, pow));
            }
            return result;
        }
        public static List<int> GetFirstNPrimes(int n)
        {
            List<int> result = new List<int>();
            int current = 2;
            while(result.Count < n)
            {
                if (IsPrime(current, result)) result.Add(current);
                current++;
            }
            return result;
        }
        public static bool IsPrime(int input, List<int> primesSoFar)
        {
            foreach(int prime in primesSoFar)
            {
                if(input % prime == 0)
                {
                    return false;
                }
                if (prime*prime > input) break;
            }
            return true;
        }

        public static List<string> Main(string input)
        {
            int inputDEC;
            try
            {
                inputDEC = ConvertBase13ToBase10(input);
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            List<int> resultsInt = GetFirstNPrimes(inputDEC);
            List<string> results13 = new List<string>();
            foreach (int prime in resultsInt)
            {
                results13.Add(ConvertBase10ToBase13(prime));
            }
            return results13;
        }

        private void runButton_Click(object sender, RoutedEventArgs e)
        {
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            List<string> result;
            try
            {
                result = Main(inputBox.Text);
            }
            catch (ArgumentException ex)
            {
                outputBox.Text = ex.Message;
                outputBox.Foreground = new SolidColorBrush(Colors.Red);
                return; 
            }
            outputBox.Foreground = new SolidColorBrush(Colors.Black);
            outputBox.Text = string.Join(", ", result);
            //sw.Stop();
            //MessageBox.Show(sw.ElapsedMilliseconds.ToString());
        }
    }
}
