using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ViewModel;

namespace WpfGridTest
{
    public class ExtendedDataGrid : DataGrid
    {
        public static DependencyProperty SortingCollectionProperty = DependencyProperty.Register("SortingCollection", typeof(ObservableCollection<SortingModel>), typeof(ExtendedDataGrid), new UIPropertyMetadata(null, SortingCollectionPropertyChanged));

        public static void SetSortingCollection(DependencyObject source, ObservableCollection<SortingModel> value)
        {
            source.SetValue(SortingCollectionProperty, value);
        }

        public static ObservableCollection<SortingModel> GetSortingCollection(DependencyObject source)
        {
            return (ObservableCollection<SortingModel>)source.GetValue(SortingCollectionProperty);
        }

        private static void SortingCollectionPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs eventArgs)
        {
            var dataGrid = source as DataGrid;

            var columns = dataGrid.Columns;
        }
    }
}
