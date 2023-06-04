import { Action, Reducer } from "redux";
import { PermisosActions } from "./actions";
import PermisosState from "./state";

const defaultState : PermisosState = {
    listado: [],
    tipoPermisos: [],
    id_solicitado: undefined,
    solicitado: undefined
}

export const PermisosReducer: Reducer<PermisosState> = (state: PermisosState | undefined, incomingAction: Action): PermisosState => {
    if (state === undefined) {
        return defaultState;
    }

    const action = incomingAction as PermisosActions;
    switch (action.type) {
        
        case "RECEIVE_TIPO_PERMISOS":
            return {
                ...state,
                tipoPermisos: action.data
            }

        case "RECEIVE_SOLC_PERMISO":

            return {
                ...state,
                id_solicitado: undefined,
                solicitado: action.data
            }

        case "REQUEST_SOLC_PERMISO":
            return {
                ...state,
                id_solicitado: action.id,
                solicitado: undefined
            }
        case "RECEIVE_PERMISOS":
            return {
                ...state,
                listado: [
                    ...action.data.map(x => {
                        return x;
                    })
                ]
            };

        default: break;
    }

    return state;
};