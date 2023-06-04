export interface PermisoInfoDto {
    id:                 number;
    nombreEmpleado:     string;
    apellidoEmpleado:   string;
    idTipoPermiso:      number;
    descripcionPermiso: string;
    fechaPermiso:       Date;
}

export interface TipoPermisoDto {
    id:          number;
    descripcion: string;
}