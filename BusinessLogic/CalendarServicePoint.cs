using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    /// <summary>
    /// This class responsible for service handling
    /// </summary>
    public class CalendarServicePoint
    {
        public static List<Appointment> AllAppointments;

        public static void DataLoad()
        {
            if (AllAppointments == null)
            {
                AllAppointments = new List<Appointment>();
                var rnd = new Random();
                for (byte i = 1; i < byte.MaxValue; ++i)
                {
                    AllAppointments.Add(new Appointment() { Id = i, Description = "Appointment " + i.ToString(), AppointmentDate = new DateTime(2017, rnd.Next(1, 12), rnd.Next(1, 25), rnd.Next(1, 24), 0, 0) });
                }
            }
        }

        public static List<Appointment> GetAllAppointmentsByMonth(int month)
        {
            var res = AllAppointments.Where(x => x.AppointmentDate.Month == (month + 1)).ToList();
            return res;
        }

        public static AppointmentDetail GetAppointmentDetailById(int Id)
        {
            var res = new AppointmentDetail();
            res.Id = Id;
            res.Appointment = AllAppointments.FirstOrDefault(x => x.Id == Id);
            res.Organizer = new Person() { Name = "Name of " + Id.ToString(), Surname = "Surname of " + Id.ToString() };
            res.Attendees = new List<Attendee>();
            res.Attendees.Add(new Attendee() { Name = "TestName1", Surname = "TestSurname1" });
            res.Attendees.Add(new Attendee() { Name = "TestName2", Surname = "TestSurname2" });
            res.Attendees.Add(new Attendee() { Name = "TestName3", Surname = "TestSurname3" });
            return res;
        }
    }
}
