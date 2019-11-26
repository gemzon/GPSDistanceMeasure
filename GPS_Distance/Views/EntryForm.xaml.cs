using GPS_Distance.ViewModels;
using System;
using System.Windows.Controls;

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
