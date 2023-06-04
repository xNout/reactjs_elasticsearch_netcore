import { PermisoInfoDto, TipoPermisoDto } from '../../Models/PermisoInfoDto';

export default interface PermisosState
{
    listado: PermisoInfoDto[],
    tipoPermisos: TipoPermisoDto[],
    solicitado: PermisoInfoDto | undefined,
    id_solicitado: number | undefined
}