using AutoMapper;
using ChallengeN5.Context;
using ChallengeN5.Controllers;
using ChallengeN5.Interfaces;
using ChallengeN5.Models;
using ChallengeN5.Models.DTOs;
using ChallengeN5.Models.Mappings;
using ChallengeN5.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace ChallengeN6_Test
{
    public class PermisosControllerTest
    {

        [Fact]
        public void Get_ReturnsOkResultWithItems()
        {
            // Arrange
            var permisosServiceMock = new Mock<IPermisosService>();

            // Create an AutoMapper configuration and create a IMapper instance
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            IMapper mapper = configuration.CreateMapper();

            var controller = new PermisosController(permisosServiceMock.Object, mapper);

            permisosServiceMock.Setup(service => service.GetPermisos())
                .Returns(new List<Permiso>
                {
                    new Permiso { Id = 1, NombreEmpleado = "Jhon", ApellidoEmpleado = "Wick", FechaPermiso = new DateTime(2023, 9, 12), TipoPermiso = 1 },
                    new Permiso { Id = 2, NombreEmpleado = "Bruno", ApellidoEmpleado = "Díaz", FechaPermiso = new DateTime(2023, 9, 12), TipoPermiso = 2 },
                });

            // Act
            var response = controller.GetPermisos();
            var responseType = response as OkObjectResult;
            var responseList = responseType.Value as List<PermisoDTO>;

            // Assert
            Assert.NotNull(response);
            Assert.IsType<List<PermisoDTO>>(responseType.Value);
            Assert.Equal(2, responseList.Count);
        }
    }
}