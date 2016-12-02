using HomeCalc.Core.Presentation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ViewModel
{
    public class MainViewModel : BasicViewModel
    {
        public MainViewModel()
        {
            AddCommand("GridOneCommand", new DelegateCommand(GridOnePressed));
            AddCommand("GridTwoCommand", new DelegateCommand(GridTwoPressed));
            AddCommand("GridSortCommand", new DelegateCommand(GridSortPressed));
        }

        private void GridSortPressed(object obj)
        {
            SortingCollection = new ObservableCollection<SortingModel>();
        }

        private void GridTwoPressed(object obj)
        {
            UIDispatcherHelper.CallOnUIThread(() =>
            {
                var list = new List<LongModel> 
            { 
                new LongModel
                {
                    Class = "First", Color = "Red", File = "system.exe", Path = "c:\\Windows", Pen = "thin_pad_pen", Severity = "High", Significance = "High"
                },
                new LongModel
                {
                    Class = "Second", Color = "Greed", File = "magnify.cmd", Path = "c:\\Program Files", Pen = "absent", Severity = "Low", Significance = "Medium"
                },
                new LongModel
                {
                    Class = "Third", Color = "Blue", File = "notes.txt", Path = "c:\\Documents", Pen = "auto_pen", Severity = "Acceptable", Significance = "Medium"
                }
            };

                ItemsCollection = new ObservableCollection<LongModel>(list);

                SortingCollection = new ObservableCollection<SortingModel>();
            });
        }

        private void GridOnePressed(object obj)
        {
            UIDispatcherHelper.CallOnUIThread(() =>
            {
                var list = new List<ShortModel> 
            { 
                new ShortModel
                {
                    Address = "Lisniy av", Email = "forestglider", Id = 0
                },
                new ShortModel
                {
                    Address = "Zhukova str", Email = "dbalykin", Id = 1
                },
                new ShortModel
                {
                    Address = "Goloseevskiy av", Email = "b_dmitriy82", Id = 2
                }
            };

                ItemsCollection = new ObservableCollection<ShortModel>(list);

                SortingCollection = new ObservableCollection<SortingModel>();
            });
        }

        private object itemsCollection;

        private ObservableCollection<SortingModel> sortingCollection;

        public object ItemsCollection
        {
            get { return itemsCollection; }
            set
            {
                if (value != itemsCollection)
                {
                    itemsCollection = value;

                    OnPropertyChanged(() => ItemsCollection);
                }
            }
        }

        public ObservableCollection<SortingModel> SortingCollection
        {
            get { return sortingCollection; }
            set
            {
                if (value != sortingCollection)
                {
                    sortingCollection = value;

                    OnPropertyChanged(() => SortingCollection);
                }
            }
        }
    }
}
