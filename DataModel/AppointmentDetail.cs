using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AppointmentDetail
    {
        public int Id { get; set; }
        public Appointment Appointment { get; set; }
        public Person Organizer { get; set; }
        public List<Attendee> Attendees { get; set; }
    }
}
