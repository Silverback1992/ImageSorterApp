using Ookii.Dialogs.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ImageSorter
{
    public static class Utility
    {
        public static void SelectFolderAndDisplayInBox(MainWindow mw, TextBox tb)
        {
            var dialog = new VistaFolderBrowserDialog();
            if (dialog.ShowDialog(mw).GetValueOrDefault())
            {
                tb.Text = dialog.SelectedPath;
            }
        }

        public static void CopyFiles(DirectoryInfo sourceFo, DirectoryInfo targetFo, bool? isSearchSubfolders, MainWindow mw)
        {
            var files = sourceFo.EnumerateFiles();

            if (isSearchSubfolders ==  true)
            {
                var directories = sourceFo.EnumerateDirectories();

                OrganizeFiles(files, targetFo, mw);

                foreach (var directory in directories)
                {
                    CopyFiles(directory, targetFo, true, mw);
                }
            }
            else
            {
                OrganizeFiles(files, targetFo, mw);
            }
        }

        private static void OrganizeFiles(IEnumerable<FileInfo> files, DirectoryInfo targetFo, MainWindow mw)
        {
            foreach (var f in files)
            {
                string lastModifiedYear = f.LastWriteTime.Year.ToString();
                string lastModifiedMonth = f.LastWriteTime.Month.ToString();

                var finalFo = GetFinalFolder(targetFo, lastModifiedYear, lastModifiedMonth);
                var finalFullFileName = $"{finalFo.FullName}\\{f.Name}";

                if(File.Exists(finalFullFileName))
                {
                    int i = 1;

                    finalFullFileName = $"{finalFo.FullName}\\{Path.GetFileNameWithoutExtension(f.Name)}_{i}{Path.GetExtension(f.Name)}";
                    
                    while (File.Exists(finalFullFileName))
                    {
                        i++;
                        finalFullFileName = $"{finalFo.FullName}\\{Path.GetFileNameWithoutExtension(f.Name)}_{i}{Path.GetExtension(f.Name)}";
                    }
                }

                File.Copy(f.FullName, finalFullFileName);
                mw.Dispatcher.Invoke(() => { mw.processProgressbar.Value++; });
            }
        }

        private static DirectoryInfo GetFinalFolder(DirectoryInfo targetFo, string lastModifiedYear, string lastModifiedMonth)
        {
            string finalFolderName = $"{lastModifiedYear}_{lastModifiedMonth}";
            var finalFolder = targetFo.EnumerateDirectories().FirstOrDefault(x => x.Name == finalFolderName);

            if (finalFolder == null)
                finalFolder = Directory.CreateDirectory($"{targetFo.FullName}\\{finalFolderName}");

            return finalFolder;
        }
    }
}
