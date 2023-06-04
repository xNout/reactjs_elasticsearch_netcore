import { TipoPermisoDto } from "./PermisoInfoDto";

export interface TipoPermisosResponse {
    tipoPermisos:   TipoPermisoDto[];
    mensajeError: string;
}