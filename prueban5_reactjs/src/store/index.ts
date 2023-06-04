import { PermisosReducer } from "./permisos/reducer";
import PermisosState from "./permisos/state";


// The top-level state object
export interface ApplicationState {
    permisos: PermisosState
}

// Whenever an action is dispatched, Redux will update each top-level application state property using
// the reducer with the matching name. It's important that the names match exactly, and that the reducer
// acts on the corresponding ApplicationState property type.
export const reducers = {
    permisos: PermisosReducer
};

export interface AppThunkAction<TAction> {
    (dispatch: (action: TAction) => void, getState: () => ApplicationState): void;
}
