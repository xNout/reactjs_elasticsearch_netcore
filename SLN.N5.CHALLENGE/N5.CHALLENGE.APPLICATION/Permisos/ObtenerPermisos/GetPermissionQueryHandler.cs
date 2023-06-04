using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.QueryDsl;
using MediatR;
using N5.CHALLENGE.APPLICATION.Interfaces;
using N5.CHALLENGE.DOMAIN.DTOs;
using N5.CHALLENGE.DOMAIN.Interfaces;

namespace N5.CHALLENGE.APPLICATION.Permisos.ObtenerPermisos
{
    public class GetPermissionQueryHandler : IRequestHandler<GetPermissionRequestModel, ObtenerPermisosResponseDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IElasticSearchAppService _elasticSearchAppService;
        public GetPermissionQueryHandler(IUnitOfWork unitOfWork, IElasticSearchAppService elasticSearchAppService)
        {
            _unitOfWork = unitOfWork;
            _elasticSearchAppService = elasticSearchAppService;
        }

        public async Task<ObtenerPermisosResponseDTO> Handle(GetPermissionRequestModel request, CancellationToken cancellationToken)
        {
            ElasticsearchClient client = _elasticSearchAppService.GetClient();
            SearchResponse<PermissionDTO> result = await client.SearchAsync<PermissionDTO>(s =>
                s.Query(q =>
                    q.Bool(b => b.
                            Should(
                                m => m.Match(t => t.Field(f => f.NombreEmpleado).Query(request.NombreEmpleado ?? "").Operator(Operator.And)),
                                m => m.Match(t => t.Field(f => f.ApellidoEmpleado).Query(request.ApellidoEmpleado ?? "").Operator(Operator.And))
                            )
                    )
                )
            );

            if (result.IsValidResponse)
            {

                PermissionDTO? permiso = result.Documents.FirstOrDefault();

                return new ObtenerPermisosResponseDTO()
                {
                    Permiso = permiso,
                    mensajeError = permiso is null ? "El permiso consultado no existe" : null
                };
            }

            return new ObtenerPermisosResponseDTO()
            {
                mensajeError = "Ocurrió un error al consultar los permisos"
            };
        }
    }
}
