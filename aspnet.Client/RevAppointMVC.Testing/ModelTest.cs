using System;
using RevAppoint.Client.Models;
using Xunit;


namespace RevAppointMVC.Testing
{
     public class ModelTest
     {
         [Fact]
         public void Test_AccountCreationViewModelExists()
         {
            var sut = new AccountCreationViewModel();
            AccountCreationViewModel sut1 = new AccountCreationViewModel();

            var actual = sut;

            Assert.IsType<AccountCreationViewModel>(actual);
            Assert.NotNull(actual);
         }
         [Fact]
         public void Test_AppointmentModelExists()
         {
            var sut = new AppointmentModel();
            AppointmentModel sut1 = new AppointmentModel();

            var actual = sut;

            Assert.IsType<AppointmentModel>(actual);
            Assert.NotNull(actual);
         }
         [Fact]
         public void Test_AppointmentViewModelExists()
         {
            var sut = new AppointmentViewModel();
            AppointmentViewModel sut1 = new AppointmentViewModel();

            var actual = sut;

            Assert.IsType<AppointmentViewModel>(actual);
            Assert.NotNull(actual);
         }
         [Fact]
         public void Test_CustomerModelExists()
         {
            var sut = new CustomerModel();
            CustomerModel sut1 = new CustomerModel();

            var actual = sut;

            Assert.IsType<CustomerModel>(actual);
            Assert.NotNull(actual);
         }
         [Fact]
         public void Test_CustomerViewModelExists()
         {
            var sut = new CustomerViewModel();
            CustomerViewModel sut1 = new CustomerViewModel();

            var actual = sut;

            Assert.IsType<CustomerViewModel>(actual);
            Assert.NotNull(actual);
         }
         [Fact]
         public void Test_EntityModelExists()
         {
            var sut = new EntityModel();
            EntityModel sut1 = new EntityModel();

            var actual = sut;

            Assert.IsType<EntityModel>(actual);
            Assert.NotNull(actual);
         }
         [Fact]
         public void Test_ErrorViewModelExists()
         {
            var sut = new ErrorViewModel();
            ErrorViewModel sut1 = new ErrorViewModel();

            var actual = sut;

            Assert.IsType<ErrorViewModel>(actual);
            Assert.NotNull(actual);
         }     
         [Fact]
         public void Test_LoginViewModelExists()
         {
            var sut = new LoginViewModel();
            LoginViewModel sut1 = new LoginViewModel();

            var actual = sut;

            Assert.IsType<LoginViewModel>(actual);
            Assert.NotNull(actual);
         }
         [Fact]
         public void Test_ProfessionalModelExists()
         {
            var sut = new ProfessionalModel();
            ProfessionalModel sut1 = new ProfessionalModel();

            var actual = sut;

            Assert.IsType<ProfessionalModel>(actual);
            Assert.NotNull(actual);
         }
         [Fact]
         public void Test_ProfessionalViewModelExists()
         {
            var sut = new ProfessionalViewModel();
            ProfessionalViewModel sut1 = new ProfessionalViewModel();

            var actual = sut;

            Assert.IsType<ProfessionalViewModel>(actual);
            Assert.NotNull(actual);
         }     
         [Fact]
         public void Test_TimeModelExists()
         {
            var sut = new TimeModel();
            TimeModel sut1 = new TimeModel();

            var actual = sut;

            Assert.IsType<TimeModel>(actual);
            Assert.NotNull(actual);
         } 
         [Fact]
         public void Test_TimeViewModelExists()
         {
            var sut = new TimeViewModel();
            TimeViewModel sut1 = new TimeViewModel();

            var actual = sut;

            Assert.IsType<TimeViewModel>(actual);
            Assert.NotNull(actual);
         }  
         [Fact]
         public void Test_UserModelExists()
         {
            var sut = new UserModel();
            UserModel sut1 = new UserModel();

            var actual = sut;

            Assert.IsType<UserModel>(actual);
            Assert.NotNull(actual);
         }            
     }
}
