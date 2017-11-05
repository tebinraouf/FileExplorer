using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace FileExplorer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //public string FileName { get; set; }

        public MainWindow()
        {
            InitializeComponent();

           
               
            
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var drive in Directory.GetLogicalDrives())
            {
                var item = new TreeViewItem();

                item.Header = drive;
                //Add the full path
                item.Tag = drive;
                

                item.Items.Add(null);

                

                

                //Listen 
                item.Expanded += FolderExpanded;


                FolderView.Items.Add(item);

            }


            

            

            var all = (TreeViewItem)FolderView.Items[0];
            string userName = Environment.UserName;
            JumpToNode(all, $"C:\\");
            Console.WriteLine(all.Tag);

        }
        private void ItemSelected(object sender, RoutedEventArgs e)
        {
            var item = (TreeViewItem)sender;

            Console.WriteLine((string)item.Tag);
        }
        private void FolderExpanded(object sender, RoutedEventArgs e)
        {
            var item = (TreeViewItem)sender;
            if (item.Items.Count != 1 || item.Items[0] != null)
            {
                return;
            }
            item.Items.Clear();
            var fullPath = (string)item.Tag;


            

            #region Get Folders
            var directories = new List<string>();

            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                {
                    directories.AddRange(dirs);
                }
            }
            catch { }


            foreach (var directoryPath in directories)
            {
                var subItem = new TreeViewItem();
                subItem.Header = GetFileFolderName(directoryPath);
                subItem.Tag = directoryPath;



                subItem.Items.Add(null);
                subItem.Expanded += FolderExpanded;

                //add to parent
                item.Items.Add(subItem);

            }
            #endregion


            #region Get Files

            var files = new List<string>();

            try
            {
                var fs = Directory.GetFiles(fullPath);
                if (fs.Length > 0)
                {
                    files.AddRange(fs);
                }
            }
            catch { }


            foreach (var filePath in files)
            {
                var subItem = new TreeViewItem();
                subItem.Header = GetFileFolderName(filePath);
                subItem.Tag = filePath;


                //add to parent
                item.Items.Add(subItem);

            }

            #endregion

        }
        private void SelectedItem(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var selected = (TreeViewItem)e.NewValue;
            var fullPath = (string)selected.Tag;
            var metaData = new FileInfo(fullPath);
            //labelResult.Content = metaData.CreationTime;


            //myDataGrid.ItemsSource = new DirectoryInfo(fullPath).Name;

            //myGrid.DataContext = new DirectoryInfo(fullPath).GetFiles();

            try
            {
                var files = new List<DirectoryInfo>();

                var details = new List<FileDetails>();
                var allFiles = new DirectoryInfo(fullPath).GetFiles();
                var allFolders = new DirectoryInfo(fullPath).GetDirectories();
                
                

                for (int i = 0; i < allFiles.Length; i++)
                {
                    var fd = new FileDetails();
                    fd.FileName = allFiles[i].Name;
                    fd.FileCreation = allFiles[i].CreationTime.ToString();
                    fd.FileImage = $"pack://application:,,,/Images/file.ico";
                    fd.IsFile = true;
                    details.Add(fd);
                }


                for (int i = 0; i < allFolders.Length; i++)
                {
                    var fd = new FileDetails();
                    fd.FileName = allFolders[i].Name;
                    fd.FileCreation = allFolders[i].CreationTime.ToString();
                    fd.FileImage = $"pack://application:,,,/Images/folder.ico";
                    fd.IsFolder = true;
                    fd.Path = fullPath + "\\"+allFolders[i].Name;
                    details.Add(fd);
                }



                myList.ItemsSource = details;

                Console.WriteLine(fullPath);
            }
            catch { }
            
        }
        private void SingleFileSelected(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(sender);

            var source = (ListBox)e.Source;
            var selected = (FileDetails)source.SelectedItem;

        }
        private void ItemMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            ListBox items = sender as ListBox;
            var selected = items.SelectedItem as FileDetails;
            var path = selected.Path;
            var allFolders = new DirectoryInfo(path).GetDirectories();

            var details = new List<FileDetails>();

            for (int i = 0; i < allFolders.Length; i++)
            {
                var detail = new FileDetails();
                detail.FileName = allFolders[i].Name;
                
                details.Add(detail);
            }

            myList.ItemsSource = details;
            Console.WriteLine(selected);
        }

        void JumpToNode(TreeViewItem tvi, string NodeName)
        {
            if (tvi.Tag.ToString() == NodeName)
            {
                tvi.IsExpanded = true;
                tvi.BringIntoView();
                return;
            }
            else
                tvi.IsExpanded = false;

            if (tvi.HasItems)
            {
                foreach (var item in tvi.Items)
                {
                    TreeViewItem temp = item as TreeViewItem;
                    JumpToNode(temp, NodeName);
                }
            }
        }
        public static string GetFileFolderName(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return string.Empty;
            }


            var normalizedPath = path.Replace('/', '\\');
            var lastIndex = normalizedPath.LastIndexOf('\\');

            if (lastIndex <= 0)
            {
                return path;
            }

            return path.Substring(lastIndex + 1);


        }
    }
}
