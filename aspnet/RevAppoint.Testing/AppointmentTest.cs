using System;
using RevAppoint.Domain.POCOs;
using Xunit;

 namespace RevAppoint.Testing
 {
     public class AppointmentTest
     {
         [Fact]
         public void Test_AppointmentExists()
         {
            var sut = new Appointment();
            Appointment sut1 = new Appointment();

            var actual = sut;

            Assert.IsType<Appointment>(actual);
            Assert.NotNull(actual);
         }

         [Fact]
         public void Test_TimeExists()
         {
            var sut = new Time();
            Time sut1 = new Time();

            var actual = sut;

            Assert.IsType<Time>(actual);
            Assert.NotNull(actual);
         }
     }
}