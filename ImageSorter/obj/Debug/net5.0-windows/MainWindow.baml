   M S B A M L   `   `   `  ����F  BImageSorter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ImageSorterImageSorter  5   	       ImageSorter.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ImageSorter     5   	     � Title$  Image Sorter��5   	   $	��450��6   $	��800��6+    � 
ResizeMode$ CanMinimize=�5	   	   .��5
      � $��10q�6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5       $��* �6   �� 5!      $��* �6   �� 5"      $��* �6   .+�5%   
   �� $��Source Folder:��6   $��2��5&      �� 5(   
   $��Target Folder:��6   $��2��5)      $��1��5*      �� 5,   
   -   5         ��Name$ sourceFolderPathTextBox��5,      �� 5.   
   -   5        $ targetFolderPathTextBox��5.      $��1��5/      �� 51   
   -   5         ��Name$  sourceFolderSelectorButton��51         folderSelectorButtons#��[  53      .��54      �� $ ��Images/FileBrowserIcon.jpg��6   55      �� 57   
   -   5        $  targetFolderSelectorButton��57      $��1��59      #��[  5:      .��5;      �� $ ��Images/FileBrowserIcon.jpg��6   5<      �� 5>   
   $��Description��6   $��25(�5?      $��4��5@      $��4��5A      $��2��5B      �� 5D   
   $����This application copies all files from the source folder, into the target folder. It does NOT differentiate between file extensions. Inside the target folder, the application will create folders based on year month of the modification date of the file. You have the option to disable subdirectory search. (Meaning the application won't check the subfolders of the source folder.)��6   $��3��5E      $��6��5F      $��3��5G      $��5��5H      $��WrapWithOverflow=�5I      $��17(�5J       �� TextAlignment$ Justify=�5K      �� 5M   
   -   5         ��Name$ subdirectorySearch��5M       d� 	IsChecked$
 TrueY�5N      $��Center=�5O      $��Center=�5P      $��18(�5Q      $��11��5R      $��4��5S      $��4��5T      .��5U      �� $��Search subfolders?��6   $��Center=�62   5V      �� 5X   
   -   5        $ 
exitButton��5X      $
��Exit��5Z        nonFolderSelectorButtons#��[ 5[      �� 5]   
   -   5        $ processButton��5]      $��Process��5_      #��[ 5`      $��10��5a      � 5c   
   -   5        	 �Name$	 processProgressbar��5c      $��7��5d      $��3��5e      $��6��5f      $��	0,10,0,10q�5g      
 � Minimum$
 0Q�5h       � Maximum$	 100Q�5i      5j      5k      