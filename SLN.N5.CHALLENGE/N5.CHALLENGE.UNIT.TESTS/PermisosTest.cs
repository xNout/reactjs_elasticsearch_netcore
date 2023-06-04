using MediatR;
using Microsoft.Extensions.Configuration;
using Moq;
using N5.CHALLENGE.APPLICATION.AppServices;
using N5.CHALLENGE.APPLICATION.Interfaces;
using N5.CHALLENGE.APPLICATION.Permisos.ListarPermisos;
using N5.CHALLENGE.APPLICATION.Permisos.ModificarPermisos;
using N5.CHALLENGE.APPLICATION.Permisos.ObtenerPermisos;
using N5.CHALLENGE.DOMAIN.DTOs;

namespace N5.CHALLENGE.UNIT.TESTS
{
    public class PermisosTest
    {
        [Fact]
        public async Task ModifyPermission_Test()
        {
            ModifyPermissionRequestModel Model = new() { Id = 1, NombreEmpleado = "Alberto", ApellidoEmpleado = "Fujimori", FechaPermiso = DateTime.Now, TipoPermiso = 1 };

            Mock<IMediator> mediator = new Mock<IMediator>();

            mediator.Setup(m => m.Send(Model, CancellationToken.None))
                           .ReturnsAsync(new ModifyPermissionResponseModel { wasModified = true });

            var configurationMock = new Mock<IConfiguration>();
            // en este ejemplo no se usa IConfiguration    
            configurationMock.Setup(x => x["Clave"]).Returns("Valor");

            IConfiguration configuration = configurationMock.Object;

            IPermisosAppService permisosService = new PermisosAppService(mediator.Object, configuration);

            ModifyPermissionResponseModel result = await permisosService.Modify(Model);

            Assert.True(result.wasModified);
            Assert.Null(result.mensajeError);
        }
        [Fact]
        public async Task Handle_ModifyPermission_Validations()
        {
            ModifyPermissionRequestModel Model = new() { };

            Mock<IMediator> mediator = new Mock<IMediator>();

            mediator.Setup(m => m.Send(Model, CancellationToken.None))
                           .ReturnsAsync(new ModifyPermissionResponseModel());

            var configurationMock = new Mock<IConfiguration>();
            // en este ejemplo no se usa IConfiguration
            configurationMock.Setup(x => x["Clave"]).Returns("Valor");

            IConfiguration configuration = configurationMock.Object;

            IPermisosAppService permisosService = new PermisosAppService(mediator.Object, configuration);

            ModifyPermissionResponseModel result = await permisosService.Modify(Model);

            Assert.False(result.wasModified);
            Assert.NotNull(result.mensajeError);
        }
        [Fact]
        public async Task GetPermission_Test()
        {
            GetPermissionRequestModel Model = new() { NombreEmpleado = "ALBERT", ApellidoEmpleado = "FUJ" };

            Mock<IMediator> mediator = new Mock<IMediator>();

            mediator.Setup(m => m.Send(Model, CancellationToken.None))
                           .ReturnsAsync(new ObtenerPermisosResponseDTO()
                           {
                               Permiso = new PermissionDTO
                               {
                                   Id = 1,
                                   NombreEmpleado = "ALBERTO",
                                   ApellidoEmpleado = "Fujimori",
                                   IdTipoPermiso = 1,
                                   DescripcionPermiso = "SUPERVISOR",
                                   FechaPermiso = DateTime.Now
                               }
                           });

            var configurationMock = new Mock<IConfiguration>();
            // en este ejemplo no se usa IConfiguration
            configurationMock.Setup(x => x["Clave"]).Returns("Valor");

            IConfiguration configuration = configurationMock.Object;

            IPermisosAppService permisosService = new PermisosAppService(mediator.Object, configuration);

            ObtenerPermisosResponseDTO result = await permisosService.ObtenerPermiso(Model);

            Assert.NotNull(result.Permiso);
            Assert.Null(result.mensajeError);
        }
        [Fact]
        public async Task Handle_GetPermission_Validations()
        {
            GetPermissionRequestModel Model = new();

            Mock<IMediator> mediator = new Mock<IMediator>();

            mediator.Setup(m => m.Send(Model, CancellationToken.None))
                           .ReturnsAsync(new ObtenerPermisosResponseDTO());

            var configurationMock = new Mock<IConfiguration>();
            // en este ejemplo no se usa IConfiguration
            configurationMock.Setup(x => x["Clave"]).Returns("Valor");

            IConfiguration configuration = configurationMock.Object;

            IPermisosAppService permisosService = new PermisosAppService(mediator.Object, configuration);

            ObtenerPermisosResponseDTO result = await permisosService.ObtenerPermiso(Model);

            Assert.Null(result.Permiso);
            Assert.NotNull(result.mensajeError);
        }
        [Fact]
        public async Task Handle_ListPermission_Test()
        {
            ListarPermisosRequestModel Model = new ListarPermisosRequestModel();

            Mock<IMediator> mediator = new Mock<IMediator>();

            mediator.Setup(m => m.Send(Model, CancellationToken.None))
                            .ReturnsAsync(new ListarPermisosResponseModel()
                            {
                                Permisos = new()
                                {
                                    new PermissionDTO
                                    {
                                        Id = 1,
                                        NombreEmpleado = "PEDRO",
                                        ApellidoEmpleado = "Picapiedra",
                                        IdTipoPermiso = 1,
                                        DescripcionPermiso = "SUPERVISOR",
                                        FechaPermiso = DateTime.Now
                                    }
                                }
                            });

            var configurationMock = new Mock<IConfiguration>();
            // en este ejemplo no se usa IConfiguration
            configurationMock.Setup(x => x["Clave"]).Returns("Valor");

            IConfiguration configuration = configurationMock.Object;

            IPermisosAppService permisosService = new PermisosAppService(mediator.Object, configuration);

            ListarPermisosResponseModel result = await permisosService.ObtenerTodos(Model);

            Assert.Null(result.mensajeError);
            Assert.True(result.Permisos.Any());
        }
    }
}