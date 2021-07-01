using Ookii.Dialogs.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace ImageSorter
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

        private void sourceFolderSelectorButton_Click(object sender, RoutedEventArgs e) => Utility.SelectFolderAndDisplayInBox(this, sourceFolderPathTextBox);

        private void targetFolderSelectorButton_Click(object sender, RoutedEventArgs e) => Utility.SelectFolderAndDisplayInBox(this, targetFolderPathTextBox);

        private void exitButton_Click(object sender, RoutedEventArgs e) => Close();

        private void processButton_Click(object sender, RoutedEventArgs e)
        {
            string sourceFoPath = sourceFolderPathTextBox.Text;
            string targetFoPath = targetFolderPathTextBox.Text;
            bool? isSearchSubFolders = subdirectorySearch.IsChecked;

            if(String.IsNullOrWhiteSpace(sourceFoPath) || String.IsNullOrWhiteSpace(targetFoPath))
            {
                MessageBox.Show("Please provide a source path and target path first.");
            }
            else
            {
                var sourceFo = new DirectoryInfo(sourceFoPath);
                var targetFo = new DirectoryInfo(targetFoPath);

                var t = new Task(() =>
                {
                    Utility.CopyFiles(sourceFo, targetFo, isSearchSubFolders, this);
                    MessageBox.Show("Process finished.");
                    Dispatcher.Invoke(() => { processProgressbar.Value = 0; });
                });

                t.Start();
            }
        }
    }
}
