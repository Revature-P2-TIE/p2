using System;
using RevAppoint.Domain.POCOs;
using Xunit;

 namespace RevAppoint.Testing
 {
     public class UserTest
     {
         [Fact]
         public void Test_CustomerExists()
         {
            var sut = new Customer();
            Customer sut1 = new Customer();

            var actual = sut;

            Assert.IsType<Customer>(actual);
            Assert.Matches("Customer", actual.Type);
            Assert.NotNull(actual);
         }

         [Fact]
         public void Test_ProfessionalExists()
         {
            var sut = new Professional();
            Professional sut1 = new Professional();

            var actual = sut;

            Assert.IsType<Professional>(actual);
            Assert.Matches("Professional", actual.Type);
            Assert.NotNull(actual);
         }
     }
}