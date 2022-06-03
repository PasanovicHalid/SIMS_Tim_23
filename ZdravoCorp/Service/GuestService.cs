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
            GuestRepository.Instance.Create(newGuest);
        }

        public Guest Read(int id)
        {
            return GuestRepository.Instance.Read(id);
        }

        public void Update(Guest guest)
        {
            GuestRepository.Instance.Update(guest);
        }

        public void Delete(int id)
        {
            GuestRepository.Instance.Delete(id);
        }

        public List<Guest> GetAll()
        {
            return GuestRepository.Instance.GetAll();
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