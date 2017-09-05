using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    /// <summary>
    /// This class responsible for request validation
    /// </summary>
    public class CalendarServiceRequestValidation
    {

        public static bool AppointmentsRequestIsValid(string[] input)
        {
            var res = false;
            int n = -1;
            if (input.Length == 4 && int.TryParse(input[3], out n) && n <= 11)
                res = true;

            return res;
        }
        public static bool AppointmentDetailRequestIsValid(string[] input)
        {
            var res = false;
            int n;
            if (input.Length == 4 && int.TryParse(input[3], out n) && CalendarServicePoint.AllAppointments.Count(x => x.Id == n) > 0)
                res = true;

            return res;
        }
    }
}
