using GPS_Distance.Models;
using GPS_Distance.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GPS_Distance.Views
{
    /// <summary>
    /// Interaction logic for EntryForm.xaml
    /// </summary>
    public partial class EntryForm : UserControl
    {
        public EntryForm()
        {
            InitializeComponent();
            DataContext = new EntryFormViewModel();
            
        }

      
    }
}
