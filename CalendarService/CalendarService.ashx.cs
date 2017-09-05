using BusinessLogic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarService
{
    /// <summary>
    /// Summary description for CalendarService
    /// </summary>
    public class CalendarService : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            CalendarServicePoint.DataLoad();

            context.Response.ContentType = "application/json";
            var req = context.Request.RawUrl.Split(new char[] { '/' });

            if (req.Length > 2)
                switch (req[2])
                {
                    case Paths.Appointments:
                        {
                            if (CalendarServiceRequestValidation.AppointmentsRequestIsValid(req))
                            {
                                var appointments = CalendarServicePoint.GetAllAppointmentsByMonth(Convert.ToInt32(req[3]));
                                context.Response.Write(JsonConvert.SerializeObject(appointments));
                            }
                            else
                                WriteErrorToRequest(context);
                            break;
                        }
                    case Paths.AppointmentDetail:
                        {
                            if (CalendarServiceRequestValidation.AppointmentDetailRequestIsValid(req))
                            {
                                var appointment = CalendarServicePoint.GetAppointmentDetailById(Convert.ToInt32(req[3]));
                                context.Response.Write(JsonConvert.SerializeObject(appointment));
                            }
                            else
                                WriteErrorToRequest(context);
                            break;
                        }
                    default:
                        {
                            WriteErrorToRequest(context);
                            break;
                        }
                }
        }

        private void WriteErrorToRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Invalid request!");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}