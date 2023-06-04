import { configureStore } from '@reduxjs/toolkit';
import { applyMiddleware, combineReducers, compose, PreloadedState } from 'redux';
import thunk from 'redux-thunk';
import { ApplicationState, reducers } from './';

const rootReducer = combineReducers({
    ...reducers
  })

export default function ConfigStore(preloadedState?: PreloadedState<ApplicationState>) {

    return configureStore(
        {
            reducer: rootReducer,
            middleware: (getDefaultMiddleware) => getDefaultMiddleware().concat(thunk),
            preloadedState
        }
    );
}
