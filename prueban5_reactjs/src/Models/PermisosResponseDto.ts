import { PermisoInfoDto } from "./PermisoInfoDto";

export interface PermisosResponseDto {
    permisos: PermisoInfoDto[],
    mensajeError: string;
}