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
    public partial class MainWindow : Window // Объявление класса MainWindow, наследующего от Window
    {
        public MainWindow() // Конструктор класса MainWindow
        {
            InitializeComponent(); // Инициализация компонентов окна
        }

        private async void ProcessFileButton_Click(object sender, RoutedEventArgs e) // Обработчик события нажатия на кнопку ProcessFileButton
        {
            string inputFile = InputFileTextBox.Text; // Считывание текста из текстового поля InputFileTextBox
            string outputFile = OutputFileTextBox.Text; // Считывание текста из текстового поля OutputFileTextBox
            int minWordLength = int.Parse(MinWordLengthTextBox.Text); // Преобразование текста из текстового поля MinWordLengthTextBox в целое число
            bool removePunctuation = RemovePunctuationCheckBox.IsChecked ?? false; // Получение значения флажка RemovePunctuationCheckBox

            await Task.Run(() => ProcessFile(inputFile, outputFile, minWordLength, removePunctuation)); // Асинхронный запуск обработки файла

            MessageBox.Show("File processing completed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information); // Вывод сообщения об успешном завершении обработки файла
        }

        private void ProcessFile(string inputFile, string outputFile, int minWordLength, bool removePunctuation) // Метод для обработки файла
        {
            try // Блок обработки исключений
            {
                string[] lines = File.ReadAllLines(inputFile); // Чтение всех строк из входного файла
                List<string> processedLines = new List<string>(); // Инициализация списка для обработанных строк


                foreach (string line in lines) // Цикл по строкам файла
                {
                    string[] words = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); // Разделение строки на слова
                    StringBuilder processedLine = new StringBuilder(); // Создание объекта для формирования обработанной строки

                    foreach (string word in words) // Цикл по словам строки
                    {
                        if (word.Length >= minWordLength) // Проверка длины слова
                        {
                            {
                                string processedWord = word; // Инициализация обработанного слова

                                if (removePunctuation) // Проверка необходимости удаления знаков пунктуации
                                {
                                    processedWord = Regex.Replace(processedWord, @"[^\w\s]", ""); // Удаление знаков пунктуации
                                }

                                processedLine.Append(processedWord + " "); // Добавление обработанного слова к обработанной строке
                            }
                        }

                        processedLines.Add(processedLine.ToString().Trim()); // Добавление обработанной строки в список
                    }

                    File.WriteAllLines(outputFile, processedLines); // Запись всех обработанных строк в выходной файл
                }
            }
            catch (Exception ex) // Обработка исключений
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error); // Вывод сообщения об ошибке
            }
        }
    }
}
