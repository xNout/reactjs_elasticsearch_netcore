import { PermisoInfoDto } from "./PermisoInfoDto";

export interface SolicitarPermisoResponseDto {
    permiso: PermisoInfoDto,
    mensajeError: string;
}