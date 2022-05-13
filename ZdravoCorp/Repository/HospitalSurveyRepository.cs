// File:    AppointmentRepository.cs
// Author:  Dusko
// Created: Sunday, 10 April 2022 22:43:17
// Purpose: Definition of Class AppointmentRepository

using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class HospitalSurveyRepository
    {
        private String dbPath = "..\\..\\Data\\hospitalSurveysDB.csv";
        private Serializer<HospitalSurvey> serializerAppointment = new Serializer<HospitalSurvey>();

        private static HospitalSurveyRepository instance = null;

        public List<int> getAllHospitalSurveyIds() {
            List<HospitalSurvey> surveys = GetAllHospitalSurveys();
            List<int> ids = new List<int>();
            foreach(HospitalSurvey survey in surveys)
            {
                ids.Add(survey.Id);
            }
            return ids;
        }
        public void generateId(HospitalSurvey newSurvey)
        {
            List<int> allSurveyIds = getAllHospitalSurveyIds();
            Random random = new Random();
            do
            {
                newSurvey.Id = random.Next();
            }
            while (allSurveyIds.Contains(newSurvey.Id));

        }
        public Boolean CreateHospitalSurvey(HospitalSurvey newSurvey)
        {
            List<HospitalSurvey> surveys = GetAllHospitalSurveys();
            generateId(newSurvey);
            surveys.Add(newSurvey);
            serializerAppointment.ToCSV(dbPath, surveys);
            return true;
        }

        public HospitalSurvey ReadHospitalSurvey(int id)
        {
            List<HospitalSurvey> surveys = GetAllHospitalSurveys();
            HospitalSurvey appointmentSurvey = null;
            foreach (HospitalSurvey survey in surveys)
            {
                if (id == survey.Id)
                {
                    //appointment.doctor = DoctorRepository.Instance.ReadDoctor(appointment.doctor.Id);
                    //appointment.Room = RoomRepository.Instance.ReadRoom(appointment.Room.Identifier);
                    //appointment.Patient = PatientRepository.Instance.ReadPatient(appointment.Patient.Id);
                    appointmentSurvey = survey;
                    break;
                }
            }
            return appointmentSurvey;
        }

        public List<HospitalSurvey> GetSurveysById(List<int> id)
        {
            List<HospitalSurvey> surveys = serializerAppointment.FromCSV(dbPath);
            List<HospitalSurvey> surveyById = new List<HospitalSurvey>();
            foreach (HospitalSurvey survey in surveys)
            {
               foreach (int i in id)
                {
                    if(survey.Id == i)
                    {
                        surveyById.Add(survey);
                    }
                }
            }
            return surveyById;
        }

        public Boolean UpdateHospitalSurvey(HospitalSurvey appointment)
        {
            Boolean success = false;
            List<HospitalSurvey> surveys = GetAllHospitalSurveys();
            for (int i = 0; i< surveys.Count; i++)
            {
                if (appointment.Id== surveys[i].Id) 
                {
                    success = true;
                    surveys[i] = appointment;
                    break;
                }
            }
            if (success)
            {
                surveys.Add(appointment);
                serializerAppointment.ToCSV(dbPath, surveys);
                
            }
            return success;

        }

        public Boolean DeleteHospitalSurvey(int id)
        {
            Boolean success = false;
            List<HospitalSurvey> appointments = GetAllHospitalSurveys();
            foreach (HospitalSurvey temp in appointments)
            {
                if (temp.Id == id)
                {
                    //success = true;
                    //appointments.Remove(temp);
                    //Doctor d = DoctorRepository.Instance.ReadDoctor(temp.doctor.Id);
                    //d.RemoveAppointment(temp);
                    //DoctorRepository.Instance.UpdateDoctor(d);
                    //Room r = RoomRepository.Instance.ReadRoom(temp.Room.Identifier);
                    //r.RemoveAppointment(temp);
                    //RoomRepository.Instance.UpdateRoom(r);
                    //Patient p = PatientRepository.Instance.ReadPatient(temp.Patient.Id);
                    //p.RemoveAppointment(temp);
                    //PatientRepository.Instance.UpdatePatient(p);
                    //serializerAppointment.ToCSV(dbPath, appointments);
                    //break;
                }
            }
            return success;
        }

        public List<HospitalSurvey> GetAllHospitalSurveys()
        {
            List<HospitalSurvey> surveys = serializerAppointment.FromCSV(dbPath); 
            //foreach (AppointmentSurvey survey in surveys)
            //{
            //    //appointment.doctor = DoctorRepository.Instance.ReadDoctor(appointment.doctor.Id);
            //    //appointment.Room = RoomRepository.Instance.ReadRoom(appointment.Room.Identifier);
            //    //appointment.Patient = PatientRepository.Instance.ReadPatient(appointment.Patient.Id);
            
            //}
            return surveys;
            
        }

        public HospitalSurveyRepository()
        {
            
        }

        public static HospitalSurveyRepository Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new HospitalSurveyRepository();
                }
                return instance ;
            }
        }
    }
}