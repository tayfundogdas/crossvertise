using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BusinessLogic.Tests
{
    /// <summary>
    /// Calendar service tests
    /// </summary>
    [TestClass]
    public class CalendarTests
    {
        public int February = 2;

        /// <summary>
        /// Load test data
        /// </summary>
        [TestInitialize()]
        public void Initialize()
        {
            CalendarServicePoint.DataLoad();
        }

        /// <summary>
        /// Clear test data
        /// </summary>
        [TestCleanup()]
        public void Cleanup()
        {
            CalendarServicePoint.AllAppointments.Clear();
            CalendarServicePoint.AllAppointments = null;
        }

        /// <summary>
        /// Get february's appointments and test returned data
        /// </summary>
        [TestMethod()]
        public void TestAppointmentsMonths()
        {
            var month = 1; //february
            var february_appointments = CalendarServicePoint.GetAllAppointmentsByMonth(month);
            Assert.AreEqual(0, february_appointments.Count(x => x.AppointmentDate.Month != February));
        }

        /// <summary>
        /// Get appointment with id 10 and test returned data for correct values
        /// </summary>
        [TestMethod()]
        public void TestAppointment()
        {
            var appointmentDetailId = 10;
            var appointmentDetail = CalendarServicePoint.GetAppointmentDetailById(appointmentDetailId);
            Assert.IsNotNull(appointmentDetail.Appointment);
            Assert.AreEqual(appointmentDetail.Id, appointmentDetailId);
        }

        /// <summary>
        /// Try to make request for 13. month which is invalid
        /// </summary>
        [TestMethod()]
        public void TestAppointmentsRequest()
        {
            var req = "/CalendarService.ashx/Appointments/13".Split(new char[] { '/' });
            Assert.IsFalse(CalendarServiceRequestValidation.AppointmentsRequestIsValid(req));
        }

        /// <summary>
        /// Get appointment detail with id 500 which does not exist
        /// </summary>
        [TestMethod()]
        public void AppointmentDetailRequestIsValid()
        {
            var req = "/CalendarService.ashx/AppointmentDetail/500".Split(new char[] { '/' });
            Assert.IsFalse(CalendarServiceRequestValidation.AppointmentDetailRequestIsValid(req));
        }
    }
}
