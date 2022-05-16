
using Model;
using System;
using Service;
using System.Collections.Generic;

namespace Controller
{
    public class GuestController
    {
        public Boolean CreateGuest(Guest newGuest)
        {
            return GuestService.Instance.CreateGuest(newGuest);
        }

        public Guest ReadGuest(int id)
        {
            return GuestService.Instance.ReadGuest(id);
        }

        public Boolean UpdateGuest(Guest guest)
        {
            return GuestService.Instance.UpdateGuest(guest);
        }

        public Boolean DeleteGuest(int id)
        {
            return GuestService.Instance.DeleteGuest(id);
        }

        public List<Guest> GetAllGuests()
        {
            return GuestService.Instance.GetAllGuests();
        }

    }
}