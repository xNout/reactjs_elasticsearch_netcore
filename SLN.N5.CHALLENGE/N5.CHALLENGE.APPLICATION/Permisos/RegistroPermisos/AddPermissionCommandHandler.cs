using AutoMapper;
using Elastic.Clients.Elasticsearch;
using MediatR;
using N5.CHALLENGE.APPLICATION.Interfaces;
using N5.CHALLENGE.DOMAIN.DTOs;
using N5.CHALLENGE.DOMAIN.Interfaces;

namespace N5.CHALLENGE.APPLICATION.Permisos.RegistroPermisos
{
    public class AddPermissionCommandHandler : IRequestHandler<AddPermissionRequestModel, AddPermissionResponseModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IElasticSearchAppService _elasticSearchAppService;
        private readonly IMapper _mapper;
        public AddPermissionCommandHandler(IUnitOfWork unitOfWork, IElasticSearchAppService elasticSearchAppService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _elasticSearchAppService = elasticSearchAppService;
            _mapper = mapper;
        }

        public async Task<AddPermissionResponseModel> Handle(AddPermissionRequestModel request, CancellationToken cancellationToken)
        {
            string? Description = await _unitOfWork.tipoPermisosRepositorio.GetDescription(request.TipoPermiso);
            if(string .IsNullOrEmpty(Description))
                return new AddPermissionResponseModel()
                {
                    mensajeError = "Tipo de permiso no valido"
                };

            PermissionInfoModel Model = _mapper.Map<PermissionInfoModel>(request);

            int Id = await _unitOfWork.permisosRepositorio.Create(Model);

            ElasticsearchClient client = _elasticSearchAppService.GetClient();

            PermissionDTO permiso = _mapper.Map<PermissionDTO>(Model);
            permiso.Id = Id;
            permiso.DescripcionPermiso = Description;

            IndexResponse result = await client.IndexAsync(permiso);
            if (!result.IsValidResponse)
                return new AddPermissionResponseModel()
                {
                    mensajeError = "El registro en elasticsearch no fue posible"
                };

            return new AddPermissionResponseModel()
            {
                Id = Id
            };
        }
    }
}
