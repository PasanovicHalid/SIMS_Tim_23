
using Model;
using System;
using Service;
using System.Collections.Generic;
using Repository;

namespace Controller
{
    public class GuestController : ICrud<Guest>
    {
        public void Create(Guest newGuest)
        {
            GuestService.Instance.Create(newGuest);
        }

        public Guest Read(int id)
        {
            return GuestService.Instance.Read(id);
        }

        public void Update(Guest guest)
        {
            GuestService.Instance.Update(guest);
        }

        public void Delete(int id)
        {
            GuestService.Instance.Delete(id);
        }

        public List<Guest> GetAll()
        {
            return GuestService.Instance.GetAll();
        }

    }
}