using AutoMapper;
using MediatR;
using N5.CHALLENGE.DOMAIN.DTOs;
using N5.CHALLENGE.DOMAIN.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.CHALLENGE.APPLICATION.TipoPermisos.ListarTipoPermisos
{
    public class ListarTipoPermisoQueryHandler : IRequestHandler<ListarTipoPermisoRequestModel, ListarTipoPermisoResponseModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ListarTipoPermisoQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ListarTipoPermisoResponseModel> Handle(ListarTipoPermisoRequestModel request, CancellationToken cancellationToken)
        {
            List<TipoPermisoInfoDTO> permisos = await _unitOfWork.tipoPermisosRepositorio.GetAll();

            return new ListarTipoPermisoResponseModel()
            {
                TipoPermisos = permisos
            };
        }
    }
}
