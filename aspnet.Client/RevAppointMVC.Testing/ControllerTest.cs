using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RevAppoint.Client.Controllers;
using RevAppoint.Client.Models;
using Xunit;

namespace RevAppointMVC.Testing
{
     public class ControllerTest
     {
        //CustomerControllerTest
        [Fact]
        public async Task SelectUser_ReturnsAViewResult()
        {
            var controller = new CustomerController();
            var user = new UserModel();
            
            var result = await controller.SelectUser(user);

            var viewResult = Assert.IsType<ViewResult>(result);
        }

        //CustomerControllerTest
        [Fact]
        public async Task CustomerAppointmentHistory_ReturnsAViewResult_WithUserName()
        {
            var controller = new CustomerController();
            var user = "UserId";

            var result = await controller.AppointmentHistory(user);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<AppointmentViewModel>(viewResult.ViewData.Model);
            Assert.Equal(user, model.CustomerUsername);
        }

        //CustomerControllerTest
        [Fact]
        public async Task CustomerCurrentAppointments_ReturnsAViewResult_WithUserName()
        {
            var controller = new CustomerController();
            var user = "UserId";

            var result = await controller.CurrentAppointments(user);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<AppointmentViewModel>(viewResult.ViewData.Model);
            Assert.Equal(user, model.CustomerUsername);
        }

        //CustomerControllerTest
        [Fact]
        public async Task CustomerPendingAppointments_ReturnsAViewResult_WithUserName()
        {
            var controller = new CustomerController();
            var user = "UserId";

            var result = await controller.PendingAppointments(user);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<AppointmentViewModel>(viewResult.ViewData.Model);
            Assert.Equal(user, model.CustomerUsername);
        }

        //CustomerControllerTest
        [Fact]
        public async Task DisplayProfessionals_ReturnsAViewResult()
        {
            var controller = new CustomerController();
            var user = new CustomerViewModel();

            var result = await controller.DisplayProfessionals(user);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<CustomerViewModel>(viewResult.ViewData.Model);
            Assert.Equal(user, model);
        }

        //CustomerControllerTest
        [Fact]
        public async Task ViewProfessional_ReturnsAViewResult()
        {
            var controller = new CustomerController();
            var user = new CustomerViewModel();

            var result = await controller.ViewProfessional(user);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<CustomerViewModel>(viewResult.ViewData.Model);
            Assert.Equal(user, model);
        }

        //CustomerControllerTest
        [Fact]
        public void CreateAppointment_ReturnsAViewResult()
        {
            var controller = new CustomerController();
            var user = new CustomerViewModel();
            user.Username = "";

            var result = controller.CreateAppointment(user);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<AppointmentViewModel>(viewResult.ViewData.Model);
            Assert.Equal("", model.CustomerUsername);
        }

        //ProfessionalControllerTest
        [Fact]
        public async Task ProfessionalHome_ReturnsAViewResult()
        {
            var controller = new ProfessionalController();
            var user = new ProfessionalViewModel();

            var result = await controller.ProfessionalHome(user);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewData.Model);
        }

        //ProfessionalControllerTest
        [Fact]
        public async Task SetAvailability_ReturnsAViewResult()
        {
            var controller = new ProfessionalController();
            var user = "UserId";

            var result = await controller.SetAvailability(user);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ProfessionalViewModel>(viewResult.ViewData.Model);
            Assert.Equal(user, model.Username);
        }

        //ProfessionalControllerTest
        [Fact]
        public async Task ViewProfile_ReturnsAViewResult()
        {
            var controller = new ProfessionalController();
            var user = "UserId";

            var result = await controller.ViewProfile(user);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ProfessionalViewModel>(viewResult.ViewData.Model);
            Assert.Equal(user, model.Username);
        }

        //ProfessionalControllerTest
        [Fact]
        public async Task ProfessionalAppointmentHistory_ReturnsAViewResult_WithUserName()
        {
            var controller = new ProfessionalController();
            var user = "UserId";

            var result = await controller.AppointmentHistory(user);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<AppointmentViewModel>(viewResult.ViewData.Model);
            Assert.Equal(user, model.ProfessionalUsername);
        }

        //ProfessionalControllerTest
        [Fact]
        public async Task ProfessionalCurrentAppointments_ReturnsAViewResult_WithUserName()
        {
            var controller = new ProfessionalController();
            var user = "UserId";

            var result = await controller.CurrentAppointments(user);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<AppointmentViewModel>(viewResult.ViewData.Model);
            Assert.Equal(user, model.ProfessionalUsername);
        }

        //ProfessionalControllerTest
        [Fact]
        public async Task ProfessionalPendingAppointments_ReturnsAViewResult_WithUserName()
        {
            var controller = new ProfessionalController();
            var user = "UserId";

            var result = await controller.PendingAppointments(user);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<AppointmentViewModel>(viewResult.ViewData.Model);
            Assert.Equal(user, model.ProfessionalUsername);
        }

        //ProfessionalControllerTest
        [Fact]
        public async Task CompleteAppointment_ReturnsAViewResult_WithUserName()
        {
            var controller = new ProfessionalController();
            var user = new AppointmentViewModel();

            var result = await controller.CompleteAppointment(user);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewData.Model);
        }

        //ProfessionalControllerTest
        [Fact]
        public async Task AcceptAppointment_ReturnsAViewResult_WithUserName()
        {
            var controller = new ProfessionalController();
            var user = new AppointmentViewModel();

            var result = await controller.AcceptAppointment(user);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewData.Model);
        }
     }
}