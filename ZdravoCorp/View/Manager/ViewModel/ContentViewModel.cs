using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoCorp.View.Core;

namespace ZdravoCorp.View.Manager.ViewModel
{
    public class ContentViewModel : ObservableObject
    {
        private static ContentViewModel instance;
        private static readonly object key = new object();

        public RelayCommand MainViewCommand { get; set; }

        public RelayCommand RoomViewCommand { get; set; }

        public RelayCommand EquipmentViewCommand { get; set; }

        public MainViewModel MainVM { get; set; }

        public RoomsViewModel RoomsVM { get; set; }

        public EquipmentViewModel EquipmentVM { get; set; }

        private WindowBrowser _windowBrowser;

        private object _currentView;

        public object CurrentView
        {
            get => _currentView;
            set
            {
                if (value != _currentView)
                {
                    _currentView = value;
                    OnPropertyChanged();
                }
            }
        }

        public WindowBrowser WindowBrowser 
        { 
            get => _windowBrowser; 
            set => _windowBrowser = value; 
        
        }

        public ContentViewModel()
        {
            WindowBrowser = new WindowBrowser();
            MainVM = new MainViewModel();
            RoomsVM = new RoomsViewModel();
            EquipmentVM = new EquipmentViewModel();
            CurrentView = MainVM;

            MainViewCommand = new RelayCommand(o =>
            {
                WindowBrowser.AddWindow(MainVM);
                CurrentView = MainVM;
            });

            RoomViewCommand = new RelayCommand(o =>
            {
                WindowBrowser.AddWindow(RoomsVM);
                CurrentView = RoomsVM;
            });

            EquipmentViewCommand = new RelayCommand(o =>
            {
                WindowBrowser.AddWindow(EquipmentVM);
                CurrentView = EquipmentVM;
            });
        }

        public static ContentViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (key)
                    {
                        if (instance == null)
                        {
                            instance = new ContentViewModel();
                        }
                    }
                }
                return instance;
            }
        }
    }
}
