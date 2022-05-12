// File:    AppointmentRepository.cs
// Author:  Dusko
// Created: Sunday, 10 April 2022 22:43:17
// Purpose: Definition of Class AppointmentRepository

using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class AppointmentSurveyRepository
    {
        private String dbPath = "..\\..\\Data\\appointmentSurveysDB.csv";
        private Serializer<AppointmentSurvey> serializerAppointment = new Serializer<AppointmentSurvey>();

        private static AppointmentSurveyRepository instance = null;

        public List<int> getAllAppointmentSurveyIds() {
            List<AppointmentSurvey> surveys = GetAllAppointmentSurveys();
            List<int> ids = new List<int>();
            foreach(AppointmentSurvey survey in surveys)
            {
                ids.Add(survey.Id);
            }
            return ids;
        }
        public void generateId(AppointmentSurvey newSurvey)
        {
            List<int> allSurveyIds = getAllAppointmentSurveyIds();
            Random random = new Random();
            do
            {
                newSurvey.Id = random.Next();
            }
            while (allSurveyIds.Contains(newSurvey.Id));

        }
        public Boolean CreateAppointmentSurvey(AppointmentSurvey newSurvey)
        {
            List<AppointmentSurvey> surveys = GetAllAppointmentSurveys();
            generateId(newSurvey);
            surveys.Add(newSurvey);
            serializerAppointment.ToCSV(dbPath, surveys);
            return true;
        }

        public AppointmentSurvey ReadAppointmentSurvey(int id)
        {
            List<AppointmentSurvey> surveys = GetAllAppointmentSurveys();
            AppointmentSurvey appointmentSurvey = null;
            foreach (AppointmentSurvey survey in surveys)
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

        public List<AppointmentSurvey> GetSurveysById(List<int> id)
        {
            List<AppointmentSurvey> surveys = serializerAppointment.FromCSV(dbPath);
            List<AppointmentSurvey> surveyById = new List<AppointmentSurvey>();
            foreach (AppointmentSurvey survey in surveys)
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

        public Boolean UpdateAppointmentSurvey(AppointmentSurvey appointment)
        {
            Boolean success = false;
            List<AppointmentSurvey> surveys = GetAllAppointmentSurveys();
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

        public Boolean DeleteAppointmentSurvey(int id)
        {
            Boolean success = false;
            List<AppointmentSurvey> appointments = GetAllAppointmentSurveys();
            foreach (AppointmentSurvey temp in appointments)
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

        public List<AppointmentSurvey> GetAllAppointmentSurveys()
        {
            List<AppointmentSurvey> surveys = serializerAppointment.FromCSV(dbPath); 
            //foreach (AppointmentSurvey survey in surveys)
            //{
            //    //appointment.doctor = DoctorRepository.Instance.ReadDoctor(appointment.doctor.Id);
            //    //appointment.Room = RoomRepository.Instance.ReadRoom(appointment.Room.Identifier);
            //    //appointment.Patient = PatientRepository.Instance.ReadPatient(appointment.Patient.Id);
            
            //}
            return surveys;
            
        }

        public AppointmentSurveyRepository()
        {
            
        }

        public static AppointmentSurveyRepository Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new AppointmentSurveyRepository();
                }
                return instance ;
            }
        }
    }
}