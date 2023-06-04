using AutoMapper;
using Elastic.Clients.Elasticsearch;
using MediatR;
using Microsoft.Extensions.Configuration;
using N5.CHALLENGE.APPLICATION.Interfaces;
using N5.CHALLENGE.DOMAIN.DTOs;
using N5.CHALLENGE.DOMAIN.Interfaces;

namespace N5.CHALLENGE.APPLICATION.Permisos.ModificarPermisos
{
    public class ModifyPermissionCommandHandler : IRequestHandler<ModifyPermissionRequestModel, ModifyPermissionResponseModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IElasticSearchAppService _elasticSearchAppService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public ModifyPermissionCommandHandler(IUnitOfWork unitOfWork, IElasticSearchAppService elasticSearchAppService, IConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _elasticSearchAppService = elasticSearchAppService;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<ModifyPermissionResponseModel> Handle(ModifyPermissionRequestModel request, CancellationToken cancellationToken)
        {
            string? Description = await _unitOfWork.tipoPermisosRepositorio.GetDescription(request.TipoPermiso);
            if (string.IsNullOrEmpty(Description))
                return new ModifyPermissionResponseModel()
                {
                    mensajeError = "Tipo de permiso no valido"
                };

            PermissionInfoModel Model = _mapper.Map<PermissionInfoModel>(request);

            bool result = await _unitOfWork.permisosRepositorio.Modify(request.Id, Model);

            if (!result)
                return new ModifyPermissionResponseModel()
                {
                    mensajeError = "Registro no existe"
                };

            ElasticsearchClient client = _elasticSearchAppService.GetClient();

            PermissionDTO permiso = _mapper.Map<PermissionDTO>(Model);
            permiso.Id = request.Id;
            permiso.DescripcionPermiso = Description;

            string indexName = _configuration["elastic-search:defaultIndex"];
            UpdateResponse<PermissionDTO> updateResult = await client.UpdateAsync<PermissionDTO, PermissionDTO>(indexName, request.Id, x => x.Doc(permiso));
            if (!updateResult.IsValidResponse)
                return new ModifyPermissionResponseModel()
                {
                    mensajeError = "La actualización en elasticsearch no fue posible"
                };

            return new ModifyPermissionResponseModel()
            {
                wasModified = result
            };
        }
    }
}
