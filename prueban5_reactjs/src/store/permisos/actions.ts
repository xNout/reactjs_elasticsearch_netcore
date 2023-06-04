import { PermisoInfoDto, TipoPermisoDto } from "../../Models/PermisoInfoDto";

interface ReceivePermisosInfo {
    type: 'RECEIVE_PERMISOS';
    data: PermisoInfoDto[];
}

interface ReceiveTipoPermisos {
    type: 'RECEIVE_TIPO_PERMISOS';
    data: TipoPermisoDto[];
}

interface RequestPermisoInfo {
    type: 'REQUEST_SOLC_PERMISO';
    id: number;
}

interface ReceivePermisoInfo {
    type: 'RECEIVE_SOLC_PERMISO';
    data: PermisoInfoDto | undefined;
}
export  type PermisosActions = ReceivePermisosInfo | ReceivePermisoInfo | RequestPermisoInfo | ReceiveTipoPermisos;