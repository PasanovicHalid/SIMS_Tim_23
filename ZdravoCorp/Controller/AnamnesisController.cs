using Model;
using System;
using System.Collections.Generic;
using Service;
using Repository;


namespace Controller
{
    public class AnamnesisController : ICrud<Anamnesis>
    {
        public void Create(Anamnesis newAnamnesis)
        {
            AnamnesisService.Instance.Create(newAnamnesis);
        }

        public Anamnesis Read(int id)
        {
            return AnamnesisService.Instance.Read(id);
        }

        public void Update(Anamnesis anamnesis)
        {
            AnamnesisService.Instance.Update(anamnesis);

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Anamnesis> GetAll()
        {
            return AnamnesisService.Instance.GetAll();
        }

        public Anamnesis FindAnamnesisByAppointmentId(int id)
        {
            return AnamnesisService.Instance.FindAnamnesisByAppointmentId(id);
        }
        public AnamnesisController()
        {

        }
    }
}