using Model;
using Repository;
using System;
using System.Collections.Generic;


namespace Service
{
    public class GuestService : ICrud<Guest>
    {

        private static GuestService instance = null;
        List<Guest> guests = new List<Guest>();

        public void Create(Guest newGuest)
        {
            GuestRepository.Instance.CreateGuest(newGuest);
        }

        public Guest Read(int id)
        {
            return GuestRepository.Instance.ReadGuest(id);
        }

        public void Update(Guest guest)
        {
            GuestRepository.Instance.UpdateGuest(guest);
        }

        public void Delete(int id)
        {
            GuestRepository.Instance.DeleteGuest(id);
        }

        public List<Guest> GetAll()
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