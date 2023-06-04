import { AppThunkAction } from "..";
import { PermisosActions } from "./actions";
import axios, { AxiosResponse } from 'axios';
import { API } from "../../settings";
import { PermisoInfoDto, TipoPermisoDto } from '../../Models/PermisoInfoDto';
import Swal from "../../Common/Swal";
import { ModificarPermisoDto } from "../../Models/ModificarPermisoDto";
import { TipoPermisosResponse } from "../../Models/TipoPermisosResponse";
import { PermisosResponseDto } from "../../Models/PermisosResponseDto";
import { SolicitarPermisoModelDto } from "../../Models/SolicitarPermisoModelDto";
import { SolicitarPermisoResponseDto } from "../../Models/SolicitarPermisoResponseDto";
import { ModificarPermisoResponseDto } from "../../Models/ModificarPermisoResponseDto";

export const actionCreators = {

    loadTipoPermisos: ():AppThunkAction<PermisosActions> => (dispatch, getState) => {

        axios.get<TipoPermisosResponse>(`${API.url}${API.modulo.tipoPermiso}`)
        .then(result => {
            const { data, status } = result;
            if(status != 200)
            {
                Swal.Error("No se recibió respuesta por parte del API");
                return;
            }

            const { tipoPermisos } = data;

            dispatch({ type:"RECEIVE_TIPO_PERMISOS", data: tipoPermisos });
        })
        .catch(err => {
            
        });
    },
    modificar:(id: number, Model: ModificarPermisoDto):AppThunkAction<PermisosActions> => (dispatch, getState) => {
        axios.put<ModificarPermisoResponseDto>(`${API.url}${API.modulo.permisos}/${id}`, Model)
        .then((result: AxiosResponse) => {
            const { data, status } = result;
            if(status == 404)
            {
                Swal.Error("No se recibió respuesta por parte del API");
                return;
            }
            const { wasModified, mensajeError } = data;
            if(wasModified === true)
            {
                Swal.Exito("Permiso modificado con éxito");
            }
            else{
                Swal.Error(mensajeError);
            }
        })
        .catch(err => {
            
            Swal.Info("El permiso a modificar no existe");
        });

    },
    get: (model: SolicitarPermisoModelDto):AppThunkAction<PermisosActions> => (dispatch, getState) => {



        dispatch({ type:"REQUEST_SOLC_PERMISO", id: 0 });

        axios.post<SolicitarPermisoResponseDto>(`${API.url}${API.modulo.permisosObtener}`, model)
        .then(result => {
            const { data, status } = result;
            if(status != 200)
            {
                Swal.Error("No se recibió respuesta por parte del API");
                return;
            }

            const { permiso, mensajeError } = data;
            if(!permiso)
            {
                Swal.Error(mensajeError);
            }
            
            dispatch({ type:"RECEIVE_SOLC_PERMISO", data: permiso });

        })
        .catch(err => {
            Swal.Info("El permiso solicitado no existe");
            dispatch({ type:"RECEIVE_SOLC_PERMISO", data: undefined });
        });
    },

    getAll: ():AppThunkAction<PermisosActions> => (dispatch, getState) => {
        axios.get<PermisosResponseDto>(`${API.url}${API.modulo.permisos}`)
        .then(result => {
            const { data, status } = result;
            if(status != 200)
            {
                Swal.Error("No se recibió respuesta por parte del API");
                return;
            }
            
            const { permisos } = data;
            dispatch({ type:"RECEIVE_PERMISOS", data: permisos });
        })
        .catch(err => {
            Swal.Error("Ocurrió un error interno");
        });
    },
    enviarFormOCCaja:(): AppThunkAction<PermisosActions> => (dispatch, getState) => {

        

    }
};