using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void ProcessFileButton_Click(object sender, RoutedEventArgs e)
        {
            string inputFile = InputFileTextBox.Text;
            string outputFile = OutputFileTextBox.Text;
            int minWordLength = int.Parse(MinWordLengthTextBox.Text);
            bool removePunctuation = RemovePunctuationCheckBox.IsChecked ?? false;

            await Task.Run(() => ProcessFile(inputFile, outputFile, minWordLength, removePunctuation));

            MessageBox.Show("File processing completed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ProcessFile(string inputFile, string outputFile, int minWordLength, bool removePunctuation)
        {
            try
            {
                string[] lines = File.ReadAllLines(inputFile);
                List<string> processedLines = new List<string>();

                foreach (string line in lines)
                {
                    string[] words = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); 
                    StringBuilder processedLine = new StringBuilder();

                    foreach (string word in words)
                    {
                        if (word.Length >= minWordLength)
                        {
                            string processedWord = word;

                            if (removePunctuation)
                            {
                                processedWord = Regex.Replace(processedWord, @"[^\w\s]", "");
                            }

                            processedLine.Append(processedWord + " ");
                        }
                    }

                    processedLines.Add(processedLine.ToString().Trim());
                }

                File.WriteAllLines(outputFile, processedLines);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
