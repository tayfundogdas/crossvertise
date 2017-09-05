using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string AppointmentDateStr
        {
            get
            {
                return String.Format("{0:g}", AppointmentDate);
            }
        }
    }
}
