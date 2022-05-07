using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoCorp.View.Core;

namespace ZdravoCorp.View.Manager.ViewModel
{
    public class RoomsViewModel : ObservableObject
    {
        public RoomController roomController;

        public ObservableCollection<Room> RoomsCollection
        {
            get;
            set;
        }

        public RoomsViewModel()
        {
            roomController = new RoomController();
            RoomsCollection = new ObservableCollection<Room>();
            //UpdateTable();
        }

        //private void UpdateTable()
        //{
        //    RoomsCollection = new ObservableCollection<Room>();
        //    List<Room> rooms = roomController.GetAllRooms();
        //    foreach (Room room in rooms)
        //    {
        //        RoomsCollection.Add(room);
        //    }
        //    //RoomTable.DataContext = RoomsCollection;
        //}
    }
}
