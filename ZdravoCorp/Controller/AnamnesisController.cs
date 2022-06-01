using Model;
using System;
using System.Collections.Generic;
using Service;
namespace Controller
{
    public class AnamnesisController
    {
        public Boolean CreateAnamnesis(Anamnesis newAnamnesis)
        {
            return AnamnesisService.Instance.CreateAnamnesis(newAnamnesis);
        }

        public Anamnesis ReadAnamnesis(int id)
        {
            return AnamnesisService.Instance.ReadAnamnesis(id);
        }

        public Boolean UpdateAnamnesis(Anamnesis appointment)
        {
            throw new NotImplementedException();

        }

        public Boolean DeleteAnamnesis(int id)
        {
            throw new NotImplementedException();
        }

        public List<Anamnesis> GetAllAnamnesis()
        {
            return AnamnesisService.Instance.GetAllAnamnesis();
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