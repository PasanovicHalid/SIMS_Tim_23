using Model;
using Repository;
using System;
using System.Collections.Generic;


namespace Service
{
    public class GuestService
    {

        private static GuestService instance = null;
        List<Guest> guests = new List<Guest>();

        public Boolean CreateGuest(Guest newGuest)
        {
            return GuestRepository.Instance.CreateGuest(newGuest);
        }

        public Guest ReadGuest(int id)
        {
            return GuestRepository.Instance.ReadGuest(id);
        }

        public Boolean UpdateGuest(Guest guest)
        {
            return GuestRepository.Instance.UpdateGuest(guest);
        }

        public Boolean DeleteGuest(int id)
        {
            return GuestRepository.Instance.DeleteGuest(id);
        }

        public List<Guest> GetAllGuests()
        {
            return GuestRepository.Instance.GetAllGuests();
        }

        public GuestService()
        {

        }

        public static GuestService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GuestService();
                }
                return instance;
            }
        }
       


    }
}