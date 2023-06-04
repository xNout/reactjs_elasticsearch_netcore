using Elastic.Clients.Elasticsearch;
using MediatR;
using N5.CHALLENGE.APPLICATION.Interfaces;
using N5.CHALLENGE.DOMAIN.DTOs;
using N5.CHALLENGE.DOMAIN.Interfaces;

namespace N5.CHALLENGE.APPLICATION.Permisos.ListarPermisos
{
    public class ListarPermisosQueryHandler : IRequestHandler<ListarPermisosRequestModel, ListarPermisosResponseModel>
    {
        private readonly IElasticSearchAppService _elasticSearchAppService;
        private readonly IUnitOfWork _unitOfWork;

        public ListarPermisosQueryHandler(IElasticSearchAppService elasticSearchAppService, IUnitOfWork unitOfWork)
        {
            _elasticSearchAppService = elasticSearchAppService;
            _unitOfWork = unitOfWork;
        }

        public async Task<ListarPermisosResponseModel> Handle(ListarPermisosRequestModel request, CancellationToken cancellationToken)
        {
            List<PermissionDTO> permisos = await _unitOfWork.permisosRepositorio.GetAll();

            return new ListarPermisosResponseModel()
            {
                Permisos = permisos
            };
        }
        // Consulta elastic search
        private async Task<ListarPermisosResponseModel> _Handle(ListarPermisosRequestModel request, CancellationToken cancellationToken)
        {
            ElasticsearchClient client = _elasticSearchAppService.GetClient();
            SearchResponse<PermissionDTO> result = await client.SearchAsync<PermissionDTO>(s =>
                s.Query(q => q.MatchAll())
            );

            if (result.IsValidResponse)
            {
                return new ListarPermisosResponseModel()
                {
                    Permisos = result.Documents.ToList()
                };
            }

            return new ListarPermisosResponseModel()
            {
                mensajeError = "Ocurrió un error al consultar los permisos"
            };
        }
    }
}
